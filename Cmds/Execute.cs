using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
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
            Entity targets;

            public As(Entity targets)
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
            Entity targets;

            public At(Entity targets)
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
            Entity targets;
            Pos pos;
            string anchor;

            private static string[] ef = new string[] { "eyes", "feet" };

            public Facing(Entity targets, string eyes_feet)
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
            Entity targets;
            Pos pos;

            public Positioned(Entity targets)
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
            Entity targets;

            public Rotated(Entity targets)
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
        #endregion

        List<ExecuteChildCommand> childcommands = new List<ExecuteChildCommand>();

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
