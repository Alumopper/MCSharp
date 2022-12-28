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
                if (value is List<byte> value1)
                {
                    this.value = value1;
                    DataModifySet(new ID("mcsharp:temp"), Path, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<byte>:" + value);
                }
            }
        }
    }
}