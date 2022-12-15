using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{

    /// <summary>
    /// <code>
    /// xp add &lt;targets> &lt;amount> [levels|points]
    /// xp set &lt;targets> &lt;amount> [levels|points]
    /// xp query &lt;targets> (levels|points)
    /// </code>
    /// </summary>
    public class Xp : Command
    {
        string add_set;
        Entity targets;
        int amount;
        string levels_points;
        bool qwq;

        public static string[] lp = new string[] { "levels", "points" };
        public static string[] @as = new string[] { "add", "set" };

        /// <summary>
        /// xp (add|set) &lt;targets> &lt;amount> [levels|points]
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Xp(string add_set, Entity targets, int amount, string levels_points)
        {
            if (!@as.Contains(add_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + add_set + "。应当为\"add\"或\"set\"");
            }
            qwq = true;
            this.targets = targets;
            this.amount = amount;
            if (!lp.Contains(levels_points))
            {
                throw new ArgumentNotMatchException("参数错误:" + levels_points + "。应当为\"levels\"或\"points\"");
            }
            this.levels_points = levels_points;
        }

        /// <summary>
        /// xp query &lt;targets> (levels|points)
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Xp(Entity targets, string levels_points)
        {
            qwq = false;
            this.targets = targets;
            if (!lp.Contains(levels_points))
            {
                throw new ArgumentNotMatchException("参数错误:" + levels_points + "。应当为\"levels\"或\"points\"");
            }
            this.levels_points = levels_points;
        }

        public override string ToString()
        {
            if (qwq)
            {
                return "xp " + add_set + " " + targets + " " + amount + " " + levels_points;
            }
            else
            {
                return "xp query " + targets + " " + levels_points;
            }
        }
    }
}
