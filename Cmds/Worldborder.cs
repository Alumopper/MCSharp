using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 此命令控制世界边界。
    /// <code>
    /// worldborder (add|set) &lt;distance> [&lt;time>]
    /// worldborder center &lt;pos>
    /// worldborder get
    /// worldborder damage amount &lt;float:damagePerBlock>
    /// worldborder damage buffer &lt;double:distance>
    /// worldborder warning distance &lt;int:distance>
    /// worldborder warning time &lt;int:time>
    /// </code>
    /// </summary>
    public class Worldborder : Command
    {
        As add_set;
        double distance;
        int time;
        Pos pos;
        float damagePerBlock;
        int type = 0;

        public enum As
        {
            add, set
        }
        public enum dt
        {
            distance, time
        }

        /// <summary>
        /// worldborder (add|set) &lt;distance> [&lt;time>]
        /// </summary>
        /// <param name="add_set"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Worldborder(As add_set, double distance, int time = 0)
        {
            this.add_set = add_set;
            this.distance = distance;
            this.time = time;
            type = 0;
        }

        /// <summary>
        /// worldborder center &lt;pos>
        /// </summary>
        /// <param name="pos"></param>
        public Worldborder(Pos pos)
        {
            this.pos = pos;
            type = 1;
        }

        /// <summary>
        /// worldborder get
        /// </summary>
        public Worldborder()
        {
            type = 2;
        }

        /// <summary>
        /// worldborder damage amount &lt;float:damagePerBlock>
        /// </summary>
        /// <param name="damagePerBlock"></param>
        public Worldborder(float damagePerBlock)
        {
            this.damagePerBlock = damagePerBlock;
            type = 3;
        }

        /// <summary>
        /// worldborder damage buffer &lt;double:distance>
        /// </summary>
        /// <param name="distance"></param>
        public Worldborder(double distance)
        {
            this.distance = distance;
            type = 4;
        }

        /// <summary>
        /// worldborder warning distance &lt;int:distance>
        /// <para></para>
        /// worldborder warning time &lt;int:time>
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="value"></param>
        public Worldborder(dt dt, int value)
        {
            if (dt == dt.distance)
            {
                distance = value;
            }
            else
            {
                time = value;
            }
            type = 5;
        }

        public override string ToString()
        {
            string re = "#worldborder qwq";
            switch (type)
            {
                case 0:
                    re = "worldborder " + (add_set == As.add ? "add " : "set ") + distance + (time == 0 ? "" : " " + time);
                    break;
                case 1:
                    re = "worldborder center " + pos;
                    break;
                case 2:
                    re = "worldborder get";
                    break;
                case 3:
                    re = "worldborder damage amount " + damagePerBlock;
                    break;
                case 4:
                    re = "worldborder damage buffer " + distance;
                    break;
                case 5:
                    re = "worldborder warning " + (time == 0 ? "distance " : "time ") + (time == 0 ? distance : time);
                    break;
            }
            return re;
        }
    }
}
