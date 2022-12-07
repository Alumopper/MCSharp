using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 禁用服务器的自动保存。所有的更改将会暂时进入队列。
    /// <code>
    /// save-off
    /// </code>
    /// </summary>
    public class Save_off : Command
    {
        public Save_off() { }

        public override string ToString()
        {
            return "save-off";
        }
    }
}
