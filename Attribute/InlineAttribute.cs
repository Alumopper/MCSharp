using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Attribute
{
    /// <summary>
    /// 命令将会穿透此方法传递到上一方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class)]
    public class InlineAttribute : System.Attribute
    {
        public InlineAttribute() { }
    }
}
