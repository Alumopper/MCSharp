using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 显示一条关于你自己的信息。
    /// <code>
    /// me &lt;action>
    /// </code>
    /// </summary>
    public class Me : Command
    {
        string msg;

        /// <summary>
        /// me &lt;action>
        /// </summary>
        /// <param name="msg"></param>
        public Me(string msg)
        {
            this.msg = msg;
        }

        public override string ToString()
        {
            return "me " + msg;
        }
    }
}
