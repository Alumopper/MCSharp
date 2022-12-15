using MCSharp.Exception;
using System.Linq;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 使用Java FlightRecorder分析数据和某些自定义事件。
    /// <code>
    /// jfr (start|stop)
    /// </code>
    /// </summary>
    public class Jfr : Command
    {
        string start_stop;

        private static string[] ss = new string[] { "start", "stop" };

        /// <summary>
        /// jfr (start|stop)
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Jfr(string start_stop)
        {
            if (!ss.Contains(start_stop))
            {
                throw new ArgumentNotMatchException("参数错误:" + start_stop + "。应当为\"start\"和\"stop\"");
            }
            this.start_stop = start_stop;
        }

        public override string ToString()
        {
            return "jfr " + start_stop;
        }
    }
}
