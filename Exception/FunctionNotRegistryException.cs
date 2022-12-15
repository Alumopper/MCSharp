using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 当函数未注册时抛出此异常
    /// </summary>
    public class FunctionNotRegistryException : ApplicationException
    {
        public FunctionNotRegistryException(string msg) : base(msg) { }
    }
}
