using System;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTIntArray : NBTArray<int>
    {
        public NBTIntArray(string name) : base(name)
        {
        }

        public override object Value
        {
            set
            {
                if (value is List<NBTSingle<int>> value1)
                {
                    this.value = value1;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<int>:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                string s = "[I;";
                foreach (int nbt in value)
                {
                    s += nbt + ",";
                }
                s = s.TrimEnd(',');
                s += "]";
                return s;
            }
        }
    }
}
