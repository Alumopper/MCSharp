using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 显示服务器的黑名单
    /// <code>
    /// banlist ips
    /// banlist players
    /// </code>
    /// </summary>
    public class Banlist : Command
    {
        string a;

        private string[] ip = new string[] { "ips", "players" };

        /// <summary>
        /// banlist (ips|players)
        /// </summary>
        public Banlist(string ips_players)
        {
            if (!ip.Contains(ips_players))
            {
                throw new ArgumentNotMatchException("参数错误:" + ips_players + "应当为\"ips\"或\"players\"");
            }
            a = ips_players;
        }

        public override string ToString()
        {
            return "banlist " + a;
        }
    }
}
