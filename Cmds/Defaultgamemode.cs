using MCSharp.Exception;
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
        string arg;
        private static string[] scap = new string[] { "survival", "creative", "adventure", "spectator" };

        /// <summary>
        /// defaultgamemode &lt;mode>
        /// </summary>
        /// <param name="survival_creative_adventure_spectator"></param>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Defaultgamemode(string survival_creative_adventure_spectator)
        {
            if (!scap.Contains(arg))
            {
                throw new ArgumentNotMatchException("参数错误:" + survival_creative_adventure_spectator + "。应当为\"survival\", \"creative\", \"adventure\"或\"spectator\"");
            }
            arg = survival_creative_adventure_spectator;
        }

        public override string ToString()
        {
            return "defaultgamemode " + arg;
        }
    }
}
