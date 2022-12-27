using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTIntArray : NBTTag
    {
        int[] value;

        public override object Value
        {
            get => value;
            set
            {
                if (value is int[] value1)
                {
                    this.value = value1;
                    DataModifySet(new ID("mcsharp:temp"), IndexName, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型int[]:" + value);
                }
            }
        }

        public override string ValueString()
        {
            string result = "[";
            foreach (int i in value)
            {
                result += i + ",";
            }
            result = result.Substring(0, result.Length - 1);
            result += "]";
            return result;
        }

        public NBTIntArray(string name,params int[] value) :base(name)
        {
            DataModifySet(new ID("mcsharp:temp"), name + index, this);
            this.value = value;
        }

        public override string ToString()
        {
            return Name + ":" + ValueString();
        }
    }
}
