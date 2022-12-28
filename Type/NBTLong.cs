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
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型int:" + value);
                }
            }
        }

        public NBTLong(string name, long value) : base(name, value)
        {
        }
    }
}
