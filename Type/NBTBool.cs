using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTBool : NBTSingle<bool>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is bool value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型bool:" + value);
                }
            }
        }

        public NBTBool(string name, bool value) : base(name, value)
        {
        }
    }
}
