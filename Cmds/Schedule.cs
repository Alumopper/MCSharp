using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 在Java版中，在经过指定的时间后执行函数。
    /// <code>
    /// schedule function &lt;function> &lt;time> [append|replace]
    /// schedule clear &lt;function>
    /// </code>
    /// </summary>
    public class Schedule : Command
    {

        ID function;
        string time;
        ar append_replace;

        public enum ar
        {
            append,replace
        }

        /// <summary>
        /// schedule function &lt;function> &lt;time> [append|replace]
        /// </summary>
        /// <param name="function">有效的函数名称或有效的标签名称</param>
        /// <param name="time">指定等待的时间。时间可以是Minecraft天、现实秒或刻（默认为刻）。格式是非负整数加上可选的字符d、s或t。</param>
        /// <param name="append_replace">指定是否取代还在等待执行的函数或指定标签里的函数。</param>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Schedule(ID function, string time, ar append_replace)
        {
            this.function = function;
            if (!Regex.IsMatch(time, "^[0-9]+[dst]?$"))
            {
                throw new ArgumentNotMatchException("非法的时间参数: " + time);
            }
            this.time = time;
            this.append_replace = append_replace;
        }

        /// <summary>
        /// schedule clear &lt;function>
        /// </summary>
        /// <param name="function">有效的函数名称或有效的标签名称</param>
        public Schedule(ID function)
        {
            this.function = function;
        }

        public override string ToString()
        {
            if(time == null)
            {
                return "schedule clear " + function;
            }
            else
            {
                return "schedule function " + function + " " + time + " " + Tools.getEnumString(append_replace);
            }
        }
    }
}
