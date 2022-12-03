using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 以指定位置为生成原点，放置地物、拼图、结构或结构模板。
    /// <code>
    /// place feature &lt;feature> [&lt;pos>]
    /// place jigsaw &lt;pool> &lt;target> &lt;max_depth> [&lt;position>]
    /// place structure &lt;structure> [&lt;pos>]
    /// place template &lt;template> [&lt;pos>] [&lt;rotation>] [&lt;mirror>] [&lt;integrity>] [&lt;seed>]
    /// </code>
    /// </summary>
    public class Place : Command
    {
        ID res;
        Pos pos;
        ID target;
        int max_depth;
        Rot rot;
        Mirror mirror;
        float integrity;
        long? seed;
        int type;

        public enum Rot
        {
            _none,
            _clockwise_90,
            _180,
            _counterclockwise_90
        }

        public enum Mirror
        {
            none,
            front_back,
            left_right
        }

        /// <summary>
        /// place feature &lt;feature> [&lt;pos>]
        /// </summary>
        /// <param name="feature">指定要放置的可用地物（包含数据包内的自定义地物）的命名空间ID。</param>
        /// <param name="pos">指定要尝试放置的原点位置。</param>
        public Place(ID feature, Pos pos = null)
        {
            this.res = feature;
            this.pos = pos;
            type = 0;
        }

        /// <summary>
        /// place jigsaw &lt;pool> &lt;target> &lt;max_depth> [&lt;position>]
        /// </summary>
        /// <param name="pool">指定要开始生成结构的模板池。</param>
        /// <param name="target">指定结构从目标池中生成时要对接的拼图方块。</param>
        /// <param name="max_depth">指定放置期间要遍历的拼图对接数最大值。必须为32位整型数值。且必须在1和7（含）之间。</param>
        /// <param name="pos">指定要尝试放置的原点位置。</param>
        public Place(ID pool, ID target, int max_depth, Pos pos = null)
        {
            this.res = pool;
            this.target = target;
            this.max_depth = max_depth;
            if(max_depth < 1)
            {
                max_depth = 1;
                DatapackInfo.log.AddLog(Util.Log.Level.ERROR, max_depth + "必须在1和7（含）之间");
            }
            if (max_depth > 7)
            {
                max_depth = 7;
                DatapackInfo.log.AddLog(Util.Log.Level.ERROR, max_depth + "必须在1和7（含）之间");
            }
            this.pos = pos;
            type = 1;
        }

        /// <summary>
        /// place structure &lt;structure> [&lt;pos>]
        /// </summary>
        /// <param name="structure">指定要生成的结构。</param>
        /// <param name="pos">指定要尝试放置的原点位置。</param>
        /// <param name="o">随便填什么，用于区分structure和feature的命令格式</param>
        public Place(ID structure, Pos pos, object o)
        {
            this.res = structure;
            this.pos = pos;
            type = 2;
        }

        /// <summary>
        /// place template &lt;template> [&lt;pos>] [&lt;rotation>] [&lt;mirror>] [&lt;integrity>] [&lt;seed>]
        /// </summary>
        /// <param name="template">指定要放置的模板（结构文件）。</param>
        /// <param name="pos">指定要尝试放置的原点位置。</param>
        /// <param name="rot">指定放置模板时应当旋转的角度，旋转方向以Y轴俯视角为基准。可用值如下：none（默认值）：不旋转。clockwise_90：顺时针旋转90°。180：旋转180°。counterclockwise_90：逆时针旋转90°。</param>
        /// <param name="mirror">指定放置模板时应当采取的镜像方式。可用值如下：none（默认值）：不镜像。front_back：前后翻转。left_right：左右翻转。</param>
        /// <param name="integrity">指定被放置结构的完整度。必须为单精度浮点数。且必须在0和1（含）之间。默认值为1。</param>
        /// <param name="seed">指定要被用于结构完整度的种子。如不指定，则使用随机种子。</param>
        public Place(ID template, Pos pos = null, Rot rot = Rot._none, Mirror mirror = Mirror.none, float integrity = 1.0f, long? seed = null)
        {
            this.res = template;
            if(pos == null)
            {
                pos = new Pos();
            }
            else
            {
                this.pos = pos;
            }
            this.rot = rot;
            this.mirror = mirror;
            this.integrity = integrity;
            this.seed = seed;
            type = 3;
        }

        public override string ToString()
        {
            string re = "#place喵";
            switch (type)
            {
                case 0:
                    {
                        re = "place feature " + res + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 1:
                    {
                        re = "place jigsaw " + res + " " + target + " " + max_depth + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 2:
                    {
                        re = "place structure " + res + (pos == null ? "" : (" " + pos));
                        break;
                    }
                case 3:
                    {
                        re = "place template " + res + " " + pos + " " + Enum.GetName(typeof(Rot), rot) + " " + Enum.GetName(typeof(Mirror), mirror) + " " + integrity + (seed == null ? "" : (" " + seed.Value));
                        break;
                    }
            }
            return re;
        }
    }
}
