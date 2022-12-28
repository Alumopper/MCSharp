using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTString : NBTSingle<string>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is string value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型string:" + value);
                }
            }
        }

        public NBTString(string name, string value) : base(name, value)
        {
        }
    }
}
