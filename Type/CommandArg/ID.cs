using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class ID
    {
        public string id;
        public string name;
        public string @namespace;
        public bool isTag;

        public ID(string id)
        {
            if (IsLegal(id))
            {
                if (id.StartsWith("#"))
                {
                    isTag = true;
                    id.Substring(1);
                }
                this.id = id;
                this.@namespace = id.Split(':')[0];
                this.name = id.Split(':')[1];
            }
            else
            {
                throw new IllegalFunctionNameException("错误的函数命名空间id:" + id);
            }
        }

        public ID(string @namespace, string name)
        {
            this.@namespace = @namespace;
            this.name = name;
            this.id = @namespace + ":" + name;
        }

        public static bool IsLegal(string str)
        {
            return Regex.IsMatch(str, "[#]?[a-z0-9_]+[:]?[a-z0-9_]+([/][a-z0-p_]+)*");
        }

        public override string ToString()
        {
            return (isTag ? "#" : "") + id;
        }
    }
}