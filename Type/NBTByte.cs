using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTByte : NBTSingle<byte>
    {
        public NBTByte(byte value) : base(value)
        {
        }

        public NBTByte(string name, byte value) : base(name, value)
        {
        }

        public NBTByte(string name, byte value, DataArg container) : base(name, value, container)
        {
        }

        public override object Value
        {
            get => value;
            set
            {
                if (value is byte value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型byte:" + value);
                }
            }
        }
        
        public override string ValueString
        {
            get
            {
                return value + "b";
            }
        }
    }
}
