using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 给予一位玩家管理员身份。
    /// <code>
    /// op &lt;player>
    /// </code>
    /// </summary>
    public class Op : Command
    {
        Entity player;

        /// <summary>
        /// op &lt;player>
        /// </summary>
        public Op(Entity player)
        {
            this.player = player;
        }

        public override string ToString()
        {
            return "op " + player;
        }
    }
}
