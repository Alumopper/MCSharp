using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp.Commands
{
    internal class Say
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
