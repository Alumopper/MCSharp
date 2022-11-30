using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 从黑名单上移除对象
    /// <code>
    /// pardon-ip &lt;player>
    /// </code>
    /// </summary>
    public class Pardon_ip : Command
    {
        string ip;

        /// <summary>
        /// pardon-ip &lt;player>
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Pardon_ip(string ip)
        {
            if (!Regex.IsMatch(ip, "((2(5[0-5]|[0-4]\\d))|[0-1]?\\d{1,2})(\\.((2(5[0-5]|[0-4]\\d))|[0-1]?\\d{1,2})){3}"))
            {
                throw new ArgumentNotMatchException("无效的ip地址:" + ip);
            }
            this.ip = ip;
        }

        public override string ToString()
        {
            return "pardon-ip " + ip;
        }
    }
}
