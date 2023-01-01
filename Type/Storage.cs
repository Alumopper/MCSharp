using MCSharp.Attribute;
using System;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    [Inline]
    public class Storage : DataArg
    {

        public ID name;

        NBTCompound nbt;

        /// <summary>
        /// 此存储中储存的NBT数据
        /// </summary>
        public NBTCompound NBT
        {
            get
            {
                return nbt;
            }
        }

        /// <summary>
        /// 创建一个空的存储
        /// </summary>
        /// <param name="name">存储的名字。不可为空</param>
        public Storage(ID name)
        {
            this.name = name ?? throw new ArgumentNullException("存储ID不能为空");
            this.nbt = new NBTCompound(this);
        }

        /// <summary>
        /// 根据一个nbt标签创建一个存储。此存储将会包含这个NBT标签。
        /// </summary>
        /// <param name="tag"></param>
        public Storage(ID name, NBTCompound nbt)
        {
            this.name = name;
            this.nbt = nbt;
        }
    }
}
