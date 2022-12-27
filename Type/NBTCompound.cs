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
        Dictionary<string,NBTTag> value = new Dictionary<string, NBTTag>();
        bool qwq = false;   //new的过程是否已经完毕
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
                    DataModifySet(new ID("mcsharp:temp"), nbtPath ?? IndexName, this);
                    nbtPath = null;
                }
                else
                {
                    throw new ArgumentException("需要为类型Dictionary<string,NBTTag>:" + value);
                }
            }
        }

        public override string ValueString()
        {
            string result = "{";
            foreach (NBTTag i in value.Values)
            {
                result += i.ToString() + ",";
            }
            result = result.Substring(0, result.Length - 1);
            result += "}";
            return result;
        }

        public NBTCompound(string name) : base(name)
        {
            //foreach(NBTTag tag in tags)
            //{
            //    value.Add(tag.Name, tag);
            //}
            //添加未序列化的命令，从而在new语句中后续调用add方法改变字典时也会让命令中的元素发生变化
            data = new Data(new ID("mcsharp:temp"), nbtPath??IndexName, "set", this);
            AddUnserializedCommand(data);
        }

        

        public NBTTag this[string index]
        {
            get
            {
                foreach (KeyValuePair<string, NBTTag> tag in value)
                {
                    if (tag.Key == index)
                    {
                        //进行了一次调用，记录
                        if(nbtPath == null)
                        {
                            //没有嵌套过，这个是根标签
                            nbtPath = IndexName + "." + index;
                        }
                        else
                        {
                            nbtPath += "." + index;
                        }
                        return tag.Value;
                    }
                }
                return null;
            }
        }

        internal void Add(NBTTag tag)
        {
            RemoveCommand();
            value.Add(tag.Name, tag);
        }

        /// <summary>
        /// 向此NBTCompound中添加一个NBTTag
        /// </summary>
        /// <param name="tag"></param>
        public void Append(NBTTag tag)
        {
            //一有动静我就序列化.jpg
            if (!qwq)
            {
                //将命令序列化到函数中
                Serialize(data);
            }
            qwq = true; //对Compound中的元素进行了添加操作。必然完成了new的过程
            value.Add(tag.Name, tag);
            DataModifySetFrom(new ID("mcsharp:temp"), IndexName + "." + tag.Name, new ID("mcsharp:temp"), tag.IndexName);
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
            value.Remove(path);
            DataRemove(new ID("mcsharp:temp"), IndexName + "." + path);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<NBTTag> GetEnumerator() => value.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.Values.GetEnumerator();

        public override string ToString()
        {
            return Name + ":" + ValueString();
        }
    }
}
