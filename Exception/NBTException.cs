using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    /// <summary>
    /// NBT数据类型错误
    /// </summary>
    public class NBTException : ApplicationException
    {
        public NBTException(string message) : base(message)
        {
        }
    }
}
