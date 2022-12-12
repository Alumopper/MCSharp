using MCSharp.Type;
using MCSharp.Type.CommandArg;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 将指定位置的方块更改为另一个方块。
    /// <code>
    /// setblock &lt;pos> &lt;block> [destroy|keep|replace]
    /// </code>
    /// </summary>
    public class SetBlock
    {
        Pos pos;
        BlockState block;
        dkr destroy_keep_replace;

        public enum dkr { 
            destory,keep,replace
        }

        /// <summary>
        /// setblock &lt;pos> &lt;block> [destroy|keep|replace]
        /// </summary>
        /// <param name="pos">指定要被更改方块的位置。</param>
        /// <param name="block">指定更改后的新方块。</param>
        /// <param name="destroy_keep_replace">指定方块更改的处理方式，必须为以下其中之一：destroy — 原方块正常掉落物品（类似于被一个玩家破坏），并播放方块被破坏的音效。keep — 仅当原方块是空气方块时才进行更改。replace — 原方块不掉落物品，且不播放方块被破坏的音效。</param>
        public SetBlock(Pos pos, BlockState block, dkr destroy_keep_replace = dkr.replace)
        {
            this.pos = pos;
            this.block = block;
            this.destroy_keep_replace = destroy_keep_replace;
        }

        public override string ToString()
        {
            return "setblock " + pos + " " + block + " " + Tools.getEnumString(destroy_keep_replace);
        }

    }
}
