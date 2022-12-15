using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 当函数的名称不合法时抛出此异常
    /// </summary>
    public class IllegalFunctionNameException : ApplicationException
    {
        public IllegalFunctionNameException(string msg) : base(msg) { }
    }
}
