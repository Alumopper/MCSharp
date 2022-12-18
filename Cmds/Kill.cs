using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 杀死/清除实体（玩家、生物等）
    /// <code>
    /// kill [&lt;targets>]
    /// </code>
    /// </summary>
    public class Kill : Command
    {
        Entity targets;

        /// <summary>
        /// kill [&lt;targets>]
        /// </summary>
        /// <param name="targets"></param>
        public Kill(Entity targets = null)
        {
            this.targets = targets;
        }

        public override string ToString()
        {
            return "kill" + (targets == null ? "" : (" " + targets));
        }
    }
}
