using MCSharp.Attribute;
using MCSharp.Cmds;
using System;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Test
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            //初始化数据包
            DatapackInfo.Init("D:\\.minecraft\\saves\\Datapack Lab\\datapacks", 10, "qwq", "qwq");
            DatapackInfo.log.Outputlevel = Util.Log.Level.DEBUG;
            qwq();
            DatapackInfo.Create();      //生成数据包
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
