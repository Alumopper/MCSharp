using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MCSharp.Cmds
{
    public class Function : Command
    {
        /// <summary>
        /// 函数命名空间id
        /// </summary>
        string functionID;

        public Function(string functionID)
        {
            this.functionID = functionID;
        }

        public override string ToString()
        {
            return "function " + functionID;
        }
    }
}
