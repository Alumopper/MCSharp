using MCSharp.Lib;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTDouble : NBTTag
    {        
        double value;

        public override object Value
        {
            get => value;
            set
            {
                if (value is double value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), nbtPath ?? IndexName, this);
                    nbtPath = null;
                }
                else
                {
                    throw new System.ArgumentException("需要为类型double:" + value);
                }
            }
        }

        public override string ValueString()
        {
            return value + "d";
        }

        public NBTDouble(string name, double value) : base(name)
        {
            DataModifySet(new ID("mcsharp:temp"), IndexName, this);
            this.value = value;
        }

        public override string ToString()
        {
            return Name + ":" + ValueString();
        }
    }
}
