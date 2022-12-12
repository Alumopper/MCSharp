using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 为特定玩家设置出生点，可在任意维度使用。
    /// <code>
    /// spawnpoint [&lt;player>] [&lt;pos>] [&lt;angle>]
    /// </code>
    /// </summary>
    public class Spawnpoint : Command
    {
        Entity player;
        Pos pos;
        Rotation angle;

        /// <summary>
        /// spawnpoint [&lt;player>] [&lt;pos>] [&lt;angle>]
        /// </summary>
        /// <param name="player">指定玩家的名称。</param>
        /// <param name="pos">指定出生点的位置。</param>
        /// <param name="angle">指定出生点的朝向。</param>
        public Spawnpoint(Entity player = null, Pos pos = null, Rotation angle = null)
        {
            this.player = player;
            this.pos = pos;
            this.angle = angle;
        }

        public override string ToString()
        {
            return "spawnpoint " + (player == null ? "" : player.ToString()) + " " + (pos == null ? "" : pos.ToString()) + " " + (angle == null ? "" : angle.ToString());
        }
    }
}
