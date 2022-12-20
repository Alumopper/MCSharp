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
    /// 此命令用于管理服务器中白名单。
    /// 服务器的管理员永远能够登录开启白名单验证的服务器，无论他们的名字是不是在白名单上。
    /// <code>
    /// whitelist (add|remove) &lt;targets>
    /// whitelist (list|off|on|reload)
    /// </code>
    /// </summary>
    public class Whitelist : Command
    {
        Entity targets;
        ar add_remove;
        loor list_on_off_reload;

        public enum ar
        {
            add, remove
        }

        public enum loor
        {
            list, off, on, reload
        }

        /// <summary>
        /// whitelist (add|remove) &lt;targets>
        /// </summary>
        /// <param name="targets"></param>
        /// <param name="add_remove"></param>
        public Whitelist(Entity targets, ar add_remove)
        {
            this.targets = targets;
            this.add_remove = add_remove;
        }

        /// <summary>
        /// whitelist (list|off|on|reload)
        /// </summary>
        /// <param name="list_on_off_reload"></param>
        public Whitelist(loor list_on_off_reload)
        {
            this.list_on_off_reload = list_on_off_reload;
        }

        public override string ToString()
        {
            if (targets != null)
            {
                return "whitelist " + Tools.GetEnumString(add_remove) + " " + targets;
            }
            else
            {
                return "whitelist " + Tools.GetEnumString(list_on_off_reload);
            }
        }
    }
}
