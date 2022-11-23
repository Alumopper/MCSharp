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
    /// 给予或移除玩家的进度
    /// <code>
    /// advancement (grant|revoke) &lt;targets&gt; everything
    /// advancement (grant|revoke) &lt;targets&gt; only &lt;advancement&gt; [&lt;criterion&gt;]
    /// advancement (grant|revoke) &lt;targets&gt; (from|through|until) &lt;advancement&gt;
    /// </code>
    /// </summary>
    public class Advancement : Command
    {
        private static string[] gr = new string[]{"grant","revoke"};
        private static string[] eoftu = new string[] { "everything", "only", "from", "through", "until" };
        private static string[] oftu = new string[] {"only","from", "through", "until" };
        private static string[] ftu = new string[] { "from", "through", "until" };

        string grant_revoke;
        Entity target;
        string[] args;

        public Advancement(string grant_revoke, Entity target,params string[] args)
        {
            //检查参数
            if(!gr.Contains(grant_revoke))
            {
                throw new ArgumentNotMatchException("参数错误:\"" + grant_revoke + "\"。应当为\"grant\"或\"revoke\"");
            }
            if (!eoftu.Contains(args[0]))
            {
                throw new ArgumentNotMatchException("参数错误:\"" + args[0] + "\"。应当为\"everything\", \"only\", \"from\", \"through\"或\"until\"");
            }
            if (oftu.Contains(args[0]))
            {
                if (!ID.IsLegal(args[1]))
                {
                    throw new ArgumentNotMatchException("参数错误:\"" + args[1] + "。期望一个命名空间id");
                }
                if (ftu.Contains(args[0]))
                {
                    if(args.Length > 2)
                    {
                        DatapackInfo.log.AddLog(Log.Level.WARN,"过多的参数:\"" + args[2] + "等");
                    }
                }
                else
                {
                    if(args.Length > 3)
                    {
                        DatapackInfo.log.AddLog(Log.Level.WARN,"过多的参数:\"" + args[3] + "等");
                    }
                }
            }
            this.grant_revoke = grant_revoke;
            this.target = target;
            this.args = args;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("advancement " + grant_revoke + " " + target);
            foreach(string arg in args)
            {
                sb.Append(" "+arg);
            }
            return sb.ToString();
        }
    }
}
