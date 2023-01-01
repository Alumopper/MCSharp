using MCSharp.Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Attribute
{
    /// <summary>
    /// 此函数中不得执行命令函数，但不会抛出异常
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public class ForbidAttribute : System.Attribute
    {
        /// <summary>
        /// 有效帧。若为-1则始终有效
        /// </summary>
        public int frame = -1;
        public ForbidAttribute(){ }

        /// <summary>
        /// 当此函数是总栈的第多少帧的时候，不得执行命令函数
        /// </summary>
        /// <param name="frame"></param>
        public ForbidAttribute(int frame)
        {
            this.frame = frame;
        }
    }
}
