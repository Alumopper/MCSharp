using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTLong : NBTSingle<long>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is long value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型int:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                return value + "l";
            }
        }

        public NBTLong(string name, long value) : base(name, value)
        {
        }
    }
}
