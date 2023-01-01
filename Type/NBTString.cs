using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTString : NBTSingle<string>
    {
        public NBTString(string value) : base(value)
        {
        }

        public NBTString(string name, string value) : base(name, value)
        {
        }

        public NBTString(string name, string value, DataArg container) : base(name, value, container)
        {
        }

        public override object Value
        {
            get => value;
            set
            {
                if (value is string value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型string:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                return "\"" + value + "\"";
            }
        }
    }
}
