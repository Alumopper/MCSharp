using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{

    /// <summary>
    /// 将一条私聊消息发送给一个或多个玩家。
    /// <code>
    /// w &lt;target> &lt;message>
    /// </code>
    /// </summary>
    public class W : Command
    {
        Selector targets;
        string message;

        /// <summary>
        /// w &lt;target> &lt;message>
        /// </summary>
        public W(Selector targets, string message)
        {
            this.targets = targets;
            this.message = message;
        }

        public override string ToString()
        {
            return "w " + targets + " " + message;

        }
    }
}
