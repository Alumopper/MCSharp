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
            DatapackInfo.Init("D:\\.minecraft\\saves\\Datapack Lab\\datapacks", 10, "qwq", "qwq");
            //Selector s = "@s";
            //Storage nbt = s.nbt["testDouble"];
            ////data modify storage xxx(临时变量，随机的名字) testDouble set from entity @s testDouble
            //nbt.Value = 1.2;
            ////data modify storgae xxx testDouble set value 1.2
            //s.nbt["testDouble"] = nbt;
            ////data modify entity @s NBT.testDouble set from storage xxx testDouble
            qwq();
            DatapackInfo.PrintDataPack();
            DatapackInfo.log.Print();
            Console.ReadKey();
            //DatapackInfo.Create();      //生成数据包
        }

        [MCFunction]
        public static void qwq()
        {
            NBTCompound qwq = new NBTCompound("owo")
            {
                new NBTDouble("qwq",1.2)
            };
            qwq.Append(qwq);
            qwq["qwq"].Value = 1.4;
            DatapackInfo.log.AddLog(Util.Log.Level.INFO, qwq["qwq"].ToString());
        }
    }
}
