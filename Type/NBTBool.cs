using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTBool : NBTSingle<bool>
    {
        public NBTBool(bool value) : base(value)
        {
        }

        public NBTBool(string name, bool value) : base(name, value)
        {
        }

        public NBTBool(string name, bool value, IDataArg container) : base(name, value, container)
        {
        }

        public override object Value
        {
            get => value;
            set
            {
                if (value is bool value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型bool:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                return value ? "true" : "false";
            }
        }
    }
}
