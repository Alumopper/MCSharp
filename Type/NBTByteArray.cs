using System;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTByteArray : NBTArray<byte>
    {
        public NBTByteArray(string name) : base(name)
        {
        }

        public override object Value
        {
            set
            {
                if (value is List<NBTSingle<byte>> value1)
                {
                    this.value = value1;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<byte>:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                string s = "[B;";
                foreach (byte nbt in value)
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