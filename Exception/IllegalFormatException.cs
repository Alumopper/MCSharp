using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 当出现非法的格式时抛出此异常
    /// </summary>
    public class IllegalFormatException : ApplicationException
    {
        public IllegalFormatException(string msg) : base(msg) { }
    }
}
