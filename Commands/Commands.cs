using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp.Commands
{
    public class Commands
    {
        /// <summary>
        /// /say
        /// </summary>
        /// <param name="text">要发送的文本</param>
        public static void Say(string text)
        {
            Say say = new Say(text);
            new Datapack()["default"][new StackFrame(1,true).GetMethod().Name.ToLower()].commands.Add(say);
        }
    }
}
