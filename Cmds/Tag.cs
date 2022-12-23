using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 管理单个实体的记分板标签
    /// <code>
    /// tag &lt;targets> add &lt;name>
    /// tag &lt;targets> list
    /// tag &lt;targets> remove &lt;name>
    /// </code>
    /// </summary>
    public class Tag : Command
    {
        Selector targets;
        ar add_remove;
        string name;
        
        public enum ar
        {
            add, remove
        }

        /// <summary>
        /// tag &lt;targets> (add|remove) &lt;name>
        /// </summary>
        /// <param name="targets"></param>
        /// <param name="add_remove"></param>
        /// <param name="name"></param>
        public Tag(Selector targets, ar add_remove, string name)
        {
            this.targets = targets;
            this.add_remove = add_remove;
            this.name = name;
        }

        /// <summary>
        /// tag &lt;targets> list
        /// </summary>
        /// <param name="targets"></param>
        public Tag(Selector targets)
        {
            this.targets = targets;
        }

        public override string ToString()
        {
            if(name != null)
            {
                return "tag " + targets + " " + Tools.GetEnumString(add_remove) + " " + name;
            }
            else
            {
                return "tag " + targets + " list";
            }
        }
    }
}
