using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Attribute
{
    /// <summary>
    /// 标记一个方法为一个命令函数
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method)]
    public class MCFunctionAttribute : System.Attribute
    {
        /// <summary>
        /// 喵喵喵
        /// </summary>
        public MCFunctionAttribute(){}
    }
}
