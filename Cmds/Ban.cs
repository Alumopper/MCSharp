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
    /// 将玩家列入黑名单
    /// <code>
    /// ban &lt;playerid or uuid&gt; [&lt;reason…&gt;]
    /// </code>
    /// </summary>
    public class Ban
    {
        string id;
        UUID uuid = null;
        string reason = null;

        /// <summary>
        /// ban &lt;playerid&gt; [&lt;reason…&gt;]
        /// </summary>
        public Ban(string id, params string[] reason)
        {
            this.id = id;
            if(!Regex.IsMatch(id, "[a-zA-Z0-9_]*"))
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "玩家名称应该只包含数字或下划线:" + id);
            }
            if(reason.Length != 0)
            {
                this.reason = reason[0];
                if(reason.Length > 1)
                {
                    DatapackInfo.log.AddLog(Util.Log.Level.WARN, "过多的参数:" + reason[1] + "等");
                }
            }
        }

        /// <summary>
        /// ban &lt;uuid&gt; [&lt;reason…&gt;]
        /// </summary>
        public Ban(UUID uuid, params string[] reason)
        {
            this.uuid = uuid;
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
            if(uuid == null)
            {
                re = "ban " + id;
            }
            else
            {
                re = "ban " + uuid;
            }
            if(reason != null)
            {
                re += " " + reason;
            }
            return re;
        }
    }
}
