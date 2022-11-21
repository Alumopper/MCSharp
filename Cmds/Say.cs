using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    public class Say : Command
    {
        private string text;

        public Say(string text)
        {
            this.text = text;
        }

        public override string ToString()
        {
            return "say " + text;
        }
    }
}
