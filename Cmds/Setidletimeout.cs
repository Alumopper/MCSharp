using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 设置踢出空闲不动玩家的时间。
    /// <code>
    /// setidletimeout &lt;空闲分钟数>
    /// </code>
    /// </summary>
    public class Setidletimeout : Command
    {
        int timeout;

        /// <summary>
        /// setidletimeout &lt;空闲分钟数>
        /// </summary>
        /// <param name="timeout"></param>
        public Setidletimeout(int timeout)
        {
            this.timeout = timeout;
        }

        public override string ToString()
        {
            return "setidletimeout " + timeout;
        }
    }
}
