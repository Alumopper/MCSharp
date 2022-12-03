using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 记录并保存性能分析数据。
    /// <code>
    /// perf (start|stop)
    /// </code>
    /// </summary>
    public class Perf : Command
    {
        string start_stop;

        private static string[] ss = { "start", "stop" };

        /// <summary>
        /// perf (start|stop)
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Perf(string start_stop)
        {
            if (!ss.Contains(start_stop))
            {
                throw new ArgumentNotMatchException("参数错误:" + start_stop + "。应当为\"start\"或\"stop\"");
            }
            this.start_stop = start_stop;
        }

        public override string ToString()
        {
            return "perf " + start_stop;
        }
    }
}
