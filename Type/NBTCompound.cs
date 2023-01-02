using MCSharp.Attribute;
using MCSharp.Cmds;
using System;
using System.Collections;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    [Inline]
    public class NBTCompound : NBTTag, IEnumerable<NBTTag>
    {
        List<NBTTag> value;
        Data data;

        /// <summary>
        /// 获取这个NBTCompound的值
        /// </summary>
        public override object Value
        {
            get => value;
            set
            {
                if (value is List<NBTTag> value1)
                {
                    //一有动静我就序列化.jpg
                    if (!hasSerialized)
                    {
                        //将命令序列化到函数中
                        Serialize(data);
                    }
                    hasSerialized = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
                    this.value = value1;
                    DataModifySet(this, this);
                }
                else
                {
                    throw new ArgumentException("需要为类型List<NBTPath>:" + value);
                }
            }
        }

        /// <summary>
        /// 获取这个NBTCompound的值的字符串形式
        /// </summary>
        public override string ValueString
        {
            get
            {
                if (IsDynamic)
                {
                    return "?";
                }
                string s = "{";
                foreach (NBTTag nbt in value)
                {
                    s += nbt.ToString() + ",";
                }
                s = s.TrimEnd(',');
                s += "}";
                return s;
            }
        }

        /// <summary>
        /// 这个NBTCompound是否是动态的
        /// </summary>
        public override bool IsDynamic
        {
            get
            {
                return value == null;
            }
        }

        /// <summary>
        /// 创建一个空的NBTCompound，NBT容器默认为ID.tempNBT
        /// </summary>
        /// <param name="name"></param>
        public NBTCompound(string name) : base(name, ID.tempNBT)
        {
            value = new List<NBTTag>();
            //添加未序列化的命令，从而在new语句中后续调用add方法改变字典时也会让命令中的元素发生变化
            data = DataModifySet(this, this,false);
        }

        /// <summary>
        /// 创建一个空的NBTCompound，指定了它所属的NBT容器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="container"></param>
        public NBTCompound(string name, IDataArg container) : base(name, container)
        {
            value = new List<NBTTag>();
            //添加未序列化的命令，从而在new语句中后续调用add方法改变字典时也会让命令中的元素发生变化
            data = DataModifySet(this, this, false);
        }

        /// <summary>
        /// 创建一个匿名NBTCompound，指定它所属的NBT容器
        /// </summary>
        public NBTCompound(IDataArg container) : base(container)
        {
            value = new List<NBTTag>();
            hasSerialized = true;
        }

        /// <summary>
        /// 创建一个匿名NBTCompound
        /// </summary>
        public NBTCompound() : base(ID.tempNBT)
        {
            value = new List<NBTTag>();
            hasSerialized = true;
        }

        /// <summary>
        /// 通过字符串获取这个NBTCompound中的NBTTag
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override NBTTag this[object index]
        {
            get
            {
                if(index is string strindex)
                {
                    //一有动静我就序列化.jpg
                    if (!hasSerialized)
                    {
                        //将命令序列化到函数中
                        Serialize(data);
                    }
                    hasSerialized = true; //对Compound中的元素进行了访问操作。必然完成了new的过程
                    foreach (NBTTag tag in value)
                    {
                        if (tag.Name == strindex)
                        {
                            return tag;
                        }
                    }
                    return null;
                }
                else
                {
                    throw new ArgumentException("只允许string类型的索引" + value);
                }
            }
        }

        internal void Add(NBTTag tag)
        {
            if(tag is NBTCompound qwq)
            {
                qwq.hasSerialized = true; //用于new的NBTTag是没有命令哒，不用考虑序列化问题
            }
            if(tag.Name != null)
            {
                RemoveCommand();
            }
            tag.parentRoot = this;  //父元素设置
            value.Add(tag);
        }

        internal void Add(NBTTag[] tags)
        {
            foreach(NBTTag tag in tags)
            {
                if (tag is NBTCompound qwq)
                {
                    qwq.hasSerialized = true; //用于new的NBTTag是没有命令哒，不用考虑序列化问题
                }
                if (tag.Name != null)
                {
                    RemoveCommand();
                }
                tag.parentRoot = this;  //父元素设置
                value.Add(tag);
            }
        }

        /// <summary>
        /// 向此NBTCompound中添加一个NBTTag
        /// </summary>
        /// <param name="tag"></param>
        public void Merge(NBTTag tag)
        {
            //一有动静我就序列化.jpg
            if (!hasSerialized)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            hasSerialized = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            tag.parentRoot = this;  //父元素设置
            value.Add(tag);
            DataModifyMerge(this, tag);
        }

        /// <summary>
        /// 将此NBTCompound中的指定项删除
        /// </summary>
        /// <param name="path"></param>
        public void Remove(string path)
        {
            //因为索引中有序列化，这里虽然也有动静但是不会专门去序列化啦
            this[path].parentRoot = null;
            value.Remove(this[path]);
            DataRemove(ID.tempNBT, Path + "." + path);
        }

        public T GetDynamicNBT<T>(string key) where T : NBTTag, new()
        {
            T re = new T
            {
                name = key
            };
            value.Add(re);
            return re;
        }
        
        public IEnumerator<NBTTag> GetEnumerator() => value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.GetEnumerator();
    }
}
