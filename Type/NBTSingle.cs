using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTSingle<T> : NBTTag
    {
        protected T value;

        /// <summary>
        /// 这个NBTSingle的值
        /// </summary>
        public override object Value
        {
            get => value;
            set
            {
                if (value is T value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型T:" + value);
                }
            }
        }

        /// <summary>
        /// 此NBTSingle是否是动态的
        /// </summary>
        public override bool IsDynamic
        {
            get
            {
                return value == null;
            }
        }

        public static implicit operator T(NBTSingle<T> nbt)
        {
            return nbt.value;
        }

        public static implicit operator NBTSingle<T>(T value)
        {
            return new NBTSingle<T>(value);
        }

        /// <summary>
        /// 创建一个只有值的匿名NBTSingle
        /// </summary>
        /// <param name="value"></param>
        public NBTSingle(T value) : base(ID.tempNBT)
        {
            this.value = value;
            //匿名NBT标签不会有命令
        }

        /// <summary>
        /// 创建一个有值和名字的NBTSingle
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public NBTSingle(string name, T value) : base(name, ID.tempNBT)
        {
            this.value = value;
            DataModifySet(this, this);
        }

        /// <summary>
        /// 创建一个有值和名字的NBTSingle，并指定它的NBT容器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="container"></param>
        public NBTSingle(string name, T value, DataArg container) : base(name, container)
        {
            this.value = value;
            DataModifySet(this, this);
        }
    }
}
