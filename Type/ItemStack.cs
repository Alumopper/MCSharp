using MCSharp.Cmds;
using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 一个物品堆，包含了一个物品的id，nbt标签以及这个物品的数量
    /// </summary>
    public class ItemStack
    {
        /// <summary>
        /// 物品堆
        /// </summary>
        public string item_stack;
        /// <summary>
        /// 物品id
        /// </summary>
        public string id;
        /// <summary>
        /// 物品nbt标签
        /// </summary>
        public NBT nbt;

        /// <summary>
        /// 物品的数量
        /// </summary>
        public int count;

        /// <summary>
        /// 通过一个物品堆创建一个物品对象
        /// </summary>
        /// <param name="item_stack"></param>
        /// <exception cref="IllegalFormatException"></exception>
        public ItemStack(string item_stack, int count = 1)
        {
            if (item_stack.Contains('{'))
            {
                string[] qwq = item_stack.Split('{');
                string a = qwq[0];  //非nbt
                string b = qwq[1];  //nbt部分
                if (!Regex.IsMatch(a, "^([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+$"))
                {
                    throw new IllegalFormatException("无法解析字符串" + item_stack + "为item_stack");
                }
                this.id = a;
                this.nbt = new NBT(b); //尝试
            }
            else
            {
                if (!Regex.IsMatch(item_stack, "^([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+$"))
                {
                    throw new IllegalFormatException("无法解析字符串" + item_stack + "为item_stack");
                }
                this.id = item_stack;
            }
            this.item_stack = item_stack;
            this.count = count;
        }
    
        /// <summary>
        /// 根据物品id和nbt创建一个参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nbt"></param>
        /// <param name="count"></param>
        /// <exception cref="IllegalFormatException"></exception>
        public ItemStack(string id, NBT nbt, int count = 1)
        {

            if (!Regex.IsMatch(id, "^([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+$"))
            {
                throw new IllegalFormatException("无法解析字符串" + item_stack + "为item_stack");
            }
            this.id = id;
            this.nbt = nbt;
            this.count = count;
        }

        public override string ToString()
        {
            return item_stack + " " + count;
        }
    }
}
