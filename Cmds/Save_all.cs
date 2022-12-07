using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 将服务器保存至硬盘。使服务器将所有区块和玩家数据标记为待保存。这些数据会随时间陆续保存进硬盘。
    /// <code>
    /// save-all [flush]
    /// </code>
    /// </summary>
    public class Save_all : Command
    {
        bool flush;

        /// <summary>
        /// save-all [flush]
        /// </summary>
        /// <param name="flush">若为true，则服务器会立即保存所有的区块数据，并造成服务器临时冻结。</param>
        public Save_all(bool flush = false)
        {
            this.flush = flush;
        }

        public override string ToString()
        {
            return "save-all" + (flush ? " flush" : "");
        }
    }
}
