using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 设定难度等级（和平、简单等）。
    /// <code>
    /// difficulty [easy|hard|normal|peaceful]
    /// </code>
    /// </summary>
    public class Difficulty
    {
        string arg;

        private static string[] ehnp = new string[] { "easy", "hard", "normal", "peaceful" };

        /// <summary>
        /// difficulty [easy|hard|normal|peaceful]
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Difficulty(string easy_hard_normal_peaceful)
        {
            if (!ehnp.Contains(easy_hard_normal_peaceful) && easy_hard_normal_peaceful != null)
            {
                throw new ArgumentNotMatchException("参数错误:" + easy_hard_normal_peaceful + "。应当为 \"easy\", \"hard\", \"normal\", \"peaceful\"或null");
            }
            arg = easy_hard_normal_peaceful;
        }

        public override string ToString()
        {
            return "difficulty" + arg == null ? "" : (" " + arg);
        }
    }
}
