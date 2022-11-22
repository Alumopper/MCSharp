using MCSharp.Cmds;
using MCSharp.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp
{
    public class Function
    {
        /// <summary>
        /// 是否是功能根函数
        /// </summary>
        public bool isRoot = false;

        /// <summary>
        /// 是否已经结束其中所有的命令
        /// </summary>
        public bool end = false;
        
        /// <summary>
        /// 函数的名字，已经转换为小写
        /// </summary>
        public string name;
        
        /// <summary>
        /// <para>函数在栈中的名字</para>
        /// <para>格式：命名空间$类名$tag命名空间_tag名_函数名</para>
        /// </summary>
        public string stackName;
        
        /// <summary>
        /// 函数命名空间
        /// </summary>
        public string @namespace;
        
        /// <summary>
        /// 上一次注入命令的函数
        /// </summary>
        public FunctionTag tag;

        /// <summary>
        /// 命令列表
        /// </summary>
        private List<Command> commands = new List<Command>();
        public List<Command> GetCommands()
        {
            return commands;
        }

        /// <summary>
        /// 函数相对于functions文件夹的路径
        /// </summary>
        public string path;

        public static Function lastFunc = null;

        public static List<string> currStack = new List<string>{""};

        public Function(string stackName)
        {
            this.stackName = stackName;
            string[] funcinfos = stackName.Split('$');
            //名字：类名_函数名
            stackName = funcinfos[2];
            //未转换的名字，如果含有下划线则切割
            if (stackName.Contains('_'))
            {
                this.tag = new FunctionTag();
                string[] qwq = stackName.Split(new char[] {'_'},3);
                //第一个为tag命名空间标记
                if (qwq[0].Equals(""))
                {
                    tag.@namespace = "minecraft";
                }
                else
                {
                    tag.@namespace = qwq[0];
                }
                tag.name = qwq[1];
                this.name = qwq[2].ToLower();
            }
            else
            {
                this.name = stackName.ToLower();
            }
            //根据类名补上函数的路径
            path = funcinfos[1].Replace('.', '_').ToLower() + "/" + name;
            @namespace = funcinfos[0].Replace('.', '_').ToLower();
            if(!Regex.IsMatch(name, @"^[a-zA-Z0-9_/]+$"))
            {
                //非法命名
                throw new FunctionNotRegistryException("函数路径只能包含字母数字或下划线:" + path);
            }
        }

        /// <summary>
        /// 返回函数的命名空间id
        /// </summary>
        /// <returns>函数的命名空间id</returns>
        public override string ToString()
        {
            return @namespace + ":" + path;
        }

        public void AddCommand(Command c)
        {
            //检查栈的变化并对栈进行更新
            StackManager.Stack = StackManager.GetStack();
            //是否能添加命令
            //需要：是根函数 或者 此函数第一次入栈（未结束）
            if(StackManager.Stack.FindIndex(t => t.Equals(stackName)) == StackManager.Stack.LastIndexOf(stackName))
            {
                if(isRoot || !end)
                {
                    commands.Add(c);
                }
            }
        }
    }
}
