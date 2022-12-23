using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 使用此命令可以使得处于旁观模式的玩家进入另一个实体的视角。
    /// <code>
    /// spectate &lt;target> [&lt;player>]
    /// spectate
    /// </code>
    /// </summary>
    public class Spectate : Command
    {
        Selector target;
        Selector player;

        /// <summary>
        /// spectate &lt;target> [&lt;player>]
        /// <para>
        /// 让一位玩家旁观另一个目标。
        /// </para>
        /// </summary>
        /// <param name="target">令玩家进入的旁观视角所属的目标。必须为单个实体或玩家。</param>
        /// <param name="player">必须为单个处于旁观模式的玩家。</param>
        public Spectate(Selector target, Selector player = null)
        {
            this.target = target;
            this.player = player;
        }

        /// <summary>
        /// spectate
        /// <para>
        /// 停止旁观实体。
        /// </para>
        /// </summary>
        public Spectate() { }

        public override string ToString()
        {
            if (target == null)
            {
                return "spectate";
            }
            else 
            {
                return "spectate " + target.ToString() + " " + (player == null ? "" : player.ToString());
            }
        }
    }
}
