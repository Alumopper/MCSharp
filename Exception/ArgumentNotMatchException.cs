using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 当命令的参数不匹配时抛出此异常
    /// </summary>
    public class ArgumentNotMatchException : ArgumentException
    {
        public ArgumentNotMatchException(string msg) : base(msg) { }
    }
}
