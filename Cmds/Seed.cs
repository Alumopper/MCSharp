using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 显示世界种子。
    /// <code>
    /// seed
    /// </code>
    /// </summary>
    public class Seed : Command
    {
        /// <summary>
        /// seed
        /// </summary>
        public Seed() {}

        public override string ToString()
        {
            return "seed";
        }
    }
}
