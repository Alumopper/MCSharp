using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 函数的特性冲突时抛出此异常
    /// </summary>
    public class AttributeConflictException : ApplicationException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public AttributeConflictException(string message) : base(message) { }
    }
}
