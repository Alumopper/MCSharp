using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 向一个或多个玩家发送一条JSON文本消息。
    /// </summary>
    public class Tellraw : Command
    {
        Entity targets;
        JsonText message;

        /// <summary>
        /// tellraw &lt;target> &lt;message>
        /// </summary>
        public Tellraw(Entity targets, JsonText message)
        {
            this.targets = targets;
            this.message = message;
        }

        public override string ToString()
        {
            return "tellraw " + targets + " " + message;
        }
    }
}
