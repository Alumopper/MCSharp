using fNbt;
using MCSharp.Attribute;
using System;
using static MCSharp.Cmds.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    [Penetrate]
    public class NBTTag
    {
        string name;
        object value;

        private static int count = 0;

        protected int index;
        internal string IndexName
        {
            get
            {
                return name + index;
            }
        }

        /// <summary>
        /// 当前的nbt路径嵌套情况
        /// </summary>
        protected static string nbtPath = null;
        
        public NBTTag()
        {
            index = count++;
        }

        internal NBTTag(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public virtual object Value
        {
            get => value;
            set => this.value = value;
        }

        public virtual string ValueString()
        {
            return "unknown";
        }
        
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
