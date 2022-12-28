using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTSingle<T> : NBTTag
    {
        protected NBTElement<T> value;

        public override object Value
        {
            get => value;
            set
            {
                if (value is T value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型T:" + value);
                }
            }
        }

        public NBTSingle(string name, T value) : base(name)
        {
            this.value = value;
            DataModifySet(new ID("mcsharp:temp"), Path, this.value);
        }

        public override string ToString()
        {
            return Name + ":" + value;
        }
    }
}
