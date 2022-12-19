using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 召唤一个实体（生物、弹射物、物品、载具等）。
    /// <code>
    /// summon &lt;entity> [&lt;pos>] [&lt;nbt>]
    /// </code>
    /// </summary>
    public class Summon : Command
    {
        ID entity;
        Pos pos;
        NBT nbt;

        /// <summary>
        /// summon &lt;entity> [&lt;pos>] [&lt;nbt>]
        /// </summary>
        /// <param name="entity">指定实体的名称。</param>
        /// <param name="pos">指定实体的位置。</param>
        /// <param name="nbt">指定实体的NBT数据。</param>
        public Summon(ID entity, Pos pos = null, NBT nbt = null)
        {
            this.entity = entity;
            this.pos = pos;
            this.nbt = nbt;
        }

        public override string ToString()
        {
            return "summon " + entity.ToString() + " " + (pos == null ? "" : pos.ToString()) + " " + (nbt == null ? "" : nbt.ToString());
        }
    }
}
