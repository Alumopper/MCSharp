using MCSharp.Type;
using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 控制数据包的加载/卸载。
    /// <code>
    /// datapack disable &lt;name>
    /// datapack enable &lt;name>
    /// datapack enable &lt;name> (first|last)
    /// datapack enable &lt;name> (before|after) &lt;existing>
    /// datapack list [available | enabled]
    /// </code>
    /// </summary>
    public class Datapack : Command
    {
        string arg1;
        string arg2;
        string arg3;
        string arg4;
        int count = 0;
        /// <summary>
        /// <code>
        /// datapack disable &lt;name>
        /// datapack enable &lt;name>
        /// datapack enable &lt;name> (first|last)
        /// datapack enable &lt;name> (before|after) &lt;existing>
        /// datapack list [available | enabled]
        /// </code>
        /// </summary>
        public Datapack(params string[] args)
        {

            if(args.Length >= 2)
            {
                if (args[0].Equals("disable"))
                {
                    if (!ID.IsLegal(args[1]))
                    {
                        throw new ArgumentNotMatchException("非法的命名空间:" + args[1]);
                    }
                    arg1 = args[0];
                    arg2 = args[1];
                    count = 2;
                    if(args.Length > 2)
                    {
                        DatapackInfo.log.AddLog(Util.Log.Level.WARN, "过多的参数:" + args[2] + "等");
                    }
                }else if (args[0].Equals("enable"))
                {
                    if (!ID.IsLegal(args[1]))
                    {
                        throw new ArgumentNotMatchException("非法的命名空间:" + args[1]);
                    }
                    arg1 = args[0];
                    arg2 = args[1];
                    if (args.Length == 3)
                    {
                        if (args[2].Equals("first") || args[2].Equals("last"))
                        {
                            arg3 = args[2];
                        }
                        else
                        {
                            throw new ArgumentNotMatchException("参数错误:" + args[2] + "。应为\"first\"或\"last\"");
                        }
                        count = 3;
                    }else if(args.Length == 4)
                    {
                        if (args[2].Equals("before") || args[2].Equals("after"))
                        {
                            arg3 = args[2];
                        }
                        else
                        {
                            throw new ArgumentNotMatchException("参数错误:" + args[2] + "。应为\"before\"或\"after\"");
                        }
                        if (!ID.IsLegal(args[3]))
                        {
                            throw new ArgumentNotMatchException("非法的命名空间:" + args[3]);
                        }
                        arg4 = args[3];
                        count = 4;
                    }
                }else if (args[0].Equals("list"))
                {
                    arg1 = args[0];
                    if (args[1].Equals("available") || args[1].Equals("enabled"))
                    {
                        arg2 = args[1];
                    }
                    else
                    {
                        throw new ArgumentNotMatchException("参数错误:" + args[1] + "。应为\"available\"或\"enabled\"");
                    }
                    count = 2;
                }
                else
                {
                    throw new ArgumentNotMatchException("参数错误:" + args[0] + "。应为\"disable\", \"enable\"或\"list\"");
                }
            }
            else if(args.Length == 1)
            {
                if (args[0].Equals("list"))
                {
                    arg1 = args[0];
                    count = 1;
                }
                else
                {
                    throw new ArgumentNotMatchException("参数错误:" + args[0] + "。应为\"disable\", \"enable\"或\"list\"");
                }
            }
            else
            {
                throw new ArgumentNotMatchException("参数错误: 至少需要1个参数, 实际得到" + args.Length + "个");
            }
        }

        public override string ToString()
        {
            string re = "#喵喵喵？这里应该是一个datapack命令，如果你看到了这个注释，说明MC#出现了一些问题！";
            switch (count)
            {
                case 1:
                    {
                        re = "datapack " + arg1;
                        break;
                    }
                case 2:
                    {
                        re = "datapack " + arg1 + " " + arg2;
                        break;
                    }
                case 3:
                    {
                        re = "datapack " + arg1 + " " + arg2 + " " + arg3;
                        break;
                    }
                case 4:
                    {
                        re = "datapack " + arg1 + " " + arg2 + " " + arg3 + " " + arg4;
                        break;
                    }  
            }
            return re;
        }
    }
}
