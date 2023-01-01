using MCSharp.Cmds;
using MCSharp.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public NBTArray(DataArg container) : base(container)
        {
            value = new List<NBTSingle<T>>();
            data = DataModifySet(this, this, false);
        }

        public NBTArray(string name) : base(name, ID.tempNBT)
        {
            value = new List<NBTSingle<T>>();
            data = DataModifySet(this, this, false);
        }
        
        public NBTArray(string name, DataArg container) : base(name, container)
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
        /// 向此NBTIntArray中添加一个整数
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

        public IEnumerator<NBTSingle<T>> GetEnumerator() => value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.GetEnumerator();

        /// <summary>
        /// 将一个字符串转化为NBTArray<T>
        /// </summary>
        /// <param name="nbt"></param>
        /// <returns></returns>
        public static NBTTag Prase(string nbt)
        {
            try
            {
                string[] keyValue = nbt.Split(new char[] {':'},2);
                //[T;1,1,1,1,1,1,1,1,1,1]
                string[] values = keyValue[1].Substring(1, keyValue[1].Length - 2).Split(':',';');
                if (values[0] == "B")
                {
                    //byte
                    byte[] bytes = new byte[values.Length-1];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = byte.Parse(values[i + 1]);
                    }
                    return new NBTArray<byte>(keyValue[0]) { bytes };
                }
                if (values[0] == "I")
                {
                    //int
                    int[] ints = new int[values.Length - 1];
                    for (int i = 0; i < ints.Length; i++)
                    {
                        ints[i] = byte.Parse(values[i + 1]);
                    }
                    return new NBTArray<int>(keyValue[0]) { ints };
                }
                if (values[0] == "L")
                {
                    //int
                    long[] longs = new long[values.Length - 1];
                    for (int i = 0; i < longs.Length; i++)
                    {
                        longs[i] = byte.Parse(values[i + 1]);
                    }
                    return new NBTArray<long>(keyValue[0]) { longs };
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch (ApplicationException)
            {
                throw new IllegalFormatException("无法解析nbt字符串: " + nbt);
            }
        }
    }
}
