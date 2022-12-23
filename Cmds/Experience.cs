using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static MCSharp.Util.Log;

namespace MCSharp.Cmds
{
    /// <summary>
    /// <code>
    /// experience add &lt;targets> &lt;amount> [levels|points]
    /// experience set &lt;targets> &lt;amount> [levels|points]
    /// experience query &lt;targets> (levels|points)
    /// </code>
    /// </summary>
    public class Experience : Command
    {
        string add_set;
        Selector targets;
        int amount;
        string levels_points;
        bool qwq;
        
        public static string[] lp = new string[] { "levels", "points" };
        public static string[] @as = new string[] { "add", "set" };

        /// <summary>
        /// experience (add|set) &lt;targets> &lt;amount> [levels|points]
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Experience(string add_set, Selector targets, int amount, string levels_points)
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
        /// experience query &lt;targets> (levels|points)
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Experience(Selector targets,string levels_points)
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
                return "experience " + add_set + " " + targets + " " + amount + " " + levels_points;
            }
            else
            {
                return "experience query " + targets + " " + levels_points; 
            }
        }
    }
}
