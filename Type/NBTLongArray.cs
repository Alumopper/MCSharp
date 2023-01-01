using System;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTLongArray : NBTArray<long>
    {
        public NBTLongArray(string name) : base(name)
        {
        }

        public NBTLongArray() : base() { }

        public override object Value
        {
            set
            {
                if (value is List<NBTSingle<long>> value1)
                {
                    this.value = value1;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<long>:" + value);
                }
            }
        }
        
        public override string ValueString
        {
            get
            {
                string s = "[L;";
                foreach (long nbt in value)
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