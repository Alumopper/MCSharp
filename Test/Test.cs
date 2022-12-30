using MCSharp.Attribute;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using System;
using System.Linq;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Test
{
    internal class Test
    {
        public static void Main()
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
            //NBTCompound qwq = new NBTCompound("owo")
            //{
            //    new NBTDouble("qwq",1.2),
            //    new NBTCompound("awa")
            //    {
            //        new NBTDouble("uwu",114514)
            //    }
            //};
            //qwq["awa"]["uwu"].Value = 1.4;
            //DatapackInfo.log.AddLog(Util.Log.Level.INFO, qwq["qwq"].ToString());
            //DatapackInfo.log.AddLog(Util.Log.Level.INFO, qwq["awa"]["uwu"].ToString());
            NBTList<NBTCompound> qwq = new NBTList<NBTCompound>("list")
            {
                new NBTCompound()
                {
                    new NBTDouble("qwq",1.2),
                },
                new NBTCompound()
                {
                    new NBTBool("qwq",false),
                    new NBTIntArray("array")
                    {
                        1,2,5,6
                    }
                }
            };
            qwq[0] = new NBTCompound()
            {
                new NBTDouble("qwq",3.5),
            };
            qwq[0]["qwq"].Value = 11.4514;
            DatapackInfo.log.AddLog(Util.Log.Level.INFO, qwq[0]);
        }
    }
}
