using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    public class Execute : Command
    {
        #region ChildCommand 子命令
        public abstract class ExecuteChildCommand{}

        public class Align : ExecuteChildCommand
        {
            string axe;

            public Align(string axe)
            {
                foreach(char c in axe)
                {
                    if('x' < c || c > 'z')
                    {
                        throw new ArgumentNotMatchException("参数错误:" + axe + "。只能为xyz的组合");
                    }
                }
                this.axe = axe;
            }

            public override string ToString()
            {
                return "align " + axe;
            }
        }

        public class Anchored : ExecuteChildCommand
        {
            string anchor;

            private static string[] ef = new string[] { "eyes", "feet" };

            public Anchored(string eyes_feet)
            {
                if (!ef.Contains(eyes_feet))
                {
                    throw new ArgumentNotMatchException("参数错误:" + eyes_feet + "。应当为\"eyes\"或者\"feet\"");
                }
                this.anchor = eyes_feet;
            }

            public override string ToString()
            {
                return "anchored " + anchor;
            }
        }

        public class As : ExecuteChildCommand
        {
            Selector targets;

            public As(Selector targets)
            {
                this.targets = targets;
            }

            public override string ToString()
            {
                return "as " + targets;
            }
        }

        public class At : ExecuteChildCommand
        {
            Selector targets;

            public At(Selector targets)
            {
                this.targets = targets;
            }

            public override string ToString()
            {
                return "at " + targets; 
            }
        }

        public class Facing : ExecuteChildCommand
        {
            Selector targets;
            Pos pos;
            string anchor;

            private static string[] ef = new string[] { "eyes", "feet" };

            public Facing(Selector targets, string eyes_feet)
            {
                this.targets = targets;
                if (!ef.Contains(eyes_feet))
                {
                    throw new ArgumentNotMatchException("参数错误:" + eyes_feet + "。应当为\"eyes\"或者\"feet\"");
                }
                this.anchor = eyes_feet;
            }

            public Facing(Pos pos)
            {
                this.pos = pos;
            }

            public override string ToString()
            {
                if(targets == null)
                {
                    return "facing " + pos;
                }
                else
                {
                    return "facing" + targets + " " + anchor;
                }
            }
        }

        public class In : ExecuteChildCommand
        {
            ID dimension;

            public In(ID dimension)
            {
                this.dimension = dimension;
            }

            public override string ToString()
            {
                return "in " + dimension;
            }
        }

        public class Positioned : ExecuteChildCommand
        {
            Selector targets;
            Pos pos;

            public Positioned(Selector targets)
            {
                this.targets = targets;
            }

            public Positioned(Pos pos)
            {
                this.pos = pos;
            }

            public override string ToString()
            {
                return "positioned " + (targets == null ? pos.ToString() : ("as " + targets));
            }
        }
        
        public class Rotated : ExecuteChildCommand
        {
            Rotation rot;
            Selector targets;

            public Rotated(Selector targets)
            {
                this.targets = targets;
            }

            public Rotated(Rotation rot)
            {
                this.rot = rot;
            }

            public override string ToString()
            {
                return "rotated " + (targets == null ? rot.ToString() : ("as " + targets));
            }
        }

        public class Run : ExecuteChildCommand
        {
            Command cmd;

            public Run(Command cmd)
            {
                this.cmd = cmd;
            }

            public override string ToString()
            {
                return cmd.ToString();
            }
        }

        public class Store : ExecuteChildCommand
        {
            rs result_success;
            DataArg target;
            string path;
            Type type;
            double scale;
            int qwq;
            ID id;
            vm value_max;
            SbObject objective;

            public enum rs
            {
                result, success
            }
            public enum Type
            {
                _byte, _short, _int, _long, _float, _double
            }
            public enum vm
            {
                value, max
            }

            /// <summary>
            /// store (result|success) [block|storage|entity] &lt;target> &lt;path> &lt;type> &lt;scale> -> execute
            /// </summary>
            /// <param name="result_success"></param>
            /// <param name="targetPos">需要将数据存储到的目标方块的坐标。   </param>
            /// <param name="path">需要持有结果的NBTTag标签的位置。</param>
            /// <param name="type">被存储的数据的类型。</param>
            /// <param name="scale">存储值的倍率。</param>
            /// <exception cref="ArgumentNotMatchException"></exception>
            public Store(rs result_success, DataArg target, string path, Type type, double scale)
            {
                this.result_success = result_success;
                this.target = target;
                this.path = path;
                this.type = type;
                this.scale = scale;
                this.qwq = 0;
            }

            /// <summary>
            /// store (result|success) bossbar &lt;id> (value|max) -> execute
            /// </summary>
            /// <param name="result_success"></param>
            /// <param name="id">需要储存在的boss栏的命名空间ID</param>
            /// <param name="value_max">存储为boss栏的当前值（value）还是最大值（max）</param>
            public Store(rs result_success, ID id, vm value_max)
            {
                this.result_success = result_success;
                this.id = id;
                this.value_max = value_max;
                this.qwq = 1;
            }
            
            /// <summary>
            /// store (result|success) score &lt;targets> &lt;objective> -> execute
            /// </summary>
            /// <param name="result_success"></param>
            /// <param name="target">修改此分数持有者（可以是实体、选择器甚至不存在的玩家）的分数</param>
            /// <param name="objective">记分项。</param>
            public Store(rs result_success, Selector target, SbObject objective)
            {
                this.result_success = result_success;
                this.target = target;
                this.objective = objective;
                this.qwq = 3;
            }

            public override string ToString()
            {
                string re = "store " + Tools.GetEnumString(result_success);
                switch (qwq)
                {
                    case 0:
                        re +=  getTypeString(target) + " " + target + " " + path + " " + Tools.GetEnumString(type) + " " + scale;
                        break;
                    case 1:
                        re += " bossbar " + id + " " + Tools.GetEnumString(value_max);
                        break;
                    case 3:
                        re += " score " + target + " " + objective;
                        break;
                }
                return re;
            }

            private static string getTypeString(object o)
            {
                if (o is Pos)
                {
                    return "block";
                }
                else if (o is Selector)
                {
                    return "entity";
                }
                else if (o is ID)
                {
                    return "storage";
                }
                else
                {
                    return null;
                }
            }
        }
        
        public class If : ExecuteChildCommand
        {
            Pos pos;
            ID biome;
            BlockPredicate block;
            Pos start;
            Pos end;
            Pos destination;
            Mode all_masked;
            string path;
            Selector target;
            ID source;
            ID predicate;
            SbObject targetObjective;
            string operation;
            Selector sourceScore;
            SbObject sourceObjective;
            IntRange range;
            int type;

            public enum Mode
            {
                all,masked
            }

            /// <summary>
            /// (if|unless) biome &lt;pos> &lt;biome> -> [execute]
            /// </summary>
            /// <param name="pos"></param>
            /// <param name="biome"></param>
            public If(Pos pos, ID biome)
            {
                this.pos = pos;
                this.biome = biome;
                type = 0;
            }

            /// <summary>
            /// (if|unless) block &lt;pos> &lt;block> -> [execute]
            /// </summary>
            /// <param name="pos"></param>
            /// <param name="block"></param>
            public If(Pos pos, BlockPredicate block)
            {
                this.pos = pos;
                this.block = block;
                type = 1;
            }

            /// <summary>
            /// (if|unless) blocks &lt;start> &lt;end> &lt;destination> &lt;scan mode> -> [execute]
            /// </summary>
            /// <param name="start"></param>
            /// <param name="end"></param>
            /// <param name="destination"></param>
            /// <param name="all_masked"></param>
            public If(Pos start, Pos end, Pos destination, Mode all_masked)
            {
                this.start = start;
                this.end = end;
                this.destination = destination;
                this.all_masked = all_masked;
                type = 2;
            }

            /// <summary>
            /// (if|unless) data block &lt;pos> &lt;path> -> [execute]
            /// </summary>
            /// <param name="pos"></param>
            /// <param name="path"></param>
            /// <exception cref="ArgumentNotMatchException"></exception>
            public If(Pos pos, string path)
            {
                this.pos = pos;
                if (!NBTTag.IsLegalPath(path))
                {
                    throw new ArgumentNotMatchException("参数错误:" + path + "。不是合法的NBTTag路径");
                }
                this.path = path;
                type = 3;
            }

            /// <summary>
            /// (if|unless) data entity &lt;target> &lt;path> -> [execute]
            /// </summary>
            /// <param name="target"></param>
            /// <param name="path"></param>
            /// <exception cref="ArgumentNotMatchException"></exception>
            public If(Selector target, string path)
            {
                this.target = target;
                if (!NBTTag.IsLegalPath(path))
                {
                    throw new ArgumentNotMatchException("参数错误:" + path + "。不是合法的NBTTag路径");
                }
                this.path = path;
                type = 4;
            }

            /// <summary>
            /// (if|unless) data storage &lt;source> &lt;path> -> [execute]
            /// </summary>
            /// <param name="source"></param>
            /// <param name="path"></param>
            /// <exception cref="ArgumentNotMatchException"></exception>
            public If(ID source, string path)
            {
                this.source = source;
                if (!NBTTag.IsLegalPath(path))
                {
                    throw new ArgumentNotMatchException("参数错误:" + path + "。不是合法的NBTTag路径");
                }
                this.path = path;
                type = 5;
            }

            /// <summary>
            /// (if|unless) entity &lt;targets> -> [execute]
            /// </summary>
            /// <param name="target"></param>
            public If(Selector target)
            {
                this.target = target;
                type = 6;
            }

            /// <summary>
            /// (if|unless) predicate &lt;predicate> -> [execute]
            /// </summary>
            /// <param name="predicate"></param>
            public If(ID predicate)
            {
                this.predicate = predicate;
                type = 7;
            }

            /// <summary>
            /// (if|unless) score &lt;target> &lt;targetObjective> (&lt;|&lt;=|=|&gt;=|&gt;) &lt;source> &lt;sourceObjective> -> [execute]
            /// </summary>
            /// <param name="target"></param>
            /// <param name="targetObjective"></param>
            /// <param name="operation"></param>
            /// <param name="source"></param>
            /// <param name="sourceObjective"></param>
            public If(Selector target, SbObject targetObjective, string operation, Selector source, SbObject sourceObjective)
            {
                this.target = target;
                this.targetObjective = targetObjective;
                this.operation = operation;
                this.sourceScore = source;
                this.sourceObjective = sourceObjective;
                type = 8;
            }

            /// <summary>
            /// (if|unless) score &lt;target> &lt;targetObjective> matches &lt;range> -> [execute]
            /// </summary>
            /// <param name="target"></param>
            /// <param name="targetObjective"></param>
            /// <param name="range"></param>
            public If(Selector target, SbObject targetObjective, IntRange range)
            {
                this.target = target;
                this.targetObjective = targetObjective;
                this.range = range;
                type = 9;
            }

            public override string ToString()
            {
                string re = "";
                switch (type)
                {
                    case 0:
                        re = "if biome " + pos + " " + biome;
                        break;
                    case 1:
                        re = "if block " + pos + block;
                        break;
                    case 2:
                        re = "if blocks " + start + " " + end + " " + destination + " " + Tools.GetEnumString(all_masked);
                        break;
                    case 3:
                        re = "if data block " + pos + " " + path;
                        break;
                    case 4:
                        re = "if data entity " + target + " " + path;
                        break;
                    case 5:
                        re = "if data storage " + source + " " + path;
                        break;
                    case 6:
                        re = "if entity " + target;
                        break;
                    case 7:
                        re = "if predicate " + predicate;
                        break;
                    case 8:
                        re = "if score " + target + " " + targetObjective + " " + operation + " " + sourceScore + " " + sourceObjective;
                        break;
                    case 9:
                        re = "if score " + target + " " + targetObjective + " matches " + range;
                        break;
                }
                return re;
            }
        }

        #endregion

        readonly List<ExecuteChildCommand> childcommands = new List<ExecuteChildCommand>();

        public void Append(ExecuteChildCommand childCommand)
        {
            if(childcommands.Last() is Run)
            {
                throw new ExecuteCommandListEndException("不可在execute的run子命令后添加更多子命令");
            }
            childcommands.Add(childCommand);
        }

        public override string ToString()
        {
            StringBuilder exe = new StringBuilder("execute ");
            foreach(ExecuteChildCommand childCommand in childcommands)
            {
                exe.Append(childCommand).Append(" ");
            }
            return exe.ToString();
        }
    }
}
