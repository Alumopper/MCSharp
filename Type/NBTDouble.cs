﻿using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTDouble : NBTSingle<double>
    {       
        public override object Value
        {
            get => value;
            set
            {
                if (value is double value2)
                {
                    this.value = value2;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型double:" + value);
                }
            }
        }

        public NBTDouble(string name, double value) : base(name, value)
        {
        }
    }
}
