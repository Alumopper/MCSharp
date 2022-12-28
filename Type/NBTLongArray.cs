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

        public override object Value
        {
            set
            {
                if (value is List<long> value1)
                {
                    this.value = value1;
                    DataModifySet(new ID("mcsharp:temp"), Path, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<long>:" + value);
                }
            }
        }
    }
}