using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class Storage : DataArg
    {

        public ID name;
        
        List<NBTTag> nbts;

        /// <summary>
        /// 创建一个空的存储
        /// </summary>
        /// <param name="name">存储的名字。不可为空</param>
        public Storage(ID name)
        {
            if (name == null)
                throw new ArgumentNullException("存储ID不能为空");
            this.name = name;
            this.nbts = new List<NBTTag>();
        }

        /// <summary>
        /// 创建一个匿名的储存
        /// </summary>
        internal Storage()
        {
            this.nbts = new List<NBTTag>();
        }

        /// <summary>
        /// 根据一个nbt标签创建一个存储。此存储将会包含这个NBT标签。
        /// </summary>
        /// <param name="tag"></param>
        public static implicit operator Storage(NBTTag tag)
        {
            Storage a = new Storage("mcsharp_temp:" + tag.GetHashCode());
            a.Add(tag);
            return a;
        }

        /// <summary>
        /// 根据名称获取NBT标签
        /// </summary>
        /// <param name="index">NBT标签的名称</param>
        /// <returns></returns>
        public NBTTag this[string index]
        {
            get
            {
                foreach (NBTTag nbt in nbts)
                {
                    if (nbt.Name == index)
                    {
                        return nbt;
                    }
                }
                return null;
            }
        }
        
        /// <summary>
        /// 向此存储中添加一个NBT标签
        /// </summary>
        /// <param name="tag"></param>
        public void Add(NBTTag tag)
        {
            nbts.Add(tag);
        }
    }
}
