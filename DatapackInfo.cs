﻿#define DEBUG

using MCSharp.Attribute;
using MCSharp.Cmds;
using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static MCSharp.Cmds.Execute;

namespace MCSharp
{
    public static class DatapackInfo
    { 
        /// <summary>
        /// 数据包输出路径，应该是一个datapack文件夹下
        /// </summary>
        public static string outputPath = "./";

        /// <summary>
        /// 数据包版本
        /// </summary>
        public static int version;

        /// <summary>
        /// 数据包描述
        /// </summary>
        //public static JsonText discription = new JsonText("A datapack generated by MCSharp");
        public static string discription = "A datapack generated by MCSharp";

        /// <summary>
        /// 数据包名字
        /// </summary>
        public static string name = "Unnamed";

        /// <summary>
        /// 数据包中的所有函数
        /// </summary>
        public static Dictionary<string, FunctionInfo> functions = new Dictionary<string, FunctionInfo>();

        /// <summary>
        /// 数据包中的所有函数标签
        /// </summary>
        public static Dictionary<string, FunctionTag> functionTags = new Dictionary<string, FunctionTag>();

        /// <summary>
        /// 数据包的编译日志
        /// </summary>
        public static Log log = new Log();

        private static bool hasInited = false;

        public new static string ToString()
        {
            return name;
        }

        public enum FunctionState
        {
            UnRegestered,
            Regestered,
            Forbidden
        }

        /// <summary>
        /// 创建一个数据包
        /// </summary>
        public static void Create()
        {
            if (!hasInited)
            {
                throw new ApplicationException("数据包未初始化:" + name);
            }
            //删除旧数据包
            DirectoryInfo old = new DirectoryInfo(outputPath + "\\" + name);
            if (old.Exists)
            {
                old.Delete(true);
            }
            //生成数据包的函数文件
            DirectoryInfo func = Directory.CreateDirectory(outputPath + "\\" + name);
            foreach (KeyValuePair<string, FunctionInfo> function in functions)
            {
                //生成函数文件的路径
                DirectoryInfo di = new DirectoryInfo(func.FullName + "\\data\\"+ function.Value.@namespace +"\\functions\\" + function.Value.path.Substring(0, function.Value.path.LastIndexOf('/')));
                if (!di.Exists)
                {
                    di.Create();
                }
                //生成函数文件
                StreamWriter fs = new StreamWriter(File.Create(di.FullName + "\\" + function.Value.name + ".mcfunction"));
                StringBuilder builder = new StringBuilder();
                foreach (var commands in function.Value.GetCommands())
                {
                    builder.Append(commands.ToString()).AppendLine();
                }
                log.AddLog(Log.Level.DEBUG, "生成函数文件：" + di.FullName + "\\" + function.Value.name + ".mcfunction");
                fs.Write(builder);
                fs.Flush();
                fs.Close();
            }
            //生成数据包的函数标签文件
            foreach (FunctionTag tag in functionTags.Values)
            {
                tag.CreateFunctionTag(outputPath);
            }
            //生成数据包的pack.mcmeta文件
            log.AddLog(Log.Level.DEBUG, "生成数据包信息文件" + outputPath + "\\" + name + "\\pack.mcmeta");
            File.WriteAllText(outputPath + "\\" + name + "\\pack.mcmeta", "{\r\n    \"pack\": {\r\n        \"description\":\"" + discription + "\",\r\n        \"pack_format\": " + version + "\r\n    }\r\n}");
            //日志
            log.AddLog(Log.Level.INFO, "在\"" + outputPath + "\"下创建了数据包\"" + name + "\"喵");
            //输出日志
            log.Print();
            Console.WriteLine("按任意键继续...");
            Console.ReadKey();
        }

        /// <summary>
        /// 清空数据包
        /// </summary>
        public static void Clear()
        {
            functions = new Dictionary<string, FunctionInfo>();
            outputPath = "./";
            name = "Unnamed";
            version = 10;
            discription = "A datapack generated by MCSharp";
            log = new Log();
        }

        /// <summary>
        /// 创建数据包并清理数据包
        /// </summary>
        public static void CreateAndClear()
        {
            Create();
            Clear();
        }

