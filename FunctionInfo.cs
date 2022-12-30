using MCSharp.Attribute;
using MCSharp.Cmds;
using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp
{
    public class FunctionInfo
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
        /// <para>格式：命名空间$类名$函数名</para>
        /// </summary>
        public string stackName;
        
        /// <summary>
        /// 函数命名空间
        /// </summary>
        public string @namespace;
        
        /// <summary>
        /// 函数标签
        /// </summary>
        public FunctionTag tag;

        /// <summary>
        /// 命令列表
        /// TODO:此处的列表只应当允许两种类型出现（string和Command）
        /// </summary>
        private List<object> commands = new List<object>();
        public List<object> GetCommands()
        {
            return commands;
        }

        /// <summary>
        /// 函数相对于functions文件夹的路径
        /// </summary>
        public string path;

        public static FunctionInfo lastFunc = null;

        public static List<string> currStack = new List<string>{""};

        public FunctionInfo(string stackName, FunctionTagAttribute tag)
        {
            //栈名：命名空间$类名$函数名
            //函数全称: 类的命名空间:类/函数名
            //切割栈名
            this.stackName = stackName;
            string[] funcinfos = stackName.Split('$');
            //根据类名补上函数的路径
            @namespace = funcinfos[0].Replace('.', '_').ToLower();  //类的命名空间
            name = funcinfos[2].ToLower(); //函数名
            path = funcinfos[1].Replace('.', '_').ToLower() + "/" + name;   //类名
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_/]+$"))
            {
                //非法命名
                throw new FunctionNotRegistryException("函数路径只能包含字母数字或下划线:" + path);
            }
            //标签
            this.tag = tag == null? null : new FunctionTag(tag.tag);
            if (this.tag != null)
            {
                //注册标签
                if (!DatapackInfo.functionTags.Keys.Contains(this.tag.ToString()))
                {
                    DatapackInfo.functionTags.Add(this.tag.ToString(), this.tag);
                }
                //向标签注入函数
                DatapackInfo.functionTags[this.tag.ToString()].functionNames.Add(this.ToString());
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

        /// <summary>
        /// 向此函数中添加一行命令
        /// </summary>
        /// <param name="c"></param>
        public void AddCommand(Command c)
        {
            //检查栈的变化并对栈进行更新
            StackManager.Stack = StackManager.GetStackName();
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

        /// <summary>
        /// 向此函数中添加一行未序列化的命令
        /// </summary>
        /// <param name="c"></param>
        public void AddUnserializedCommand(Command c)
        {
            //检查栈的变化并对栈进行更新
            StackManager.Stack = StackManager.GetStackName();
            //是否能添加命令
            //需要：是根函数 或者 此函数第一次入栈（未结束）
            if (StackManager.Stack.FindIndex(t => t.Equals(stackName)) == StackManager.Stack.LastIndexOf(stackName))
            {
                if (isRoot || !end)
                {
                    commands.Add(c);
                }
            }
        }

        /// <summary>
        /// 删除最后一个命令
        /// </summary>
        public void RemoveCommand()
        {
            commands.RemoveAt(commands.Count - 1);
        }

        /// <summary>
        /// 将此命令中的一个命令序列化
        /// 若没有此命令，则抛出异常
        /// </summary>
        /// <param name="element"></param>
        public void Serialize(Command element)
        {
            commands[commands.IndexOf(element)] = element.ToString();
        }
    }
}
