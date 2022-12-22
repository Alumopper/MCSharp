using MCSharp.Attribute;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using System;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Test
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            //初始化数据包
            //DatapackInfo.Init("D:\\.minecraft\\saves\\Datapack Lab\\datapacks", 10, "qwq", "qwq");
            Entity w = new Entity("@a[limit=2]");
            Console.ReadKey();
            //DatapackInfo.Create();      //生成数据包
        }

        [MCFunction]
        [FunctionTag("qwq","owo")]
        public static void qwq()
        {
            DatapackInfo.log.AddLog(Util.Log.Level.WARN, "嘤嘤嘤");
            Say("qwq");
            test();
        }

        public static void test()
        {
            //Say("test");
            awa();
        }

        [MCFunction]
        public static void awa()
        {
            Say("awa");
        }
    }
}
