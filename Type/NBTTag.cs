using MCSharp.Attribute;
using System;
using fNbt;
using System.Text.RegularExpressions;
using MCSharp.Exception;
using System.Net.Http.Headers;
using MCSharp.Cmds;
using System.Collections.Generic;
using System.CodeDom;
using System.Linq;
using static MCSharp.Cmds.Team;
using System.Reflection;

namespace MCSharp.Type
{
    [Inline]
    public class NBTTag
    {
        //此NBTTag的父节点
        public NBTTag parentRoot;
        
        internal string name;
        
        public string Name
        {
            get
            {
                return name;
            }
        }

        object value;

        public virtual object Value
        {
            get => value;
            set => this.value = value;
        }
        
        public virtual string ValueString
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool IsDynamic
        {
            get
            {
                return value == null;
            }
        }

        /// <summary>
        /// 列表正在被访问的元素索引
        /// </summary>
        public virtual int IndexOf
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 是否已经序列化
        /// </summary>
        protected bool hasSerialized = false;

        IDataArg container;
        
        public IDataArg Container
        {
            get
            {
                return container;
            }
        }

        private static int count = 0;

        protected int index;

        /// <summary>
        /// 此NBTTag在存储mcsharp:temp中的路径
        /// </summary>
        public string Path
        {
            get
            {
                string re = name + (parentRoot != null ? "" : index.ToString());
                if (parentRoot is NBTCompound)
                {
                    re = parentRoot.Path + "." + re;
                }
                else if (parentRoot != null && (parentRoot.GetType().IsGenericType ? parentRoot.GetType().GetGenericTypeDefinition() : parentRoot.GetType()) == typeof(NBTList<>))
                {
                    re = parentRoot.Path + "[" + parentRoot.IndexOf + "]" + re;
                }
                return re;
            }
        }

        protected bool isList = false;

        public NBTTag(IDataArg container)
        {
            index = count++;
            this.container = container;
        }

        internal NBTTag(string name, IDataArg container)
        {
            index = count++;
            this.name = name;
            this.container = container;
        }
        
