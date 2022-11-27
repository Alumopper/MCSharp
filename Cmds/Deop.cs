using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 撤销玩家的管理员身份。
    /// <code>
    /// deop &lt;player>
    /// </code>
    /// </summary>
    public class Deop : Command
    {
        string player;

        /// <summary>
        /// deop &lt;player>
        /// </summary>
        /// <param name="player"></param>
        public Deop(string player)
        {
            if (!Regex.IsMatch(player, "^[a-zA-Z0-9_]+$"))
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "非法的玩家名:" + player);
            }
            this.player = player;
        }

        public override string ToString()
        {
            return "deop " + player;
        }
    }
}
