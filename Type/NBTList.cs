using MCSharp.Cmds;
using System.Collections;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTList<T> : NBTTag, IEnumerable<T> where T : NBTTag 
    {
        List<T> value = new List<T>();
        Data data;
        int indexof = -1;

        /// <summary>
        /// 获取或设置此NBTList的值。返回一个List<T>对象
        /// </summary>
        public override object Value
        {
            get => value;
            set
            {
                //一有动静我就序列化.jpg
                if (!hasSerialized)
                {
                    //将命令序列化到函数中
                    Serialize(data);
                }
                hasSerialized = true; //对Compound中的元素进行了访问操作。必然完成了new的过程
                if (value is List<T> value2)
                {
                    this.value = value2;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new System.ArgumentException("需要为类型List<"+typeof(T)+">:" + value);
                }
            }
        }

        public override string ValueString
        {
            get
            {
                string s = "[";
                foreach (T nbt in value)
                {
                    s += nbt.ValueString + ",";
                }
                s = s.TrimEnd(',');
                s += "]";
                return s;
            }
        }
        
        public override bool IsDynamic
        {
            get
            {
                return value == null;
            }
        }

        public override int IndexOf
        {
            get
            {
                return indexof;
            }
        }

        public override NBTTag this[object index]
        {
            get
            {
                if (index is int index1)
                {
                    //一有动静我就序列化.jpg
                    if (!hasSerialized)
                    {
                        //将命令序列化到函数中
                        Serialize(data);
                    }
                    hasSerialized = true;
                    indexof = index1;
                    return value[index1];
                }
                else
                {
                    throw new System.ArgumentException("只允许int类型的索引:" + index);
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
                    hasSerialized = true;
                    indexof = index1;
                    DataModifySet(this[index1], value);
                }
                else
                {
                    throw new System.ArgumentException("只允许int类型的索引:" + index);
                }
            }
        }

        public NBTList(string name, DataArg container) : base(name, container)
        {
            isList = true;
            //添加未序列化的命令，从而在new语句中后续调用add方法改变列表时也会让命令中的元素发生变化
            data = DataModifySet(this, this, false);
        }
        
        public NBTList(string name) : base(name, ID.tempNBT)
        {
            isList = true;
            //添加未序列化的命令，从而在new语句中后续调用add方法改变列表时也会让命令中的元素发生变化
            data = DataModifySet(this, this,false);
        }
        
        public NBTList(DataArg container) : base(container)
        {
            isList = true;
            //添加未序列化的命令，从而在new语句中后续调用add方法改变列表时也会让命令中的元素发生变化
            data = DataModifySet(this, this, false);
        }

        public NBTList() : base(ID.tempNBT)
        {
            isList = true;
            //添加未序列化的命令，从而在new语句中后续调用add方法改变列表时也会让命令中的元素发生变化
            data = DataModifySet(this, this, false);
        }

        internal void Add(T item)
        {
            if (item.Name != null)
            {
                RemoveCommand();
            }
            value.Add(item);
            item.parentRoot = this;
        }
        
        internal void Add(T[] items)
        {
            foreach(T item in items)
            {
                if (item.Name != null)
                {
                    RemoveCommand();
                }
                value.Add(item);
                item.parentRoot = this;
            }
        }

        public void Append(T item)
        {
            //一有动静我就序列化.jpg
            if (!hasSerialized)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            hasSerialized = true; //对Compound中的元素进行了访问操作。必然完成了new的过程
            value.Add(item);
            item.parentRoot = this;
            DataModifyAppend(this, item);
        }
        
        public IEnumerator<T> GetEnumerator() => value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.GetEnumerator();
    }
}
