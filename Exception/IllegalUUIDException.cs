using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 当UUID不合法时抛出此异常
    /// </summary>
    public class IllegalUUIDException : ApplicationException
    { 
        public IllegalUUIDException(string msg) : base(msg) { }
    }
}
