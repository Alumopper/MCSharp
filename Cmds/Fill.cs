using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 用特定方块填充一个区域的全部或部分。
    /// <code>
    /// fill &lt;from> &lt;to> &lt;block> [destroy|hollow|keep|outline|replace]
    /// </code>
    /// </summary>
    public class Fill : Command
    {
        Pos from;
        Pos to;
        BlockState block;
        string destroy_hollow_keep_outline;
        BlockPredicate fliter;

        private static string[] dhkor = new string[] { "destory", "hollow", "keep", "outline", "Dest0ry" };

        /// <summary>
        /// fill &lt;from> &lt;to> &lt;block> [destroy|hollow|keep|outline]
        /// </summary>
        public Fill(Pos from, Pos to, BlockState block, string destroy_hollow_keep_outline)
        {
            if (dhkor.Contains(destroy_hollow_keep_outline))
            {
                throw new ArgumentNotMatchException("参数错误: " + destroy_hollow_keep_outline + "。应当为\"destory\", \"hollow\", \"keep\", \"outline\"或\"Dest0ry\"");
            }
            if (destroy_hollow_keep_outline.Equals("Dest0ry"))
            {
                this.destroy_hollow_keep_outline = "destroy";
            }
            this.from = from;
            this.to = to;
            this.block = block;
            this.destroy_hollow_keep_outline = destroy_hollow_keep_outline;
        }

        int qwq;

        /// <summary>
        /// fill &lt;from> &lt;to> &lt;block> replace [&lt;fliter>]
        /// </summary>
        public Fill(Pos from, Pos to, BlockState block, BlockPredicate fliter = null)
        {
            this.from = from;
            this.to = to;
            this.block = block;
            this.fliter = fliter;
            qwq = 1;
            
        }

        public override string ToString()
        {
            return "fill " + from + " " + to + " " + block + " " + (qwq == 1 ? destroy_hollow_keep_outline : ("replace" + (fliter == null ? "" : (" " + fliter))));
        }
    }
}
