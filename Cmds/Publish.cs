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
    /// 向局域网开放单人游戏世界。
    /// <code>
    /// publish [&lt;allowCommands>] [&lt;gamemode>] [&lt;port>]
    /// </code>
    /// </summary>
    public class Publish : Command
    {
        bool allowCommands;
        Gamemodes gamemode;
        int? port;

        /// <summary>
        /// publish [&lt;allowCommands>] [&lt;gamemode>] [&lt;port>]
        /// </summary>
        /// <param name="allowCommands">是否允许作弊。</param>
        /// <param name="gamemode">新玩家进入世界后的默认游戏模式。</param>
        /// <param name="port">主机所在的端口，介于1024到65535。</param>
        public Publish(bool allowCommands = false, Gamemodes gamemode = Gamemodes.survival, int? port = null)
        {
            this.allowCommands = allowCommands;
            this.gamemode = gamemode;
            if(port < 1024)
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "端口应介于1024和65535之间，实际为:" + port);
            }
            if (port > 65535)
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "端口应介于1024和65535之间，实际为:" + port);
            }
            this.port = port;
        }

        public override string ToString()
        {
            return "publish " + allowCommands + " " + Tools.getEnumString(gamemode) + " " + (port == null ? "" : (" " + port));
        }
    }
}
