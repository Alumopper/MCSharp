using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTFloat : NBTSingle<float>
    {
        public override object Value
        {
            get => value;
            set
            {
                if (value is float value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型float:" + value);
                }
            }
        }

        public NBTFloat(string name, float value) : base(name, value)
        {
        }
    }
}
