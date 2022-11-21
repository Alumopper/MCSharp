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
            if (!FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:"+ new StackFrame(1).GetMethod().Name);
            }
            Function function = new Function(functionID);
            Datapack.functions[StackManager.GetStack()[0]].AddCommand(function);
            return function;
        }

        /// <summary>
        /// /say
        /// </summary>
        /// <param name="text">要发送的文本</param>
        public static Say Say(string text)
        {
            if (!FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Say say = new Say(text);
            Datapack.functions[StackManager.GetStack()[0]].AddCommand(say);
            return say;
        }

        /// <summary>
        /// 此命令函数是否被注册
        /// </summary>
        /// <returns>如果命令函数被注册，返回true</returns>
        private static bool FunctionHasRegistry()
        {
            StackFrame s = new StackFrame(2);
            if (Datapack.functions.ContainsKey(s.GetMethod().DeclaringType.FullName + "$" + s.GetMethod().Name))
            {
                return true;
            }
            return false;
        }
    }
}
