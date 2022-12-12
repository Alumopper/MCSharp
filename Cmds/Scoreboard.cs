using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCSharp.Cmds.Scoreboard;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 这些命令管理记分板的目标、玩家和队伍。
    /// <code>
    /// scoreboard objectives (add|list|modify|remove|setdisplay)
    ///     add &lt;objective> &lt;rule> [&lt;display>]
    ///     list
    ///     modify &lt;rule> displayname &lt;display>
    ///     modify &lt;objective> rendertype (hearts|integer)
    ///     remove &lt;objective>
    ///     setdisplay &lt;displaySlot> [&lt;objective>]
    /// scoreboard players(add|enable|get|list|operation|remove|reset|set)
    ///     add &lt;target> &lt;objective> &lt;value>
    ///     enable &lt;target> &lt;objective(trigger)>
    ///     get &lt;target> &lt;objective>
    ///     list [&lt;target>]
    ///     operation &lt;target> &lt;objective> &lt;operation> &lt;source> &lt;sourceObject>
    ///     remove &lt;target> &lt;objective> &lt;value>
    ///     reset &lt;target> [&lt;objective>]
    ///     set &lt;target> &lt;objective> &lt;value>
    /// </code>
    /// </summary>
    public class Scoreboard : Command
    {
        #region 参数
        almrs add_list_modify_remove_setdisplay;
        SbObject objective;
        string rule;
        JsonText display;
        hi hearts_integer;
        DisplaySlot displaySlot;
        string target;
        int value;
        eg enable_get;
        string source;
        SbObject sourceObject;
        string operation;
        ars add_remove_set;

        int type;
        #endregion

        #region 枚举
        public enum almrs
        {
            add,list,modify,remove,setdisplay
        }
        public enum hi
        {
            hearts,integer
        }
        public enum eg { 
            get,enable
        }
        public enum ars
        {
            add, remove, set
        }
        #endregion

        public class Operation
        {
            public static string PLUS = "+=";
            public static string MINUS = "-=";
            public static string TIME = "*=";
            public static string DIVIDE = "/=";
            public static string REMAINDER = "%=";
            public static string ASSIGN = "=";
            public static string BIGGER = ">";
            public static string SMALLER = "<";
            public static string EXCHANGE = "><";

            public static string[] ALL = new string[] { PLUS, MINUS, TIME, DIVIDE, REMAINDER, ASSIGN, BIGGER, SMALLER, EXCHANGE };
        }

        /// <summary>
        /// 合法的显示位置
        /// </summary>
        public class DisplaySlot
        {
            public static DisplaySlot list = new DisplaySlot(Slot.list);
            public static DisplaySlot sidebar = new DisplaySlot(Slot.sidebar);
            public static DisplaySlot belowName = new DisplaySlot(Slot.belowName);

            string slot;

            /// <summary>
            /// 合法的显示位置列表
            /// </summary>
            public enum Slot
            {
                list, sidebar, sidebar_team, belowName
            }
            
            /// <summary>
            /// 生成一个合法的显示位置
            /// </summary>
            /// <param name="slot"></param>
            /// <param name="color">用于slot为sidebar_team时。其余时候即使设定也不会有效果</param>
            public DisplaySlot(Slot slot, Color.Colors? color = null)
            {
                if(slot.Equals(Slot.sidebar_team) && color == null)
                {
                    throw new ArgumentNotMatchException("需要一个颜色");
                }
                this.slot = Tools.getEnumString(slot).Replace("_",".") + (slot.Equals("sidebar.team") ? ("." + Tools.getEnumString(color)) : "");
            }

            public override string ToString()
            {
                return slot;
            }
        }

        /// <summary>
        /// scoreboard objectives add &lt;objective> &lt;rule> [&lt;display>]
        /// </summary>
        /// <param name="objective"></param>
        /// <param name="rule"></param>
        /// <param name="display"></param>
        public Scoreboard(SbObject objective, string rule, JsonText display = null)
        {
            this.objective = objective;
            this.rule = rule;
            this.display = display;
            this.type = 0;
        }

        /// <summary>
        /// scoreboard list
        /// </summary>
        public Scoreboard() {
            this.type = 1;
        }

        /// <summary>
        /// scoreboard objectives modify &lt;rule> displayname &lt;display>
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="display"></param>
        public Scoreboard(string rule, JsonText display)
        {
            this.rule = rule;
            this.display = display;
            this.type = 2;
        }

        /// <summary>
        /// scoreboard objectives modify &lt;objective> rendertype (hearts|integer)
        /// </summary>
        /// <param name="objective"></param>
        /// <param name="hearts_integer"></param>
        public Scoreboard(SbObject objective, hi hearts_integer)
        {
            this.objective = objective;
            this.hearts_integer = hearts_integer;
            this.type = 3;
        }

        /// <summary>
        /// scoreboard objectives remove &lt;objective>
        /// </summary>
        /// <param name="objective"></param>
        public Scoreboard(SbObject objective)
        {
            this.objective = objective;
            this.type = 4;
        }

        /// <summary>
        /// scoreboard objectives setdisplay &lt;displaySlot> [&lt;objective>]
        /// </summary>
        /// <param name="displaySlot"></param>
        /// <param name="objective"></param>
        public Scoreboard(DisplaySlot displaySlot, SbObject objective)
        {
            this.displaySlot = displaySlot;
            this.objective = objective;
            this.type = 5;
        }

        /// <summary>
        /// scoreboard players (add|remove|set) &lt;target> &lt;objective> &lt;value>
        /// </summary>
        /// <param name="add_remove_set"></param>
        /// <param name="target"></param>
        /// <param name="objective"></param>
        /// <param name="value"></param>
        public Scoreboard(ars add_remove_set,string target, SbObject objective, int value)
        {
            this.add_remove_set = add_remove_set;
            this.target = target;
            this.objective = objective;
            this.value = value;
            this.type = 6;
        }

        /// <summary>
        /// scoreboard players (enable|get) &lt;target> &lt;objective(trigger)>
        /// </summary>
        /// <param name="enable_get"></param>
        /// <param name="target"></param>
        /// <param name="objective"></param>
        public Scoreboard(eg enable_get, string target, SbObject objective)
        {
            this.enable_get = enable_get;
            this.target = target;
            this.objective = objective;
            this.type = 7;
        }

        /// <summary>
        /// scoreboard players list [&lt;target>]
        /// </summary>
        /// <param name="target"></param>
        public Scoreboard(string target = null)
        {
            this.target = target;
            this.type = 8;
        }

        /// <summary>
        /// scoreboard players operation &lt;target> &lt;objective> &lt;operation> &lt;source> &lt;sourceObject>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="objective"></param>
        /// <param name="operation"></param>
        /// <param name="source"></param>
        /// <param name="sourceObject"></param>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Scoreboard(string target, SbObject objective, string operation, string source, SbObject sourceObject)
        {
            this.target = target;
            this.objective = objective;
            if (!Operation.ALL.Contains(operation))
            {
                throw new ArgumentNotMatchException("参数错误: " + operation + "。非法的运算符");
            }
            this.operation = operation;
            this.source = source;
            this.sourceObject = sourceObject;
            this.type = 9;
        }

        /// <summary>
        /// scoreboard players reset &lt;target> [&lt;objective>]
        /// </summary>
        /// <param name="target"></param>
        /// <param name="objective"></param>
        public Scoreboard(string target, SbObject objective = null)
        {
            this.target = target;
            this.objective = objective;
            this.type = 10;
        }

        public override string ToString()
        {
            string re = "#scoreboard qwq";
            switch (type)
            {
                case 0:
                    {
                        re = "scoreboard objectives add " + objective + " " + rule + " " + display;
                        break;
                    }
                case 1:
                    {
                        re = "scoreboard objectives list";
                        break;
                    }
                case 2:
                    {
                        re = "scoreboard objectives modify " + rule + " displayname " + display;
                        break;
                    }
                case 3:
                    {
                        re = "scoreboard objectives modify " + objective + " rendertype " + Tools.getEnumString(hearts_integer);
                        break;
                    }
                case 4:
                    {
                        re = "scoreboard objectives remove " + objective;
                        break;
                    }
                case 5:
                    {
                        re = "scoreboard objectives setdisplay " + displaySlot + " " + objective;
                        break;
                    }
                case 6:
                    {
                        re = "scoreboard players " + Tools.getEnumString(add_remove_set) + " " + target + " " + objective + " " + value;
                        break;
                    }
                case 7:
                    {
                        re = "scoreboard players " + Tools.getEnumString(enable_get) + " " + target + " " + objective;
                        break;
                    }
                case 8:
                    {
                        re = "scoreboard players list " + target;
                        break;
                    }
                case 9:
                    {
                        re = "scoreboard players operation " + target + " " + objective + " " + operation + " " + source + " " + sourceObject;
                        break;
                    }
                case 10:
                    {
                        re = "scoreboard players reset " + target + " " + objective;
                        break;
                    }
            }
            return re;
        }
    }
}
