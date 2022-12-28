using MCSharp.Attribute;
using MCSharp.Cmds;
using System;
using System.Collections;
using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    [Penetrate]
    public class NBTCompound : NBTTag, IEnumerable<NBTTag>
    {
        NBTElement<Dictionary<string,NBTTag>> value = new Dictionary<string, NBTTag>();
        Data data;
        
        public override object Value
        {
            get => value;
            set
            {
                if (value is Dictionary<string, NBTTag> value1)
                {
                    //一有动静我就序列化.jpg
                    if (!qwq)
                    {
                        //将命令序列化到函数中
                        Serialize(data);
                    }
                    qwq = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
                    this.value = value1;
                    DataModifySet(new ID("mcsharp:temp"), Path, this.value);
                }
                else
                {
                    throw new ArgumentException("需要为类型Dictionary<string,NBTTag>:" + value);
                }
            }
        }

        public NBTCompound(string name) : base(name)
        {
            //foreach(NBTTag tag in tags)
            //{
            //    value.Add(tag.Name, tag);
            //}
            //添加未序列化的命令，从而在new语句中后续调用add方法改变字典时也会让命令中的元素发生变化
            data = new Data(new ID("mcsharp:temp"), Path, "set", this.value);
            AddUnserializedCommand(data);
        }

        public override NBTTag this[string index]
        {
            get
            {
                //一有动静我就序列化.jpg
                if (!qwq)
                {
                    //将命令序列化到函数中
                    Serialize(data);
                }
                qwq = true; //对Compound中的元素进行了访问操作。必然完成了new的过程
                foreach (KeyValuePair<string, NBTTag> tag in value.Value)
                {
                    if (tag.Key == index)
                    {
                        return tag.Value;
                    }
                }
                return null;
            }
        }

        internal void Add(NBTTag tag)
        {
            if(tag is NBTCompound qwq)
            {
                qwq.qwq = true; //用于new的NBTTag是没有命令哒，不用考虑序列化问题
            }
            RemoveCommand();
            tag.parentRoot = this;  //父元素设置
            value.Value.Add(tag.Name, tag);
        }

        /// <summary>
        /// 向此NBTCompound中添加一个NBTTag
        /// </summary>
        /// <param name="tag"></param>
        public void Merge(NBTTag tag)
        {
            //一有动静我就序列化.jpg
            if (!qwq)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            qwq = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            tag.parentRoot = this;  //父元素设置
            value.Value.Add(tag.Name, tag);
            DataModifySetFrom(new ID("mcsharp:temp"), Path + "." + tag.Name, new ID("mcsharp:temp"), tag.Path);
        }

        /// <summary>
        /// 将此NBTCompound中的指定项删除
        /// </summary>
        /// <param name="path"></param>
        public void Remove(string path)
        {
            //一有动静我就序列化.jpg
            if (!qwq)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            qwq = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            value.Value[path].parentRoot = null;
            value.Value.Remove(path);
            DataRemove(new ID("mcsharp:temp"), Path + "." + path);
        }
        
        public IEnumerator<NBTTag> GetEnumerator() => value.Value.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.Value.Values.GetEnumerator();

        public override string ToString()
        {
            return Name + ":" + value;
        }
    }
}
