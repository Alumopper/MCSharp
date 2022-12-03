using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 在指定位置显示粒子效果。
    /// <code>
    /// particle &lt;name> [&lt;pos>]
    /// particle &lt;name> &lt;pos> &lt;delta> &lt;speed> &lt;count> [force|normal] [&lt;viewers>]
    /// </code>
    /// </summary>
    public class Particle : Command
    {
        ID name;
        Pos pos;
        Vector3<int> delta;
        float speed;
        int count;
        string force_normal;
        Entity viewers;

        Color dust;
        float size;
        Color trans;
        BlockState block;
        int second;
        ItemStack item;

        byte type;

        private static string[] fn = { "normal", "force" };

        /// <summary>
        /// particle &lt;name> [&lt;pos>]
        /// </summary>
        /// type 0
        public Particle(ID name, Pos pos = null)
        {
            this.name = name;
            this.pos = pos;
            type = 0;
        }

        /// <summary>
        /// particle &lt;name> &lt;pos> &lt;delta> &lt;speed> &lt;count> [force|normal] [&lt;viewers>]
        /// </summary>
        /// type 1
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Particle(ID name, Pos pos, Vector3<int> delta, float speed, int count, string force_normal = "normal", Entity viewers = null)
        {
            this.name = name;
            this.pos = pos;
            this.delta = delta;
            this.speed = speed;
            this.count = count;
            if (!fn.Contains(force_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"normal\"或\"force\"");
            }
            this.force_normal = force_normal;
            this.viewers = viewers;
            type = 1;
        }

        /// <summary>
        /// particle &lt;name> &lt;vec3:color> [&lt;pos>]
        /// </summary>
        /// type 2
        public Particle(Color dust, Pos pos = null)
        {
            this.name = new ID("minecraft:dust");
            this.pos = pos;
            this.dust = dust;
            type = 2;
        }

        /// <summary>
        /// particle &lt;name> &lt;vec3:color> &lt;pos> &lt;delta> &lt;speed> &lt;count> [force|normal] [&lt;viewers>]
        /// </summary>
        /// type 3
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Particle(Color dust, Pos pos, Vector3<int> delta, float speed, int count, string force_normal = "normal", Entity viewers = null)
        {
            this.name = new ID("minecraft:dust");
            this.dust = dust;
            this.pos = pos;
            this.delta = delta;
            this.speed = speed;
            this.count = count;
            if (!fn.Contains(force_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"normal\"或\"force\"");
            }
            this.force_normal = force_normal;
            this.viewers = viewers;
            type = 3;
        }

        /// <summary>
        /// particle &lt;name> &lt;vec3:color> &lt;size> &lt;transcolor> [&lt;pos>]
        /// </summary>
        /// type 4
        public Particle(Color dust, float size, Color trans , Pos pos = null)
        {
            this.name = new ID("minecraft:dust_color_transition");
            this.pos = pos;
            this.dust = dust;
            this.size = size;
            this.trans = trans;
            type = 4;
        }

        /// <summary>
        /// particle &lt;name> &lt;vec3:color> &lt;size> &lt;transcolor> &lt;pos> &lt;delta> &lt;speed> &lt;count> [force|normal] [&lt;viewers>]
        /// </summary>
        /// type 5
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Particle(Color dust, float size, Color trans, Pos pos, Vector3<int> delta, float speed, int count, string force_normal = "normal", Entity viewers = null)
        {
            this.name = new ID("minecraft:dust_color_transition");
            this.dust = dust;
            this.size = size;
            this.trans = trans;
            this.pos = pos;
            this.delta = delta;
            this.speed = speed;
            this.count = count;
            if (!fn.Contains(force_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"normal\"或\"force\"");
            }
            this.force_normal = force_normal;
            this.viewers = viewers;
            type = 5;
        }

        /// <summary>
        /// particle &lt;name:(block|falling_dust)> &lt;block> [&lt;pos>]
        /// </summary>
        /// type 6
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Particle(ID name,BlockState block, Pos pos = null)
        {
            this.name = name;
            if(!(name.id.Equals("minecraft:block") || name.id.Equals("minecraft:falling_dust")))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"minecraft:block\"或\"minecraft:falling_dust\"");
            }
            this.block = block;
            this.pos = pos;
            type = 6;
        }

        /// <summary>
        /// particle &lt;name> &lt;name:(block|falling_dust)> &lt;block> &lt;pos> &lt;delta> &lt;speed> &lt;count> [force|normal] [&lt;viewers>]
        /// </summary>
        /// type 7
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Particle(ID name, BlockState block, Pos pos, Vector3<int> delta, float speed, int count, string force_normal = "normal", Entity viewers = null)
        {
            this.name = name;
            if (!(name.id.Equals("minecraft:block") || name.id.Equals("minecraft:falling_dust")))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"minecraft:block\"或\"minecraft:falling_dust\"");
            }
            this.block = block;
            this.pos = pos;
            this.delta = delta;
            this.speed = speed;
            this.count = count;
            if (!fn.Contains(force_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"normal\"或\"force\"");
            }
            this.force_normal = force_normal;
            this.viewers = viewers;
            type = 7;
        }

        /// <summary>
        /// particle &lt;name> &lt;itme> [&lt;pos>]
        /// </summary>
        /// type 8
        public Particle(ItemStack item, Pos pos = null)
        {
            this.name = new ID("minecraft:item");
            this.item = item;
            this.pos = pos;
            type = 8;
        }

        /// <summary>
        /// particle &lt;name> &lt;itme> &lt;pos> &lt;delta> &lt;speed> &lt;count> [force|normal] [&lt;viewers>]
        /// </summary>
        /// type 9
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Particle(ItemStack item, Pos pos, Vector3<int> delta, float speed, int count, string force_normal = "normal", Entity viewers = null)
        {
            this.name = new ID("minecraft:item");
            this.item = item;
            this.pos = pos;
            this.delta = delta;
            this.speed = speed;
            this.count = count;
            if (!fn.Contains(force_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_normal + "应当为\"normal\"或\"force\"");
            }
            this.force_normal = force_normal;
            this.viewers = viewers;
            type = 9;
        }

        public override string ToString()
        {
            string re = "#这里是particle喵";
            switch (type)
            {
                case 0:
                    {
                        re = "particle " + name + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 1:
                    {
                        re = "particle " + name + " " + pos + " " + delta + " " + speed + " " + count + " " + force_normal + (viewers == null ? "" : " " + viewers);
                        break;
                    }
                case 2:
                    {
                        re = "particle " + name + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 3:
                    {
                        re = "particle " + name + " " + dust + " " + pos + " " + delta + " " + speed + " " + count + " " + force_normal + (viewers == null ? "" : " " + viewers);
                        break;
                    }
                case 4:
                    {
                        re = "particle " + name + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 5:
                    {
                        re = "particle " + name + " " + dust + " " + size + " " + trans + " " + pos + " " + delta + " " + speed + " " + count + " " + force_normal + (viewers == null ? "" : " " + viewers);
                        break;
                    }
                case 6:
                    {
                        re = "particle " + name + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 7:
                    {
                        re = "particle " + name + " " + block + " " + pos + " " + delta + " " + speed + " " + count + " " + force_normal + (viewers == null ? "" : " " + viewers);
                        break;
                    }
                case 8:
                    {
                        re = "particle " + name + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 9:
                    {
                        re = "particle " + name + " " + item + " " + pos + " " + delta + " " + speed + " " + count + " " + force_normal + (viewers == null ? "" : " " + viewers);
                        break;
                    }
            }
            return re;
        }
    }
}
