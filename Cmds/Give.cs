using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 给予实体一种指定数量的物品。
    /// <code>
    /// give &lt;target> &lt;item> [&lt;count>]
    /// </code>
    /// </summary>
    public class Give : Command
    {
        Selector target;
        ItemStack item;

        /// <summary>
        /// give &lt;target> &lt;item> [&lt;count>]
        /// </summary>
        /// <param name="item">一个物品堆。物品堆中已经包含count有关信息</param>
        public Give(Selector target, ItemStack item)
        {
            this.target = target;
            this.item = item;
        }

        public override string ToString()
        {
            return "give " + target + " " + item;
        }


    }
}
