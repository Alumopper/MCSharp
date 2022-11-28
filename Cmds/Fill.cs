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
        string destroy_hollow_keep_outline_replace;
        BlockPredicate fliter;

        private static string[] dhkor = new string[] { "destory", "hollow", "keep", "outline", "replace", "Dest0ry" };

        public Fill(Pos from, Pos to, BlockState block, string destroy_hollow_keep_outline_replace)
        {
            this.from = from;
            this.to = to;
            this.block = block;
            this.destroy_hollow_keep_outline_replace = destroy_hollow_keep_outline_replace;
        }

        public Fill(Pos from, Pos to, BlockState block, BlockPredicate fliter)
        {
            this.from = from;
            this.to = to;
            this.block = block;
            this.fliter = fliter;
        }

        public override string ToString()
        {
            return "fill " + from + " " + to + " " + block + " " + (fliter == null ? destroy_hollow_keep_outline_replace : ("replace " + fliter));
        }
    }
}
