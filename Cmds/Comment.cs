using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// mcfunction特有的注释
    /// </summary>
    public class Comment : Command
    {
        string comment;
        
        public Comment(string comment)
        {
            this.comment = comment;
        }

        public override string ToString()
        {
            return "#" + comment;
        }
    }
}
