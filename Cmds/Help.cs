using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 获取可用命令列表或单个命令的帮助信息。
    /// <code>
    /// help
    /// help &lt;command>
    /// </code>
    /// </summary>
    public class Help : Command
    {
        string command;

        /// <summary>
        /// help [&lt;command>]
        /// </summary>
        public Help(string command)
        {
            this.command = command;
        }

        public override string ToString()
        {
            return "help" + (command == null ? "" : " " + command);
        }
    }
}
