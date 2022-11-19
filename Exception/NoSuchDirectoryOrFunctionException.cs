using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp.Exception
{
    public class NoSuchDirectoryOrFunctionException : ApplicationException
    {
        public NoSuchDirectoryOrFunctionException(string msg): base(msg){}
    }
}
