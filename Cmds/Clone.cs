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
    /// 在指定区域之间复制方块结构
    /// <code>
    /// clone &lt;begin> &lt;end> &lt;destination> [replace|masked] [force|move|normal]
    /// clone &lt;begin> &lt;end> &lt;destination> filtered &lt;filter> [force|move|normal]
    /// </code>
    /// </summary>
    public class Clone : Command
    {
        Pos begin;
        Pos end;
        Pos destination;
        string replace_masked;
        string force_move_normal;
        BlockState filter;

        private static string[] rm = new string[] { "replace", "masked" };
        private static string[] fmn = new string[] { "force", "move", "normal" };

        public Clone(Pos begin, Pos end, Pos destination, string replace_masked, string force_move_normal)
        {
            this.begin = begin;
            this.destination = destination;
            if (!rm.Contains(replace_masked) && replace_masked != null)
            {
                throw new ArgumentNotMatchException("参数错误:" + replace_masked + "。应当为\"replace\"或\"masked\"");
            }
            if(replace_masked == null)
            {
                this.replace_masked = "replace";
            }
            else
            {
                this.replace_masked = replace_masked;
            }
            if (force_move_normal != null && !fmn.Contains(force_move_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_move_normal + "。应当为\"force\", \"move\"或\"normal\"");
            }
            if (force_move_normal == null)
            {
                this.force_move_normal = "normal";
            }
            else
            {
                this.force_move_normal = force_move_normal;
            }
        }

        public Clone(Pos begin, Pos end, Pos destination, BlockState filter , string force_move_normal)
        {
            this.begin = begin;
            this.destination = destination;
            this.filter = filter;
            if (force_move_normal != null && !fmn.Contains(force_move_normal))
            {
                throw new ArgumentNotMatchException("参数错误:" + force_move_normal + "。应当为\"force\", \"move\"或\"normal\"");
            }
            this.force_move_normal = force_move_normal;
        }

        public override string ToString()
        {
            string re = "#喵喵喵？这里应该是一个clone命令，如果你看到了这个注释，说明MC#出现了一些问题！";
            if(replace_masked != null)
            {
                re = "clone " + begin + " " + end + " " + destination + " " + replace_masked + " " + force_move_normal;
            }
            else
            {
                re = "clone " + begin + " " + end + " " + destination + " filtered " + filter + " " + force_move_normal;
            }
            return re;
        }
    }
}
