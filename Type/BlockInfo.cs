using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class BlockInfo: IDataArg
    {
        Pos pos;
        public Pos Position
        {
            get
            {
                return pos;
            }
        }

        public string DataCmdStr()
        {
            return pos.ToString();
        }

        public void Merge(NBTTag nbt)
        {
            DataMerge(this, nbt);
        }
    }
}
