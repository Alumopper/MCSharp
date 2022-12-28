﻿using System;
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
                if (value is List<int> value1)
                {
                    this.value = value1;
                    DataModifySet(new ID("mcsharp:temp"), Path, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<int>:" + value);
                }
            }
        }
    }
}
