using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp
{
    internal class StackManager
    {
        private static List<string> stack = new List<string>();

        public static List<string> Stack
        {
            set
            {
                //栈的底部始终都会是根函数
                DatapackInfo.functions[value.Last()].isRoot = true;
                if (!Tools.ListEqualBySort(value,stack)) {
                    //栈发生了变化，说明发生了函数调用
                    //函数栈发生了变化，可能存在出栈和入栈
                    //求交集，从最后一个元素往前数，直到遇到不一样的元素，即为交集
                    List<string> intersect = new List<string>();
                    List<string> stackddd = new List<string>(); //原栈多出来的
                    //原栈不同的地方一定发生了出栈，而现栈不同的地方一定发生了入栈，即函数调用
                    //注意因为列表的尾巴才是栈的底部，所以要反着取值
                    for (int i = 0;i < Math.Min(value.Count,stack.Count); i++)
                    {
                        if (value[value.Count - 1 - i].Equals(stack[stack.Count - 1 - i]))
                        {
                            intersect.Insert(0,value[value.Count - 1 - i]);
                        }
                        else
                        {
                            for (int j = i; j < stack.Count; j++)
                            {
                                stackddd.Insert(0,stack[stack.Count - 1 - j]);
                            }
                            break;
                        }
                    }
                    //原栈出栈，即函数完成了调用，函数中的所有命令已经被注入到数据包对应的命令函数中，已经不再需要注入命令
                    foreach (string f in stackddd)
                    {
                        DatapackInfo.functions[f].end = true;
                    }
                    //现栈进栈，即此函数在上一个函数中被调用了，需要在上一个函数中添加一个funtion命令表示函数调用
                    //注意，在这样的列表中，索引越靠前，代表是栈的顶层，即[0]代表正在被执行的函数，[1]代表调用正在被执行的函数的函数
                    List<string> qwq = new List<string>(value);
                    while (!Tools.ListEqualBySort(qwq,intersect))
                    {
                        string w = qwq[0];
                        qwq.RemoveAt(0);
                        //但是需要注意的是，如果"被调用"的函数为根函数，那么实际上这个函数不会存在父函数被调用，因此需要忽略
                        if (DatapackInfo.functions[w].isRoot)
                        {
                            continue;
                        }
                        //添加函数调用语句
                        DatapackInfo.functions[qwq[0]].GetCommands().Add(new Cmds.Function(DatapackInfo.functions[w].ToString()));
                    }
                }
                stack = value;
            }
            get
            {
                return stack;
            }
        }
        
        /// <summary>
        /// 获取当前的命令函数栈
        /// <para>注意并不是实际的函数栈，而是命令函数栈，即返回的列表中只会有<b>已经注册在数据包中的</b>函数</para>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetStack()
        {
            StackFrame[] sfs = new StackTrace().GetFrames();
            List<string> re = new List<string>();
            foreach (StackFrame s in sfs)
            {
                string methodName = s.GetMethod().DeclaringType.Namespace + "$" + s.GetMethod().DeclaringType.Name + "$" + s.GetMethod().Name;
                if (DatapackInfo.functions.ContainsKey(methodName))
                {
                    re.Add(methodName);
                }
            }
            return re;
        }
    }
}
