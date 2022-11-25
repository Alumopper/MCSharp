using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 把一个IP地址加入黑名单
    /// <code>
    /// banip &lt;playerid or ip&gt; [&lt;reason…&gt;]
    /// </code>
    /// </summary>
    public class Ban_ip : Command
    {
        string id = null;
        string ip = null;
        string reason = null;

        /// <summary>
        /// banip &lt;playerid or ip&gt; [&lt;reason…&gt;]
        /// </summary>
        public Ban_ip(string id_ip, params string[] reason)
        {
            if (Regex.IsMatch(id, "((2(5[0-5]|[0-4]\\d))|[0-1]?\\d{1,2})(\\.((2(5[0-5]|[0-4]\\d))|[0-1]?\\d{1,2})){3}"))
            {
                ip = id_ip;
            }
            else
            {
                this.id = id_ip;
                if (!Regex.IsMatch(id_ip, "[a-zA-Z0-9_]*"))
                {
                    DatapackInfo.log.AddLog(Util.Log.Level.WARN, "玩家名称应该只包含数字或下划线:" + id);
                }
            }
            if (reason.Length != 0)
            {
                this.reason = reason[0];
                if (reason.Length > 1)
                {
                    DatapackInfo.log.AddLog(Util.Log.Level.WARN, "过多的参数:" + reason[1] + "等");
                }
            }
        }

        public override string ToString()
        {
            string re;
            if (ip == null)
            {
                re = "ban " + id;
            }
            else
            {
                re = "ban " + ip;
            }
            if (reason != null)
            {
                re += " " + reason;
            }
            return re;
        }
    }
}
