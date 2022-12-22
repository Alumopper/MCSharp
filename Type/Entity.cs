using MCSharp.Exception;
using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 实体类，一个目标选择器
    /// </summary>
    public class Entity : DataArg
    {
        public enum SelectorType
        {
            p, r, a, e, s
        }

        /// <summary>
        /// 目标选择器的字符串
        /// </summary>
        public string selector;

        /// <summary>
        /// 目标选择器的基础类型
        /// </summary>
        public SelectorType selectorType;
        
        /// <summary>
        /// 目标选择器是否只选择单个目标
        /// </summary>
        public bool isSingle;

        /// <summary>
        /// 目标选择器的参数
        /// </summary>
        public Dictionary<string, object> args;

        /// <summary>
        /// 通过一个目标选择器构建实体
        /// </summary>
        /// <param name="selector"></param>
        public Entity(string selector)
        {
            //目标选择器的格式：@type[argument1=value1,argument2=value2,...]
            //基本格式判断
            if(selector.Length == 2)
            {
                selectorType = GetType(selector[1]);
                args = null;
            }else if(selector.Length > 2)
            {
                selectorType = GetType(selector[1]);
                //解析参数
                args = ParseArgs(selector.Substring(2));
            }
        }

        public static SelectorType GetType(char c)
        {
            //目标选择器的格式：@type[argument1=value1,argument2=value2,...]
            switch (c)
            {
                case 'p':
                    return SelectorType.p;
                case 'a':
                    return SelectorType.a;
                case 'r':
                    return SelectorType.r;
                case 's':
                    return SelectorType.s;
                case 'e':
                    return SelectorType.e;
                default:
                    throw new IllegalFormatException("非法的目标选择器: @" + c);
            }
        }

        public static Dictionary<string, object> ParseArgs(string args)
        {
            //^[@][prase]([\[](([^=,]+[=][!]?([^=,{}]+|[{].+[}]))+([,]([^=,]+[=][!]?([^=,{}]+|[{].+[}])))*)+[\]])?$
            Dictionary<string, object> re = new Dictionary<string, object>();
            if (!args.StartsWith("[") || !args.EndsWith("]"))
            {
                throw new IllegalFormatException("非法的目标选择器参数:"+ args);
            }
            //掐头去尾
            args = args.Substring(1, args.Length - 1);
            int bucket = 0; //大括号
            string p = "";
            foreach(char c in args)
            {
                if (c == '{')
                {
                    //进入括号
                    bucket++;
                    p += c;
                    continue;
                }
                else if (c == '}')
                {
                    //退出括号
                    bucket--;
                    p += c;
                    continue;
                }
                //在括号内
                if(bucket != 0)
                {
                    p += c;
                    continue;
                }
                else if(c == ',' || c == ']')
                {
                    //逗号分隔符，得到键值对
                    string[] kv = p.Split(new char[] { '=' }, 2);
                    switch (kv[0])
                    {
                        case "x":
                            re.Add("x", double.Parse(kv[1]));
                            break;
                        case "y":
                            re.Add("y", double.Parse(kv[1]));
                            break;
                        case "z":
                            re.Add("z", double.Parse(kv[1]));
                            break;
                        case "dx":
                            re.Add("dx", double.Parse(kv[1]));
                            break;
                        case "dy":
                            re.Add("dy", double.Parse(kv[1]));
                            break;
                        case "dz":
                            re.Add("dz", double.Parse(kv[1]));
                            break;
                        case "distance":
                            re.Add("distance", double.Parse(kv[1]));
                            break;
                        case "scores":
                            string[] scores = kv[1].Substring(1, kv[1].Length-2).Split(',');
                            Dictionary<string, IntRange> scs = new Dictionary<string, IntRange>();
                            foreach (string score in scores)
                            {
                                string[] sckv = score.Split('=');
                                scs.Add(sckv[0], new IntRange(sckv[1]));
                            }
                            re.Add("scores", scs);
                            break;
                        case "tag":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add("!tag", kv[1].Substring(1));
                            }
                            else
                            {
                                re.Add("tag", kv[1]);
                            }
                            break;
                        case "team":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add("!team", kv[1].Substring(1));
                            }
                            else
                            {
                                re.Add("team", kv[1]);
                            }
                            break;
                        case "type":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add("!type", new ID(kv[1].Substring(1)));
                            }
                            else
                            {
                                re.Add("type", new ID(kv[1]));
                            }
                            break;
                        case "predicate":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add("!predicate", new ID(kv[1].Substring(1)));
                            }
                            else
                            {
                                re.Add("predicate", new ID(kv[1]));
                            }
                            break;
                        case "x_rotation":
                            re.Add("x_rotation", new IntRange(kv[1]));
                            break;
                        case "y_rotation":
                            re.Add("y_rotation", new IntRange(kv[1]));
                            break;
                        case "nbt":
                            re.Add("nbt", new NBT(kv[1]));
                            break;
                        case "level":
                            re.Add("level", new IntRange(kv[1]));
                            break;
                        case "gamemode":
                            re.Add("gamemode", TGamemode.GetGamemodes(kv[1]));
                            break;
                        case "advancements":
                            //TODO:需要确认，进度条件可不可以塞多个条件并列
                            string[] kv2 = kv[1].Substring(1, kv[1].Length - 2).Split(new char[] {'='},2);
                            KeyValuePair<ID, object> qwq;
                            if (Regex.IsMatch(kv2[1], "^[{][0-9a-z_]+[=](true|false)[}]$"))
                            {
                                //条件
                                string[] kv3 = kv2[1].Substring(1, kv[1].Length - 2).Split(new char[] { '=' }, 2);
                                KeyValuePair<string, bool> pwp = new KeyValuePair<string, bool>(kv3[0], bool.Parse(kv3[1]));
                                qwq = new KeyValuePair<ID, object>(new ID(kv2[0]), pwp);
                            }
                            else
                            {
                                qwq = new KeyValuePair<ID, object>(new ID(kv2[0]), bool.Parse(kv2[1]));
                            }
                            re.Add("advancements", qwq);
                            break;
                        case "limit":
                            re.Add("limit", int.Parse(kv[1]));
                            break;
                        case "sort":
                            //TODO:sort后面的字符串不是自由写的但是我现在好想睡觉阿巴阿巴阿巴阿巴阿巴阿巴阿巴阿巴Zzzzzzz（狐狐瘫
                            re.Add("sort", kv[1]);
                            break;
                    }                    
                }
                p += c;
            }
            if(bucket != 0)
            {
                throw new BracketsNotMatchException("括号不匹配: " + args);
            }
            return re;
        }


        public override string ToString()
        {
            return selector;
        }
    }
}
