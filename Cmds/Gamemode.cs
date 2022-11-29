using MCSharp.Exception;
using MCSharp.Type;
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
        string mode;
        Entity target;

        private static string[] scap = new string[] { "survival", "creative", "adventure", "spectator" };

        /// <summary>
        /// gamemode (adventure|creative|spectator|survival) [&lt;target>]
        /// </summary
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Gamemode(string survival_creative_adventure_spectator, Entity target)
        {
            if (!scap.Contains(survival_creative_adventure_spectator))
            {
                throw new ArgumentNotMatchException("参数错误:" + survival_creative_adventure_spectator + "。应当为\"survival\", \"creative\", \"adventure\"或\"spectator\"");
            }
            mode = survival_creative_adventure_spectator;
            this.target = target;
        }

        public override string ToString()
        {
            return "gamemode " + mode + (target == null ? "" : " " + target ) ;
        }
    }
}
