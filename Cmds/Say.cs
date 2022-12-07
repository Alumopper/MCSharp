using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 通过聊天框向多个玩家发送消息。
    /// <code>
    /// say &lt;message>
    /// </code>
    /// </summary>
    public class Say : Command
    {
        private string text;

        /// <summary>
        /// say &lt;message>
        /// </summary>
        /// <param name="text"></param>
        public Say(string text)
        {
            this.text = text;
        }

        public override string ToString()
        {
            return "say " + text;
        }
    }
}