        public virtual NBTTag this[object index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 获取这个NBTCompound的字符串形式
        /// </summary>
        public override string ToString()
        {
            return (Name ?? "?") + ":" + ValueString;
        }

        public static implicit operator NBTTag(SbValue sbValue)
        {
            //todo
            return null;
        }
        
        /// <summary>
        /// 属性的穷尽字符串数组
        /// </summary>
        public static string[] attributes = new string[]
        {
            "generic.max_health",
            "generic.follow_range",
            "generic.knockback_resistance",
            "generic.movement_speed",
            "generic.attack_damage",
            "generic.attack_knockback",
            "generic.armor",
            "generic.armor_toughness"
        };

        /// <summary>
        /// 检查一个nbt路径是否合法
        /// </summary>
        /// <param name="path">一个nbt路径</param>
        public static bool IsLegalPath(string path)
        {
            string[] paths = path.Split('.');
            foreach (string i in paths)
            {
                if (!Regex.IsMatch(i, "^[a-zA-Z0-9_]+([\\[](([0-9]+)|([\"][a-zA-Z_]+[\"]))[\\]])*$") || i == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 反序列化一段nbt字符串，从字符串中解析nbt列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="nbt"></param>
        /// <returns></returns>
        [Forbid]
        public static NBTList<T> PraseList<T>(string name, string nbt) where T : NBTTag
        {
            try
            {
                NBTList<T> re;
                int brackets = 0;
                List<T> tags = new List<T>();
                nbt = nbt.Substring(1, nbt.Length - 2); //掐头去尾
                string t = "";
                //列表
                //一级拆解
                for (int i = 0; i < nbt.Length; i++)
                {
                    if (brackets == 0 && nbt[i] == ',')
                    {
                        //一个值
                        T value = (T)Prase(null, t);
                        tags.Add(value);
                        t = "";
                    }
                    else if (nbt[i] == '{' || nbt[i] == '[')
                    {
                        brackets++;
                    }
                    else if (nbt[i] == '}' || nbt[i] == ']')
                    {
                        brackets--;
                    }
                    else
                    {
                        t += nbt[i];
                        continue;
                    }
                }
                //一个值
                T value1 = (T)Prase(null, t);
                tags.Add(value1);
                if (brackets != 0)
                {
                    throw new IllegalFormatException("括号不匹配: " + nbt);
                }
                if (name == null)
                {
                    re = new NBTList<T>()
                {
                    tags.ToArray()
                };
                }
                else
                {
                    re = new NBTList<T>(name)
                {
                    tags.ToArray()
                };
                }
                return re;
            }
            catch (IllegalFormatException e)
            {
                throw e;
            }
            catch (ApplicationException)
            {
                throw new IllegalFormatException("无法解析nbt: " + nbt);
            }
        }

        /// <summary>
        /// 反序列化一段nbt字符串，从字符串中解析nbt
        /// </summary>
        /// <param name="nbt"></param>
        /// <returns>反序列化出的nbt字符串</returns>
        [Forbid]
        public static NBTTag Prase(string name,string nbt)
        {
            /*
             * 需要解析的字符串一般是这样的{xxx1:yyy1,xxx2:yyy2}，或者是{xxx:yyy}
             * 当然也可能是单个值或者一个列表，数组等
             * 有列表的时候会复杂一些。{xxx:[a:b,e:{v:c}]}
             * 应当返回一个匿名的NBTCompound，当然这个时候的name也是null。
             * 在解析时，还是先用逗号切割这种传统异能来把每个键值对分开
             * 得到xxx:yyy这样的。
             * 这个时候我们就继续递归调用Parse()，第一个参数是xxx，第二个参数是yyy
             * 然后是区分我们要返回什么类型的NBT
             * 显然，如果字符串是{}开头结尾，这是一个NBTCompound
             * 否则则是数组或者单值，列表。
             * 列表的解析需要单独说一说。
             * 列表的键值对是这样的：xxx:[a,b,c,d,e]
             * 这时我们传入Prase的参数就是[a,b,c,d,e]的，开头和结尾都是中括号，非常有辨识度。
             * 然后我们就可以接着用逗号分割，把里面的键值对取出来
             * 由于NBTList是一个List类型的，因此只能有一种类型。这种类型就由第一个元素决定啦。
             * 因为NBTList是泛型类型，所以需要使用上面那个有泛型的方法 =w=
            */
            try
            {
                NBTTag re = null;
                int brackets = 0;
                if (nbt.StartsWith("{"))
                {
                    List<NBTTag> tags = new List<NBTTag>();
                    nbt = nbt.Substring(1, nbt.Length - 2); //掐头去尾
                    string t = "";
                    //复合
                    //一级拆解
                    for (int i = 0; i < nbt.Length; i++)
                    {
                        if (brackets == 0 && nbt[i] == ',')
                        {
                            //一个键值对
                            string[] kv = t.Split(new char[] { ':' }, 2);
                            tags.Add(Prase(kv[0], kv[1]));
                            t = "";
                        }
                        else if (nbt[i] == '{' || nbt[i] == '[')
                        {
                            t += nbt[i];
                            brackets++;
                        }
                        else if (nbt[i] == '}' || nbt[i] == ']')
                        {
                            t += nbt[i];
                            brackets--;
                        }
                        else
                        {
                            t += nbt[i];
                        }
                    }
                    //最后一个键值对
                    string[] kv1 = t.Split(new char[] { ':' }, 2);
                    if (kv1.Length == 2)
                    {
                        tags.Add(Prase(kv1[0], kv1[1]));
                    }
                    if (brackets != 0)
                    {
                        throw new IllegalFormatException("括号不匹配: " + nbt);
                    }
                    if (name == null)
                    {
                        re = new NBTCompound()
                        {
                            tags.ToArray()
                        };
                    }
                    else
                    {
                        re = new NBTCompound(name)
                        {
                            tags.ToArray()
                        };
                    }
                }
                else if (nbt.StartsWith("[") && nbt.Length > 3 && nbt[2] ==';')
                {
                    //[T;1,1,1,1,1,1,1,1,1,1]
                    string[] values = nbt.Substring(1, nbt.Length - 2).Split(',', ';');
                    if (values[0] == "B")
                    {
                        //byte
                        byte[] bytes = new byte[values.Length - 1];
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = byte.Parse(values[i + 1]);
                        }
                        return name == null ? new NBTByteArray() { bytes} : new NBTArray<byte>(name) { bytes };
                    }
                    if (values[0] == "I")
                    {
                        //int
                        int[] ints = new int[values.Length - 1];
                        for (int i = 0; i < ints.Length; i++)
                        {
                            ints[i] = int.Parse(values[i + 1]);
                        }
                        return name == null ? new NBTIntArray() { ints } : new NBTIntArray(name) { ints };
                    }
                    if (values[0] == "L")
                    {
                        //long
                        long[] longs = new long[values.Length - 1];
                        for (int i = 0; i < longs.Length; i++)
                        {
                            longs[i] = long.Parse(values[i + 1]);
                        }
                        return name == null ? new NBTLongArray() { longs } : new NBTLongArray(name) { longs };
                    }
                    else
                    {
                        throw new ApplicationException();
                    }
                }
                else if (nbt.StartsWith("["))
                {
                    //事列表
                    //获取列表的第一个值
                    string nbt1 = nbt.Substring(1, nbt.Length - 2); //掐头去尾
                    string t = "";
                    //复合
                    //一级拆解
                    for (int i = 0; i < nbt1.Length; i++)
                    {
                        if (brackets == 0 && nbt1[i] == ',')
                        {
                            //一个值
                            System.Type type = Prase(null, t).GetType();
                            re = (NBTTag)typeof(NBTTag).GetMethod("PraseList").MakeGenericMethod(type).Invoke(null ,new object[] { name, nbt });
                            break;
                        }
                        else if (nbt1[i] == '{' || nbt1[i] == '[')
                        {
                            brackets++;
                        }
                        else if (nbt1[i] == '}' || nbt1[i] == ']')
                        {
                            brackets--;
                        }
                        else
                        {
                            t += nbt1[i];
                            continue;
                        }
                    }
                }
                else
                {
                    //单值
                    if (bool.TryParse(nbt, out bool value))
                    {
                        re = name == null ? new NBTBool(value) : new NBTBool(name, value);
                        return re;
                    }
                    if (int.TryParse(nbt, out int value1))
                    {
                        re = name == null ? new NBTInt(value1) : new NBTInt(name, value1);
                        return re;
                    }
                    if (double.TryParse(nbt, out double value2))
                    {
                        re = name == null ? new NBTDouble(value2) : new NBTDouble(name, value2);
                        return re;
                    }
                    if (nbt.EndsWith("s") && short.TryParse(nbt.Substring(0, nbt.Length - 1), out short value3))
                    {
                        re = name == null ? new NBTShort(value3) : new NBTShort(name, value3);
                        return re;
                    }
                    if (nbt.EndsWith("l") && long.TryParse(nbt.Substring(0, nbt.Length - 1), out long value4))
                    {
                        re = name == null ? new NBTLong(value4) : new NBTLong(name, value4);
                        return re;
                    }
                    if (nbt.EndsWith("f") && float.TryParse(nbt.Substring(0, nbt.Length - 1), out float value5))
                    {
                        re = name == null ? new NBTFloat(value5) : new NBTFloat(name, value5);
                        return re;
                    }
                    if (nbt.EndsWith("d") && double.TryParse(nbt.Substring(0, nbt.Length - 1),out value2))
                    {
                        re = name == null ? new NBTDouble(value2) : new NBTDouble(name, value2);
                        return re;
                    }
                    if(nbt.StartsWith("\"") && nbt.EndsWith("\""))
                    {
                        nbt = nbt.Substring(1, nbt.Length - 2);
                    }
                    re = name == null ? new NBTString(nbt) : new NBTString(name, nbt);
                    return re;
                }
                return re;
            }
            catch (IllegalFormatException e)
            {
                throw e;
            }
            catch (ApplicationException)
            {
                throw new IllegalFormatException("无法解析nbt: " + nbt);
            }
        }
    }
}
