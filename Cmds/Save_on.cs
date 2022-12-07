using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 启用服务器的自动保存。
    /// <code>
    /// save-on
    /// </code>
    /// </summary>
    public class Save_on : Command
    {
        public Save_on() { }

        public override string ToString()
        {
            return "save-on";
        }
    }
}
