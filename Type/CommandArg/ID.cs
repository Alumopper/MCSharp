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

        public ID(string id)
        {
            if (IsLegal(id))
            {
                this.id = id;
                this.@namespace = id.Split(':')[0];
                this.name = id.Split(':')[1];
            }
        }

        public ID(string @namespace, string name)
        {
            this.@namespace = @namespace;
            this.name = name;
            this.id = @namespace + ":" + name;

    {

            }
        }

        public static bool IsLegal(string str)
        {
            return Regex.IsMatch(str, "[a-z0-9_]*[:]?[a-z0-9_]*");
        }

        public override string ToString()
        {
            return id;
        }
    }
}