using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 开始或结束调试会话。
    /// <code>
    /// debug (start|stop|function)
    /// </code>
    /// </summary>
    public class Debug : Command
    {
        string arg;
        private static string[] ssf = new string[] { "start", "stop", "function" };

        /// <summary>
        /// debug (start|stop|function)
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Debug(string start_stop_function)
        {
            if (!ssf.Contains(start_stop_function))
            {
                throw new ArgumentNotMatchException("参数错误:" + start_stop_function + "。应当为\"start\", \"stop\"或\"function\"");
            }
            arg = start_stop_function;
        }

        public override string ToString()
        {
            return "debug " + arg;
        }
    }
}
