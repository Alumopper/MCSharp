using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    public class FunctionNotRegistryException : ApplicationException
    {
        public FunctionNotRegistryException(string msg) : base(msg) { }
    }
}
