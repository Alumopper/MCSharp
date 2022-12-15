using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// 当execute命令已经结束时（最后一个子命令为run），仍然尝试添加子命令时抛出异常
    /// </summary>
    public class ExecuteCommandListEndException : ApplicationException
    {
        public ExecuteCommandListEndException(string message) : base(message){}
    }
}