        ///// <summary>
        ///// 注册一个函数为命令函数到数据包中
        ///// </summary>
        //public static void registryfunction()
        //{
        //    stackframe sf = new stacktrace().getframe(1);
        //    string funcname = sf.getmethod().declaringtype.namespace + "$" + sf.getmethod().declaringtype.name + "$" + sf.getmethod().name;
        //    functioninfo n = new functioninfo(funcname);
        //    //若函数没有被注册，则注册此函数
        //    if (!functions.containskey(funcname))
        //    {
        //        functions.add(funcname, n);
        //    }
        //}
        
        /// <summary>
        /// 注册一个函数为命令函数到数据包中
        /// </summary>
        public static void RegistryFunction(MethodBase method)
        {
            string funcname = method.DeclaringType.Namespace + "$" + method.DeclaringType.Name + "$" + method.Name;
            FunctionInfo n = new FunctionInfo(funcname, (FunctionTagAttribute)method.GetCustomAttribute(typeof(FunctionTagAttribute)));
            //若函数没有被注册，则注册此函数
            if (!functions.ContainsKey(funcname))
            {
                functions.Add(funcname, n);
            }
        }

        /// <summary>
        /// 此数据包中是否含有此函数
        /// </summary>
        /// <param name="stackName">函数在栈中的名字</param>
        /// <returns>如果含有此函数返回true</returns>
        public static bool HasFunction(string stackName)
        {
            foreach (string names in functions.Keys)
            {
                if (names.Equals(stackName))
                {
                    return true;
                }
            }
            return false;
        }

#if DEBUG
        //TODO:debug用函数
        public static void PrintFunctionNames()
        {
            StringBuilder stringBuilder = new StringBuilder("");
            foreach (FunctionInfo function in functions.Values)
            {
                stringBuilder.Append(function).AppendLine();
            }
            Console.Write(stringBuilder.ToString());
        }

        //TODO:debug用函数
        public static void PrintDataPack()
        {
            //打印喵
            foreach(FunctionInfo functionInfo in functions.Values)
            {
                Console.WriteLine(functionInfo.ToString());
                foreach(object command in functionInfo.GetCommands())
                {
                    Console.WriteLine("\t" + command.ToString());
                }
            }
        }

#endif
        /// <summary>
        /// 此命令函数是否被注册
        /// </summary>
        /// <returns>如果命令函数被注册，返回true</returns>
        public static FunctionState GetFunctionState()
        {
            List<StackFrame> fs = new StackTrace(2).GetFrames().ToList();
            foreach (StackFrame s in fs)
            {
                //是否已注册
                if (DatapackInfo.functions.ContainsKey(s.GetMethod().DeclaringType.Namespace + "$" + s.GetMethod().DeclaringType.Name + "$" + s.GetMethod().Name))
                {
                    return FunctionState.Regestered;
                }
                //是否有穿透属性
                if (s.GetMethod().IsDefined(typeof(MCFunctionAttribute)) || s.GetMethod().DeclaringType.IsDefined(typeof(MCFunctionAttribute)))
                {
                    RegistryFunction(s.GetMethod());
                    return FunctionState.Regestered;
                }
                //是否有有效的中断属性
                int index = fs.IndexOf(s);
                foreach(System.Attribute attribute in s.GetMethod().GetCustomAttributes(inherit: true).Cast<System.Attribute>())
                {
                    if (attribute is ForbidAttribute attribute1 && attribute1.frame == index)
                    {
                        return FunctionState.Forbidden;
                    }
                }
                //是否有穿透属性
                if (s.GetMethod().IsDefined(typeof(PenetrateAttribute)) || s.GetMethod().DeclaringType.IsDefined(typeof(PenetrateAttribute))){
                    continue;
                }
                else
                {
                    throw new FunctionNotRegistryException("未注册的函数" + s.GetMethod().Name);
                }
            }
            return FunctionState.UnRegestered;
        }

        /// <summary>
        /// 初始化数据包
        /// </summary>
        [MCFunction]
        public static void Init(string outputPath, int version, string discription, string name)
        {
            DatapackInfo.outputPath = outputPath;
            DatapackInfo.version = version;
            DatapackInfo.discription = discription;
            DatapackInfo.name = name;
            DatapackInfo.hasInited = true;
            SbObject.MCS_intvar = new SbObject("mcs_intvar");
            SbObject.MCS_default = new SbObject("mcs_default");
        }
    }
}