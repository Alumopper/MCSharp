using MCSharp.Cmds;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Test
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            //初始化数据包
            DatapackInfo.Init("D:\\.minecraft\\saves\\Datapack Lab\\datapacks", 10, "qwq", "qwq");
            qwq(); 
            DatapackInfo.PrintDataPack();
            Console.ReadLine();
            //DatapackInfo.Create();      //生成数据包
        }

        public static void qwq()
        {
            DatapackInfo.RegistryFunction();
            MCInt a = 114514;
            MCInt b = 1919;
            MCInt c = 810;
            MCInt p = 233;
            MCInt qwq = new MCInt(a + b + c - p * a + (p / b),"qwq");
        }
    }
}
