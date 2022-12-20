using MCSharp.Exception;
using MCSharp.Type.CommandArg;
using MCSharp.Util;
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
    public class Difficulty : Command
    {
        Difficulties? difficulties;

        /// <summary>
        /// difficulty [easy|hard|normal|peaceful]
        /// </summary>
        public Difficulty(Difficulties? difficulties = null)
        {
            this.difficulties = difficulties;
        }

        public override string ToString()
        {
            return "difficulty" + (difficulties == null ? "" : (" " + Tools.GetEnumString(difficulties)));
        }
    }
}
