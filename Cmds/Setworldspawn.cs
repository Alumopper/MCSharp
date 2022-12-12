using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 设置世界出生点。
    /// <code>
    /// setworldspawn [&lt;pos>] [&lt;angle>]
    /// </code>
    /// </summary>
    public class Setworldspawn : Command
    {
        Pos pos;
        Rotation angle;

        /// <summary>
        /// setworldspawn [&lt;pos>] [&lt;angle>]
        /// </summary>
        /// <param name="pos">指定出生点的位置。</param>
        /// <param name="angle">指定出生点的朝向。</param>
        public Setworldspawn(Pos pos = null, Rotation angle = null)
        {
            this.pos = pos;
            this.angle = angle;
        }

        public override string ToString()
        {
            return "setworldspawn " + (pos == null ? "" : pos.ToString()) + " " + (angle == null ? "" : angle.ToString());
        }
    }
}
