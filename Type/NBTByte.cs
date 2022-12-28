using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTByte : NBTSingle<byte>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is byte value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型byte:" + value);
                }
            }
        }

        public NBTByte(string name, byte value) : base(name, value)
        {
        }
    }
}
