using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 用于创建或修改Boss栏。
    /// <code>
    /// bossbar add &lt;id> &gt;name>
    /// bossbar get &lt;id> (max|players|value|visible)
    /// bossbar list
    /// bossbar remove &lt;id>
    /// bossbar set &lt;id> (color|max|name|players|style|value|visible)
    /// ... color (blue|green|pink|purple|red|white|yellow)
    /// ... max &lt;max>
    /// ... name &lt;name>
    /// ... players [&lt;targets>]
    /// ... style (notched_6|notched_10|notched_12|notched_20|progress)
    /// ... value &lt;value>
    /// ... visible &lt;visible>
    /// </code>
    /// </summary>
    public class Bossbar : Command
    {
        int type;
        ID id;
        JsonText name;
        string max_players_value_visible;
        string color;
        string max_value;
        int x;
        Selector targets;
        string style;
        bool visible;

        private static string[] mpvv = new string[] { "max", "players", "value", "visible" };
        private static string[] mv = new string[] { "max", "value" };

        /// <summary>
        /// bossbar add &lt;id> &gt;name>
        /// </summary>
        /// type - 0
        public Bossbar(ID id, JsonText name)
        {
            this.id = id;
            this.name = name;
            type = 0;
        }

        /// <summary>
        /// bossbar get &lt;id> (max|players|value|visible)
        /// </summary>
        /// type - 1
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Bossbar(ID id, string max_players_value_visible)
        {
            this.id = id;
            if (!mpvv.Contains(max_players_value_visible))
            {
                throw new ArgumentNotMatchException("参数错误:" + max_players_value_visible + "。应当为\"max\", \"players\", \"value\"或\"visible\"");
            }
            this.max_players_value_visible = max_players_value_visible;
            type = 1;
        }

        /// <summary>
        /// bossbar list
        /// </summary>
        /// type - 2
        public Bossbar()
        {
            this.type = 2;
        }

        /// <summary>
        /// bossbar set &lt;id> color (blue|green|pink|purple|red|white|yellow)
        /// </summary>
        /// <param name="set">任意字符串，反正没有用，只是用于区分方法用的</param>
        /// type - 3
        public Bossbar(ID id, Type.Bossbar.Color color)
        {
            this.id = id;
            switch (color)
            {
                case Type.Bossbar.Color.blue:
                    this.color = "blue";
                    break;
                case Type.Bossbar.Color.green:
                    this.color = "green";
                    break;
                case Type.Bossbar.Color.pink:
                    this.color = "pink";
                    break;
                case Type.Bossbar.Color.purple:
                    this.color = "purple";
                    break;
                case Type.Bossbar.Color.red:
                    this.color = "red";
                    break;
                case Type.Bossbar.Color.white:
                    this.color = "white";
                    break;
                case Type.Bossbar.Color.yellow:
                    this.color = "yellow";
                    break;
            }
            this.type = 3;
        }

        /// <summary>
        /// bossbar set &lt;id> (max|value) &lt;x>
        /// </summary>
        /// <param name="set">任意字符串，反正没有用，只是用于区分方法用的</param>
        /// type - 4
        public Bossbar(ID id, string max_value, int x)
        {
            this.id = id;
            if (!mv.Contains(max_value))
            {
                throw new ArgumentNotMatchException("参数错误:" + max_value + "。应当为\"max\"或\"value\"");
            }
            this.max_value = max_value;
            this.x = x;
            this.type = 4;
        }

        /// <summary>
        /// bossbar set &lt;id> name &lt;name>
        /// </summary>
        /// <param name="set">任意字符串，反正没有用，只是用于区分方法用的</param>
        /// type - 5
        public Bossbar(ID id, string set, JsonText name)
        {
            this.id = id;
            this.name = name;
            this.type = 5;
        }

        /// <summary>
        /// bossbar set &lt;id> players [&lt;targets>]
        /// </summary>
        /// type - 6
        /// <param name="targets">若为null，即此参数为无</param>
        public Bossbar(ID id, string set, Selector targets = null)
        {
            this.id = id;
            this.targets = targets;
            this.type = 6;
        }

        /// <summary>
        /// bossbar set &lt;id> style (notched_6|notched_10|notched_12|notched_20|progress)
        /// </summary>
        /// type - 7
        public Bossbar(ID id, Type.Bossbar.Style style)
        {
            this.id = id;
            switch (style)
            {
                case Type.Bossbar.Style.notched_6:
                    this.style = "notched_6";
                    break;
                case Type.Bossbar.Style.notched_10:
                    this.style = "notched_10";
                    break;
                case Type.Bossbar.Style.notched_12:
                    this.style = "notched_12";
                    break;
                case Type.Bossbar.Style.notched_20:
                    this.style = "notched_20";
                    break;
                case Type.Bossbar.Style.progress:
                    this.style = "progress";
                    break;
            }
            this.type = 7;
        }

        /// <summary>
        /// bossbar set &lt;id> visible &lt;visible>
        /// </summary>
        /// type - 8
        public Bossbar(ID id, bool visible)
        {
            this.id = id;
            this.visible = visible;
            this.type = 8;
        }

        /// <summary>
        /// bossbar remove &lt;id>
        /// </summary>
        /// <param name="id"></param>
        public Bossbar(ID id)
        {
            this.id = id;
            type = 9;
        }
        
        public override string ToString()
        {
            string re = "#喵喵喵？这里应该是一个bossbar命令，如果你看到了这个注释，说明MC#出现了一些问题！";
            switch (type)
            {
                case 0:
                    {
                        //bossbar add <id> <name>
                        re = "bossbar add " + id + " " + name;
                        break;
                    }
                case 1:
                    {
                        //bossbar get <id> (max|players|value|visible)
                        re = "bossbar get " + id + " " + max_players_value_visible;
                        break;
                    }
                case 2:
                    {
                        //bossbar list
                        re = "bossbar list";
                        break;
                    }
                case 3:
                    {
                        //bossbar set <id> color (blue|green|pink|purple|red|white|yellow)
                        re = "bossbar set " + id + " color " + color;
                        break;
                    }
                case 4:
                    {
                        //bossbar set <id> (max|value) <x>
                        re = "bossbar set <id> " + max_value + " " + x;
                        break;
                    }
                case 5:
                    {
                        //bossbar set <id> name <name>
                        re = "bossbar set " + id + " name " + name;
                        break;
                    }
                case 6:
                    {
                        //bossbar set <id> players [<targets>]
                        re = "bossbar set " + id + " players" + targets == null ? "" : " " + targets;
                        break;
                    }
                case 7:
                    {
                        //bossbar set <id> style (notched_6|notched_10|notched_12|notched_20|progress)
                        re = "bossbar set " + id + " style " + style;
                        break;
                    }
                case 8:
                    {
                        //bossbar set <id> visible <visible>
                        re = "bossbar set " + id + " visible " + (visible ? "true" : "false");
                        break;
                    }
                case 9:
                    {
                        //bossbar remove <id>
                        re = "bossbar remove " + id;
                        break;
                    }
            }
            return re;
        }
    }
}
