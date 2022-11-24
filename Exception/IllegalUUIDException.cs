using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Exception
{
    public class IllegalUUIDException : ApplicationException
    { 
        public IllegalUUIDException(string msg) : base(msg) { }
    }
}
