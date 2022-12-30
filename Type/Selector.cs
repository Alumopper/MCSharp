using MCSharp.Exception;
using MCSharp.Type.CommandArg;
using MCSharp.Util;
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
    /// 目标选择器
    /// </summary>
    public class Selector : DataArg
    {
        public enum SelectorType
        {
            p, r, a, e, s
        }

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
        public List<SelectorArgument> args;

        /// <summary>
        /// 通过一个目标选择器构建实体
        /// </summary>
        /// <param name="selector"></param>
        public Selector(string selector)
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

        public static implicit operator Selector(string selector)
        {
            return new Selector(selector);
        }

        /// <summary>
        /// 通过一个目标选择器种类构建目标选择器
        /// </summary>
        /// <param name="type"></param>
        public Selector(SelectorType type)
        {
            selectorType = type;
            args = null;
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

        public static List<SelectorArgument> ParseArgs(string args)
        {
            //^[@][prase]([\[](([^=,]+[=][!]?([^=,{}]+|[{].+[}]))+([,]([^=,]+[=][!]?([^=,{}]+|[{].+[}])))*)+[\]])?$
            List<SelectorArgument> re = new List<SelectorArgument>();
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
                            re.Add(new x(double.Parse(kv[1])));
                            break;
                        case "y":
                            re.Add(new y(double.Parse(kv[1])));
                            break;
                        case "z":
                            re.Add(new z(double.Parse(kv[1])));
                            break;
                        case "dx":
                            re.Add(new dx(double.Parse(kv[1])));
                            break;
                        case "dy":
                            re.Add(new dy(double.Parse(kv[1])));
                            break;
                        case "dz":
                            re.Add(new dz(double.Parse(kv[1])));
                            break;
                        case "distance":
                            re.Add(new distance(double.Parse(kv[1])));
                            break;
                        case "scores":
                            string[] scores = kv[1].Substring(1, kv[1].Length-2).Split(',');
                            foreach (string score in scores)
                            {
                                string[] sckv = score.Split('=');
                                re.Add(new scores(sckv[0], new IntRange(sckv[1])));
                            }
                            break;
                        case "tag":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add(new tag(kv[1].Substring(1),false));
                            }
                            else
                            {
                                re.Add(new tag(kv[1]));
                            }
                            break;
                        case "team":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add(new team(kv[1].Substring(1), false));
                            }
                            else
                            {
                                re.Add(new team(kv[1]));
                            }
                            break;
                        case "type":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add(new type(kv[1].Substring(1), false));
                            }
                            else
                            {
                                re.Add(new type(kv[1]));
                            }
                            break;
                        case "predicate":
                            if (kv[1].StartsWith("!"))
                            {
                                re.Add(new predicate(kv[1].Substring(1), false));
                            }
                            else
                            {
                                re.Add(new predicate(kv[1]));
                            }
                            break;
                        case "x_rotation":
                            re.Add(new x_rotation(new IntRange(kv[1])));
                            break;
                        case "y_rotation":
                            re.Add(new y_rotation(new IntRange(kv[1])));
                            break;
                        case "nbt":
                            re.Add(new nbt(NBT.Prase(kv[1])));
                            break;
                        case "level":
                            re.Add(new level(new IntRange(kv[1])));
                            break;
                        case "gamemode":
                            re.Add(new gamemode(TGamemode.GetGamemodes(kv[1])));
                            break;
                        case "advancements":
                            //TODO:需要确认，进度条件可不可以塞多个条件并列
                            string[] kv2 = kv[1].Substring(1, kv[1].Length - 2).Split(new char[] {'='},2);
                            if (Regex.IsMatch(kv2[1], "^[{][0-9a-z_]+[=](true|false)[}]$"))
                            {
                                //条件
                                string[] kv3 = kv2[1].Substring(1, kv[1].Length - 2).Split(new char[] { '=' }, 2);
                                re.Add(new advancements(new ID(kv2[0]), kv3[0], bool.Parse(kv3[1])));
                            }
                            else
                            {
                                re.Add(new advancements(new ID(kv2[0]), bool.Parse(kv2[1])));
                            }
                            break;
                        case "limit":
                            re.Add(new limit(int.Parse(kv[1])));
                            break;
                        case "sort":
                            //TODO:sort后面的字符串不是自由写的但是我现在好想睡觉阿巴阿巴阿巴阿巴阿巴阿巴阿巴阿巴Zzzzzzz（狐狐瘫
                            re.Add(new sort(kv[1]));
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
            string re = "@" + Tools.GetEnumString(selectorType);
            if(args != null)
            {
                re += "[";
                foreach(SelectorArgument arg in args)
                {
                    re += arg + ",";
                }
                re = re.Substring(0, re.Length - 1);
                re += "]";
            }
            return re;
        }
    }
}
