using MCSharp.Exception;
using MCSharp.Type;
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
    /// 设置玩家的游戏模式
    /// gamemode (adventure|creative|spectator|survival) [&lt;target>]
    /// </summary>
    public class Gamemode : Command
    {
        Gamemodes mode;
        Entity target;

        /// <summary>
        /// gamemode (adventure|creative|spectator|survival) [&lt;target>]
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Gamemode(Gamemodes gamemode, Entity target = null)
        {
            mode = gamemode;
            this.target = target;
        }

        public override string ToString()
        {
            return "gamemode " + Tools.getEnumString(mode) + (target == null ? "" : " " + target ) ;
        }
    }
}
