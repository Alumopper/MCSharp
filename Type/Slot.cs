using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 表示一个物品栏槽位
    /// 物品栏的槽位通常都应该是xxx.xxx或者xxx.数值这样的格式。对此，非数字的部分和数字部分被分开处理
    /// </summary>
    public class Slot
    {
        int slot;
        string slothead;

        /// <summary>
        /// 创建一个Slot
        /// </summary>
        /// <param name="slothead">字符串部分</param>
        /// <param name="slot">数字部分。若为负数则表示没有，即此Slot为纯字母</param>
        public Slot(string slothead,int slot = -1)
        {
            this.slot = slot;
            this.slothead = slothead;
        }

        public override string ToString()
        {
            return slothead + (slot < 0 ? "" : ("." + slot));
        }

        public static class Armor
        {
            public static Slot chest = new Slot("armor.chest");
            public static Slot feet = new Slot("armor.feet");
            public static Slot head = new Slot("armor.head");
            public static Slot legs = new Slot("armor.legs");
        }

        public static class Weapon
        {
            public static Slot mainhand = new Slot("weapon.mainhand");
            public static Slot offhand = new Slot("weapon.offhand");
        }

        public static Slot weapon = new Slot("weapon");

        public class Dw5da6fDAWFDaw654
        {
            public Slot this[int i]
            {
                get
                {
                    if(i < 0)
                    {
                        i = 0;
                        DatapackInfo.log.AddLog(Util.Log.Level.WARN, "索引应当大于1，但是传入了:" + i);
                    }
                    return new Slot("container", i);
                }
            }
        }

        public static Dw5da6fDAWFDaw654 container = new Dw5da6fDAWFDaw654();

        public class DWD5d4w5d4awdawd7
        {
            public Slot this[int i]
            {
                get
                {
                    if (i < 0)
                    {
                        i = 0;
                        DatapackInfo.log.AddLog(Util.Log.Level.WARN, "索引应当大于1，但是传入了:" + i);
                    }
                    return new Slot("enderchest", i);
                }
            }
        }

        public static DWD5d4w5d4awdawd7 enderchest = new DWD5d4w5d4awdawd7();

        public class EDJWDwd5a4d8wa4d8
        {
            public Slot this[int i]
            {
                get
                {
                    if (i < 0)
                    {
                        i = 0;
                        DatapackInfo.log.AddLog(Util.Log.Level.WARN, "索引应当大于1，但是传入了:" + i);
                    }
                    return new Slot("hotbar", i);
                }
            }
        }

        public static EDJWDwd5a4d8wa4d8 hotbar = new EDJWDwd5a4d8wa4d8();

        public static class Horse
        {
            public static Slot saddle = new Slot("horse.saddle");
            public static Slot chest = new Slot("horse.chest");
            public static Slot armor = new Slot("horse.armor");
        }

        public class GRSGsef548sf4fdsd
        {
            public Slot this[int i]
            {
                get
                {
                    if (i < 0)
                    {
                        i = 0;
                        DatapackInfo.log.AddLog(Util.Log.Level.WARN, "索引应当大于1，但是传入了:" + i);
                    }
                    return new Slot("horse", i);
                }
            }
        }

        public static GRSGsef548sf4fdsd horse = new GRSGsef548sf4fdsd();

        public class OEASdqd4wa84d88d4
        {
            public Slot this[int i]
            {
                get
                {
                    if (i < 0)
                    {
                        i = 0;
                        DatapackInfo.log.AddLog(Util.Log.Level.WARN, "索引应当大于1，但是传入了:" + i);
                    }
                    return new Slot("villager", i);
                }
            }
        }

        public static OEASdqd4wa84d88d4 villager = new OEASdqd4wa84d88d4();
    }
}
