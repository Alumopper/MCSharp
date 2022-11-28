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
        Entity target;
        ID id;
        int level = 1;

        /// <summary>
        /// enchant &lt;target> &lt;id> [&lt;level>]
        /// </summary>
        public Enchant(Entity target, ID id,int level)
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

        /// <summary>
        /// enchant &lt;target> &lt;id>
        /// </summary>
        public Enchant(Entity target, ID id)
        {
            this.target = target;
            this.id = id;
        }

        public override string ToString()
        {
            return "enchant " + target + " " + id + " " + level; 
        }
    }
}
