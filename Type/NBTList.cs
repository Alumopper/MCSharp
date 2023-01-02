using MCSharp.Cmds;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        /// <summary>
        /// 这个NBTList是不是动态的
        /// </summary>
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

        public NBTList(string name, IDataArg container) : base(name, container)
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
        
        public NBTList(IDataArg container) : base(container)
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

        /// <summary>
        /// 在此NBTList末尾添加一个值
        /// </summary>
        /// <param name="item"></param>
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

        /// <summary>
        /// 在此NBTList的指定位置插入一个值
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="item">要插入的值</param>
        public void Insert(int index, T item)
        {
            //一有动静我就序列化.jpg
            if (!hasSerialized)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            hasSerialized = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            value.Insert(index, item);
            item.parentRoot = this;
            DataModifyInsert(this, (NBTSingle<T>)item, index);
        }

        /// <summary>
        /// 在此NBTList开头插入一个值
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
            value.Prepend(item);
            item.parentRoot = this;
            DataModifyPrepend(this, item);
        }
        
        /// <summary>
        /// 将此NBTList中的指定项删除
        /// </summary>
        /// <param name="path"></param>
        public void Remove(int index)
        {
            //因为索引中有序列化，这里虽然也有动静但是不会专门去序列化啦
            this[index].parentRoot = null;
            value.Remove((T)this[index]);
            DataRemove(ID.tempNBT, Path + "[" + index + "]");
        }

        public IEnumerator<T> GetEnumerator() => value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.GetEnumerator();
    }
}
