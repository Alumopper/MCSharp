using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTDouble : NBTSingle<double>
    {
        public NBTDouble(double value) : base(value)
        {
        }

        public NBTDouble(string name, double value) : base(name, value)
        {
        }

        public NBTDouble(string name, double value, IDataArg container) : base(name, value, container)
        {
        }

        public override object Value
        {
            get => value;
            set
            {
                if (value is double value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型double:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                return value + "d";
            }
        }
    }
}
