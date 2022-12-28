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
        //此NBTTag的父节点
        public NBTTag parentRoot;
        string name;
        object value;
        protected bool qwq = false;   //new的过程是否已经完毕

        private static int count = 0;

        protected int index;

        /// <summary>
        /// 此NBTTag在存储mcsharp:temp中的路径
        /// </summary>
        internal string Path
        {
            get
            {
                string re = name + (parentRoot != null ? "" : index.ToString());
                if (parentRoot is NBTCompound)
                {
                    re = parentRoot.Path + "." + re;
                }
                else if (parentRoot is NBTList<NBTTag> parentList)
                {
                    re = "[" + parentList.IndexOf(this) + "]";
                }
                return re;
            }
        }
        
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
        
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public virtual NBTTag this[string index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
