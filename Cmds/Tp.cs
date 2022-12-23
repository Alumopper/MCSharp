using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 传送实体（玩家、生物等）到指定的地点，并修改其旋转角度。
    /// 不像大多数只能影响已经生成的区块的命令，/tp。若被传送的目标是玩家，则传送后玩家所在的区块及附近的区块会自动开始生成。
    /// <code>
    /// tp &lt;destination>
    /// tp &lt;targets> &lt;destination>
    /// tp &lt;location>
    /// tp &lt;targets> &lt;location>
    /// tp &lt;targets> &lt;location> &lt;rotation>
    /// tp &lt;targets> &lt;location> facing &lt;facingLocation>
    /// tp &lt;targets> &lt;location> facing entity &lt;facingEntity> [&lt;facingAnchor>]
    /// </code>
    /// </summary>
    public class Tp : Command
    {
        Selector targets;
        Pos location;
        Selector destination;
        Rotation rotation;
        Pos facingLocation;
        Selector facingEntity;
        ef facingAnchor;

        public enum ef
        {
            eyes, feet
        }

        /// <summary>
        /// tp &lt;destination>
        /// </summary>
        /// <param name="destination"></param>
        public Tp(Selector destination)
        {
            this.destination = destination;
        }

        /// <summary>
        /// tp &lt;targets> &lt;destination>
        /// </summary>
        public Tp(Selector targets, Selector destination)
        {
            this.targets = targets;
            this.destination = destination;
        }

        /// <summary>
        /// tp &lt;location>
        /// </summary>
        public Tp(Pos location)
        {
            this.location = location;
        }

        /// <summary>
        /// tp &lt;targets> &lt;location>
        /// tp &lt;targets> &lt;location> &lt;rotation>
        /// </summary>
        public Tp(Selector targets, Pos location, Rotation rotation = null)
        {
            this.targets = targets;
            this.location = location;
            this.rotation = rotation;
        }

        /// <summary>
        /// tp &lt;targets> &lt;location> facing &lt;facingLocation>
        /// </summary>
        public Tp(Selector targets, Pos location, Pos facingLocation)
        {
            this.targets = targets;
            this.location = location;
            this.facingLocation = facingLocation;
        }

        /// <summary>
        /// tp &lt;targets> &lt;location> facing entity &lt;facingEntity> [&lt;facingAnchor>]
        /// </summary>
        public Tp(Selector targets, Pos location, Selector facingEntity, ef eyes_feet = ef.eyes)
        {
            this.targets = targets;
            this.location = location;
            this.facingEntity = facingEntity;
            this.facingAnchor = eyes_feet;
        }

        public override string ToString()
        {
            if (targets == null)
            {
                if (destination != null)
                {
                    return "tp " + destination;
                }
                else
                {
                    return "tp " + location;
                }
            }
            else
            {
                if (destination != null)
                {
                    return "tp " + targets + " " + destination;
                }
                else
                {
                    if (rotation != null)
                    {
                        return "tp " + targets + " " + location + " " + rotation;
                    }
                    else if (facingLocation != null)
                    {
                        return "tp " + targets + " " + location + " facing " + facingLocation;
                    }
                    else if (facingEntity != null)
                    {
                        return "tp " + targets + " " + location + " facing entity " + facingEntity + " " + Tools.GetEnumString(facingAnchor);
                    }
                    else
                    {
                        return "tp " + targets + " " + location;
                    }
                }
            }
        }
    }
}
