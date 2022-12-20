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
    /// 设置新玩家进入服务器时默认的游戏模式（生存、创造等）。
    /// <code>
    /// defaultgamemode &lt;mode>
    /// </code>
    /// </summary>
    public class Defaultgamemode : Command
    {
        Gamemodes mode;

        /// <summary>
        /// defaultgamemode &lt;mode>
        /// </summary>
        /// <param name="gamemode"></param>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Defaultgamemode(Gamemodes gamemode)
        {
            mode = gamemode;
        }

        public override string ToString()
        {
            return "defaultgamemode " + Tools.GetEnumString(mode);
        }
    }
}
