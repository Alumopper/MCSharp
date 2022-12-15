using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 将指定的战利品放入物品栏或世界。
    /// <code>
    /// loot &lt;目标> &lt;来源>
    /// 目标：
    ///     spawn &lt;位置>
    ///     replace entity &lt;目标> &lt;起始槽位> [&lt;数量>]
    ///     replace block &lt;位置> &lt;起始槽位> [&lt;数量>]
    ///     give &lt;玩家>
    ///     insert &lt;位置>
    /// 来源：
    ///     fish &lt;loot_table> &lt;位置> [&lt;工具>|mainhand|offhand]
    ///     loot &lt;loot_table>
    ///     kill &lt;目标>
    ///     mine &lt;位置> [&lt;工具>|mainhand|offhand]
    /// </code>
    /// </summary>
    public class Loot
    {
        Target target;
        Source source;

        public class Target
        {
            Pos pos;
            op1? spawn_insert = null;
            Entity target;
            Slot slot;
            int? count;

            public enum op1
            {
                spawn,insert
            }

            /// <summary>
            /// spawn &lt;位置>
            /// </summary>
            /// <param name="spawn_insert"></param>
            /// <param name="pos"></param>
            public Target(op1 spawn_insert, Pos pos)
            {
                this.spawn_insert = spawn_insert;
                this.pos = pos;
            }

            /// <summary>
            /// give &lt;玩家>
            /// </summary>
            /// <param name="target"></param>
            public Target(Entity target)
            {
                this.target = target;
            }

            /// <summary>
            /// replace entity &lt;目标> &lt;起始槽位> [&lt;数量>]
            /// </summary>
            /// <param name="target"></param>
            /// <param name="slot"></param>
            /// <param name="count"></param>
            public Target(Entity target, Slot slot, int? count = null)
            {
                this.target = target;
                this.slot = slot;
                this.count = count;
            }

            /// <summary>
            /// replace block &lt;位置> &lt;起始槽位> [&lt;数量>]
            /// </summary>
            /// <param name="pos"></param>
            /// <param name=""></param>
            public Target(Pos pos, Slot slot, int? count = null)
            {
                this.pos = pos;
                this.slot = slot;
                this.count = count;
            }

            public override string ToString()
            {
                if(spawn_insert != null)
                {
                    return Tools.getEnumString(spawn_insert) + " " + pos;
                }else if(slot != null)
                {
                    if(pos != null)
                    {
                        return "replace block " + pos + " " + slot + " " + (count == null ? "" : count + "");
                    }
                    else
                    {
                        return "replace entity " + target + " " + slot + " " + (count == null ? "" : count + "");
                    }
                }
                else
                {
                    return "give " + target;
                }
            }
        }

        public class Source
        {
            ID loot_table;
            Pos pos;
            string tool;
            Entity target;

            /// <summary>
            /// fish &lt;loot_table> &lt;位置> [&lt;工具>|mainhand|offhand]
            /// </summary>
            /// <param name="loot_table"></param>
            /// <param name="pos"></param>
            /// <param name="tool"></param>
            public Source(ID loot_table, Pos pos, string tool)
            {
                this.loot_table = loot_table;
                this.pos = pos;
                this.tool = tool;
            }

            /// <summary>
            /// loot &lt;loot_table>
            /// </summary>
            /// <param name="loot_table"></param>
            public Source(ID loot_table)
            {
                this.loot_table = loot_table;
            }

            /// <summary>
            /// kill &lt;目标>
            /// </summary>
            /// <param name="target"></param>
            public Source(Entity target)
            {
                this.target = target;
            }

            /// <summary>
            /// mine &lt;位置> [&lt;工具>|mainhand|offhand]
            /// </summary>
            /// <param name="pos"></param>
            /// <param name="tool"></param>
            public Source(Pos pos, string tool)
            {
                this.pos = pos;
                this.tool = tool;
            }

            public override string ToString()
            {
                if(target != null)
                {
                    return "kill " + target;
                }else if(loot_table != null)
                {
                    if(pos != null)
                    {
                        return "fish " + loot_table + " " + pos + " " + tool;
                    }
                    else
                    {
                        return "loot " + loot_table;
                    }
                }
                else
                {
                    return "mine " + pos +" " + tool;
                }
            }
        }
    
        public Loot(Target target, Source source)
        {
            this.target = target;
            this.source = source;
        }

        public override string ToString()
        {
            return "loot " + target + " " + source;
        }
    }
}
