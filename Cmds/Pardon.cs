using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 从黑名单上移除对象
    /// <code>
    /// pardon &lt;player>
    /// </code>
    /// </summary>
    public class Pardon : Command
    {
        string player;
        UUID uuid;

        /// <summary>
        /// pardon &lt;player>
        /// </summary>
        public Pardon(string player)
        {
            if (!Regex.IsMatch(player, "^[a-zA-Z0-9_]+$"))
            {
                DatapackInfo.log.AddLog(Util.Log.Level.ERROR, "玩家名称只能包含数字字母或下划线");
            }
            this.player = player;
        }

        /// <summary>
        /// pardon &lt;player>
        /// </summary>
        public Pardon(UUID uuid)
        {
            this.uuid = uuid;
        }

        public override string ToString()
        {
            if(uuid == null)
            {
                return "pardon " + player;
            }
            else
            {
                return "pardon " + uuid;
            } 
        }
    }
}
