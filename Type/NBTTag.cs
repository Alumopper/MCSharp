using MCSharp.Attribute;
using System;
using static MCSharp.Cmds.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCSharp.Type.CommandArg;
using System.ComponentModel;

namespace MCSharp.Type
{
    [Penetrate]
    public class NBTTag
    {
        //此NBTTag的父节点
        public NBTTag parentRoot;
        
        string name;
        
        public string Name
        {
            get
            {
                return name;
            }
        }

        object value;

        public virtual object Value
        {
            get => value;
            set => this.value = value;
        }
        
        public virtual string ValueString
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool IsDynamic
        {
            get
            {
                return value == null;
            }
        }

        /// <summary>
        /// 列表正在被访问的元素索引
        /// </summary>
        public virtual int IndexOf
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 是否已经序列化
        /// </summary>
        protected bool hasSerialized = false;

        DataArg container;
        
        public DataArg Container
        {
            get
            {
                return container;
            }
        }

        private static int count = 0;

        protected int index;

        /// <summary>
        /// 此NBTTag在存储mcsharp:temp中的路径
        /// </summary>
        public string Path
        {
            get
            {
                string re = name + (parentRoot != null ? "" : index.ToString());
                if (parentRoot is NBTCompound)
                {
                    re = parentRoot.Path + "." + re;
                }
                else if (parentRoot != null && (parentRoot.GetType().IsGenericType ? parentRoot.GetType().GetGenericTypeDefinition() : parentRoot.GetType()) == typeof(NBTList<>))
                {
                    re = parentRoot.Path + "[" + parentRoot.IndexOf + "]" + re;
                }
                return re;
            }
        }

        protected bool isList = false;

        public NBTTag(DataArg container)
        {
            index = count++;
            this.container = container;
        }

        internal NBTTag(string name, DataArg container)
        {
            index = count++;
            this.name = name;
            this.container = container;
        }
        
        public virtual NBTTag this[object index]
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
        
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
