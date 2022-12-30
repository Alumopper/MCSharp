using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTInt : NBTSingle<int>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is int value2)
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

        public NBTInt(string name, int value) : base(name, value)
        {
        }
    }
}
