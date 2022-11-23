using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MCSharp;
using MCSharp.Exception;

namespace MCSharp.Cmds
{
    public class Commands
    {

        public static Function Function(string functionID)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:"+ new StackFrame(1).GetMethod().Name);
            }
            Function function = new Function(functionID);
            DatapackInfo.functions[StackManager.GetStack()[0]].AddCommand(function);
            return function;
        }

        /// <summary>
        /// /say
        /// </summary>
        /// <param name="text">要发送的文本</param>
        public static Say Say(string text)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Say say = new Say(text);
            DatapackInfo.functions[StackManager.GetStack()[0]].AddCommand(say);
            return say;
        }
    }
}
