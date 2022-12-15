using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 给使用命令的实体所在的队伍全体成员发送消息，不在命令方块上执行。
    /// <code>
    /// teammsg &lt;message>
    /// </code>
    /// </summary>
    public class Teammsg : Command
    {
        string message;

        /// <summary>
        /// teammsg &lt;message>
        /// </summary>
        /// <param name="message">指定要发送的消息</param>
        public Teammsg(string message) {
            this.message = message;
        }

        public override string ToString()
        {
            return "teammsg " + message;
        }
    }
}
