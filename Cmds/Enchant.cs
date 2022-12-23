using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 为一个实体手持的物品添加魔咒。受限于铁砧机制。
    /// <code>
    /// enchant &lt;target> &lt;id> [&lt;level>]
    /// </code>
    /// </summary>
    public class Enchant : Command
    {
        Selector target;
        ID id;
        int level = 1;

        /// <summary>
        /// enchant &lt;target> &lt;id> [&lt;level>]
        /// </summary>
        public Enchant(Selector target, ID id,int level = 1)
        {
            this.target = target;
            this.id = id;
            if(level < 1)
            {
                level = 1;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "level应当至少为1，但是传入了" + level);
            }
            this.level = level;
        }

        public override string ToString()
        {
            return "enchant " + target + " " + id + " " + level; 
        }
    }
}
