using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp
{
    public class Function
    {
        public string name;
        public ArrayList commands = new ArrayList();

        public Function(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            string qwq = name+"\n";
            foreach(var o in commands)
            {
                qwq += o + "\n";
            }
            return qwq;
        }
    }
}
