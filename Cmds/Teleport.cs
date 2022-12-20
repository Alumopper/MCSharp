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
    /// 不像大多数只能影响已经生成的区块的命令，/teleport可以将实体传送到尚未生成的区块中。若被传送的目标是玩家，则传送后玩家所在的区块及附近的区块会自动开始生成。
    /// <code>
    /// teleport &lt;destination>
    /// teleport &lt;targets> &lt;destination>
    /// teleport &lt;location>
    /// teleport &lt;targets> &lt;location>
    /// teleport &lt;targets> &lt;location> &lt;rotation>
    /// teleport &lt;targets> &lt;location> facing &lt;facingLocation>
    /// teleport &lt;targets> &lt;location> facing entity &lt;facingEntity> [&lt;facingAnchor>]
    /// </code>
    /// </summary>
    public class Teleport : Command
    {
        Entity targets;
        Pos location;
        Entity destination;
        Rotation rotation;
        Pos facingLocation;
        Entity facingEntity;
        ef facingAnchor;

        public enum ef
        {
            eyes, feet
        }

        /// <summary>
        /// teleport &lt;destination>
        /// </summary>
        /// <param name="destination"></param>
        public Teleport(Entity destination)
        {
            this.destination = destination;
        }

        /// <summary>
        /// teleport &lt;targets> &lt;destination>
        /// </summary>
        public Teleport(Entity targets, Entity destination)
        {
            this.targets = targets;
            this.destination = destination;
        }

        /// <summary>
        /// teleport &lt;location>
        /// </summary>
        public Teleport(Pos location)
        {
            this.location = location;
        }

        /// <summary>
        /// teleport &lt;targets> &lt;location>
        /// teleport &lt;targets> &lt;location> &lt;rotation>
        /// </summary>
        public Teleport(Entity targets, Pos location, Rotation rotation = null)
        {
            this.targets = targets;
            this.location = location;
            this.rotation = rotation;
        }

        /// <summary>
        /// teleport &lt;targets> &lt;location> facing &lt;facingLocation>
        /// </summary>
        public Teleport(Entity targets, Pos location, Pos facingLocation)
        {
            this.targets = targets;
            this.location = location;
            this.facingLocation = facingLocation;
        }

        /// <summary>
        /// teleport &lt;targets> &lt;location> facing entity &lt;facingEntity> [&lt;facingAnchor>]
        /// </summary>
        public Teleport(Entity targets, Pos location, Entity facingEntity, ef eyes_feet = ef.eyes)
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
                    return "teleport " + destination;
                }
                else
                {
                    return "teleport " + location;
                }
            }
            else
            {
                if (destination != null)
                {
                    return "teleport " + targets + " " + destination;
                }
                else
                {
                    if (rotation != null)
                    {
                        return "teleport " + targets + " " + location + " " + rotation;
                    }
                    else if (facingLocation != null)
                    {
                        return "teleport " + targets + " " + location + " facing " + facingLocation;
                    }
                    else if (facingEntity != null)
                    {
                        return "teleport " + targets + " " + location + " facing entity " + facingEntity + " " + Tools.GetEnumString(facingAnchor);
                    }
                    else
                    {
                        return "teleport " + targets + " " + location;
                    }
                }
            }
        }
    }
}
