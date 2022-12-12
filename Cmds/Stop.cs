using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 停止服务端。
    /// <code>
    /// stop
    /// </code>
    /// </summary>
    public class Stop : Command
    {
        public Stop() { }

        public override string ToString()
        {
            return "stop";
        }
    }
}
