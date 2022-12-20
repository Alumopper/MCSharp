using MCSharp.Attribute;
using MCSharp.Cmds;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [MCFunction]
        public static void qwq()
        {
            Commands.Say("qwq");
            test();
        }

        public static void test()
        {
            awa();
        }

        [MCFunction]
        public static void awa()
        {
            Commands.Say("awa");
        }
    }
}
