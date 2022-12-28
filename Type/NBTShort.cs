using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTShort : NBTSingle<short>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is short value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型short:" + value);
                }
            }
        }

        public NBTShort(string name, short value) : base(name, value)
        {
        }
    }
}
