using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 把实体（如玩家、生物、物品等）随机传送到区域内地表的某个位置。
    /// <code>
    /// spreadplayers &lt;pos2> &lt;distance> &lt;maxrange> [under maxheight] &lt;considerteam> &lt;target>
    /// </code>
    /// </summary>
    public class Spreadplayers : Command
    {
        Pos2D pos2;
        float distance;
        float maxrange;
        float? maxheight = null;
        bool considerteam;
        Entity target;

        /// <summary>
        /// spreadplayers &lt;pos2> &lt;distance> &lt;maxrange> under &lt;maxheight> &lt;considerteam> &lt;target>
        /// </summary>
        /// <param name="pos2"></param>
        /// <param name="distance"></param>
        /// <param name="maxrange"></param>
        /// <param name="maxheight"></param>
        /// <param name="considerteam"></param>
        /// <param name="target"></param>
        public Spreadplayers(Pos2D pos2, float distance, float maxrange, float maxheight, bool considerteam, Entity target)
        {
            this.pos2 = pos2;
            this.distance = distance;
            this.maxrange = maxrange;
            this.maxheight = maxheight;
            this.considerteam = considerteam;
            this.target = target;
        }

        /// <summary>
        /// spreadplayers &lt;pos2> &lt;distance> &lt;maxrange> &lt;considerteam> &lt;target>
        /// </summary>
        /// <param name="pos2"></param>
        /// <param name="distance"></param>
        /// <param name="maxrange"></param>
        /// <param name="respectTeams"></param>
        /// <param name="target"></param>
        public Spreadplayers(Pos2D pos2, float distance, float maxrange, bool respectTeams, Entity target)
        {
            this.pos2 = pos2;
            this.distance = distance;
            this.maxrange = maxrange;
            this.considerteam = respectTeams;
            this.target = target;
        }

        public override string ToString()
        {
            if (maxheight == null)
                return "spreadplayers " + pos2.ToString() + " " + distance.ToString() + " " + maxrange.ToString() + " " + considerteam.ToString() + " " + target.ToString();
            else
                return "spreadplayers " + pos2.ToString() + " " + distance.ToString() + " " + maxrange.ToString() + " under " + maxheight.ToString() + " " + considerteam.ToString() + " " + target.ToString();
        }
    }
}
