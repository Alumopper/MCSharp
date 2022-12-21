using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Attribute
{
    /// <summary>
    /// 表示一个函数的标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class FunctionTagAttribute : System.Attribute
    {
        public ID tag;
        
        public FunctionTagAttribute(string tagname, string @namespace = "minecraft")
        {
            tag = new ID(@namespace, tagname);
        }
    }
}
