using MCSharp.Cmds;
using MCSharp.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static MCSharp.Cmds.Commands;


namespace MCSharp.Type
{
    public class NBTArray<T> : NBTTag, IEnumerable<NBTSingle<T>>
    {
        protected List<NBTSingle<T>> value = new List<NBTSingle<T>>();
        Data data;  //未序列化的命令

        public override object Value
        {
            set
            {
                if (value is List<NBTSingle<T>> value1)
                {
                    this.value = value1;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<NBTSingle<T>>:" + value);
                }
            }
        }
        
        /// <summary>
        /// 这个NBTArray是不是动态的
        /// </summary>
        public override bool IsDynamic
        {
            get
            {
                return value == null;
            }
        }

        public NBTArray() : base(ID.tempNBT)
        {
            value = new List<NBTSingle<T>>();
            data = DataModifySet(this, this, false);
        }

        public NBTArray(IDataArg container) : base(container)
        {
            value = new List<NBTSingle<T>>();
            data = DataModifySet(this, this, false);
        }

        public NBTArray(string name) : base(name, ID.tempNBT)
        {
            value = new List<NBTSingle<T>>();
            data = DataModifySet(this, this, false);
        }
        
        public NBTArray(string name, IDataArg container) : base(name, container)
        {
            value = new List<NBTSingle<T>>();
            data = DataModifySet(this, this, false);
        }

        public override NBTTag this[object index]
        {
            get
            {
                if (index is int index1)
                {
                    return value[index1];
                }
                else
                {
                    throw new ArgumentException("只允许int类型的索引:" + index);
                }
            }
            set
            {
                if (index is int index1)
                {
                    //一有动静我就序列化.jpg
                    if (!hasSerialized)
                    {
                        //将命令序列化到函数中
                        Serialize(data);
                    }
                    hasSerialized = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
                    this.value[index1] = (NBTSingle<T>)value;
                    DataModifySet(this[index1], this[index1]);
                }
                else
                {
                    throw new ArgumentException("只允许int类型的索引:" + index);
                }
            }
        }

        internal void Add(NBTSingle<T> item)
        {
            value.Add(item);
            item.parentRoot = this;
        }

        internal void Add(NBTSingle<T>[] items)
        {
            foreach(NBTSingle<T> item in items)
            {
                value.Add(item);
                item.parentRoot = this;
            }
        }

        internal void Add(T[] items)
        {
            foreach (NBTSingle<T> item in items)
            {
                value.Add(item);
                item.parentRoot = this;
            }
        }

        /// <summary>
        /// 向此NBTArray末尾添加一个值
        /// </summary>
        /// <param name="tag"></param>
        public void Append(T tag)
        {
            //一有动静我就序列化.jpg
            if (!hasSerialized)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            hasSerialized = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            value.Add(tag);
            DataModifyAppend(this, (NBTSingle<T>)tag);
        }

        /// <summary>
        /// 在此NBTArray的指定位置插入一个值
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="tag">要插入的值</param>
        public void Insert(int index, T tag)
        {
            //一有动静我就序列化.jpg
            if (!hasSerialized)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            hasSerialized = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            value.Insert(index, tag);
            DataModifyInsert(this, (NBTSingle<T>)tag, index);
        }
        
        /// <summary>
        /// 在此NBTArray开头插入一个值
        /// </summary>
        /// <param name="item"></param>
        public void Prepend(T item)
        {
            //一有动静我就序列化.jpg
            if (!hasSerialized)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            hasSerialized = true; //对Compound中的元素进行了访问操作。必然完成了new的过程
            value.Prepend<NBTSingle<T>>(item);
            DataModifyPrepend(this, (NBTSingle<T>)item);
        }
        
        /// <summary>
        /// 将此NBTList中的指定项删除
        /// </summary>
        /// <param name="path"></param>
        public void Remove(int index)
        {
            //因为索引中有序列化，这里虽然也有动静但是不会专门去序列化啦
            this[index].parentRoot = null;
            value.Remove((NBTSingle<T>)this[index]);
            DataRemove(ID.tempNBT, Path + "[" + index + "]");
        }

        public IEnumerator<NBTSingle<T>> GetEnumerator() => value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.GetEnumerator();
    }
}
