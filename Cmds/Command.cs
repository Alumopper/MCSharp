using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 所有命令类的基类
    /// </summary>
    public class Command
    {
        /// <summary>
        /// 返回此命令对象的命令函数文本形式，可以直接被minecraft读取。每个命令类都应当重写此方法
        /// </summary>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
