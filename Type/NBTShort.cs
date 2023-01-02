using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTShort : NBTSingle<short>
    {
        public NBTShort(short value) : base(value)
        {
        }

        public NBTShort(string name, short value) : base(name, value)
        {
        }

        public NBTShort(string name, short value, IDataArg container) : base(name, value, container)
        {
        }

        public override object Value
        {
            get => value;
            set
            {
                if (value is short value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型short:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                return value + "s";
            }
        }
    }
}
