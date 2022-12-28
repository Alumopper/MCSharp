using MCSharp.Cmds;
using System;
using System.Collections;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;


namespace MCSharp.Type
{
    public class NBTArray<T> : NBTTag, IEnumerable<T>
    {
        protected NBTElement<List<T>> value = new NBTElement<List<T>>();
        Data data;  //未序列化的命令

        public override object Value
        {
            set
            {
                if (value is List<T> value1)
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
        
        public NBTArray(string name) : base(name)
        {
            value.Value = new List<T>();
            data = new Data(new ID("mcsharp:temp"), Path, "set", this.value);
            AddUnserializedCommand(data);
        }

        public T this[int index]
        {
            get
            {
                return value.Value[index];
            }
            set
            {
                //一有动静我就序列化.jpg
                if (!qwq)
                {
                    //将命令序列化到函数中
                    Serialize(data);
                }
                qwq = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
                this.value.Value[index] = (T)value;
                DataModifySet(new ID("mcsharp:temp"), Path, value);
            }
        }

        public override string ToString()
        {
            return Name + ":" + value;
        }

        internal void Add(NBTElement<T> item)
        {
            value.Value.Add(item);
        }

        /// <summary>
        /// 向此NBTIntArray中添加一个整数
        /// </summary>
        /// <param name="tag"></param>
        public void Append(T tag)
        {
            //一有动静我就序列化.jpg
            if (!qwq)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            qwq = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            value.Value.Add(tag);
            DataModifyAppend(new ID("mcsharp:temp"), Path, tag);
        }

        public IEnumerator<T> GetEnumerator() => value.Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.Value.GetEnumerator();
    }
}
