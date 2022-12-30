using MCSharp.Exception;
using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 一个命名空间id。也可以是标签。
    /// </summary>
    public class ID : DataArg
    {
        public static readonly ID tempNBT = new ID("mcsharp:temp");

        /// <summary>
        /// 命名空间id全称。不包含标签符"#"
        /// </summary>
        public string id;

        /// <summary>
        /// 命名空间id的id部分
        /// </summary>
        public string name;
        
        /// <summary>
        /// 命名空间id的命名空间部分
        /// </summary>
        public string @namespace;

        /// <summary>
        /// 是否是标签。如果是标签，在调用ToString方法时会在前面加上"#"
        /// </summary>
        public bool isTag;

        /// <summary>
        /// 根据一个命名空间的字符串创建一个命名空间id。字符串的标准格式为xxx:xxx或#xxx:xxx。若未执行命名空间，则默认命名空间为minecraft
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="IllegalFunctionNameException"></exception>
        public ID(string id)
        {
            if (IsLegal(id))
            {
                if (id.StartsWith("#"))
                {
                    isTag = true;
                    id.Substring(1);
                }
                if (id.Contains(":"))
                {
                    this.id = id;
                    this.@namespace = id.Split(':')[0];
                    this.name = id.Split(':')[1];
                }
                else
                {
                    this.@namespace = "minecraft";
                    this.name = id;
                    this.id = @namespace + ":" + name;
                }
            }
            else
            {
                throw new IllegalFunctionNameException("错误的函数命名空间id:" + id);
            }
        }

        /// <summary>
        /// 根据指定的命名空间和名称创建新的命名空间id
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="name"></param>
        public ID(string @namespace, string name)
        {
            this.@namespace = @namespace;
            this.name = name;
            this.id = @namespace + ":" + name;
        }

        public static bool IsLegal(string str)
        {
            return Regex.IsMatch(str, "(^[#]?[a-z0-9_]+[:][a-z0-9_]+([/][a-z0-p_]+)*$)|(^[a-z0-9_]+$)");
        }

        public override string ToString()
        {
            return (isTag ? "#" : "") + id;
        }

        public static implicit operator ID(string id)
        {
            return new ID(id);
        }

        public override bool Equals(object obj)
        {
            if (obj is ID)
            {
                return ((ID)obj).id == id && isTag == ((ID)obj).isTag;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}