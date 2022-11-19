using MCsharp.Commands;
using MCsharp.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp
{
    public class FuncHolder
    {
        Datapack datapack;
        string name;
        public Dictionary<string,Function> functions = new Dictionary<string, Function>();

        public FuncHolder(string name)
        {
            this.name = name;
        }
        public Function this[String s]
        {
            get
            {
                try
                {
                    Function re = functions[s];
                    return re;
                }
                catch
                {
                    //创建新的函数
                    Function func = new Function(s);
                    functions.Add(s, func);
                    return func;
                }
            }
        }
        public override string ToString()
        {
            string qwq = name + "---------------->\n";
            foreach (var o in functions)
            {
                qwq += o.Value + "\n";
            }
            return qwq;
        }
    }
}
