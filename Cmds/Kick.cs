using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 将一位玩家踢出服务器。
    /// kick &lt;player> [reason]
    /// </summary>
    public class Kick : Command
    {
        string player;
        string reason;
        /// <summary>
        /// <code>
        /// kick &lt;player> [reason]
        /// </code>
        /// </summary>
        public Kick(string player, string reason = "")
        {
            this.player = player;
            this.reason = reason;
        }

        public override string ToString()
        {
            return "kick " + player + " " + reason;
        }
    }
}
