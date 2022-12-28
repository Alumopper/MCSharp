using System.Collections.Generic;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Type
{
    public class NBTElement<T>
    {
        private T element;
        public T Value
        {
            get => element;
            set
            {
                element = value;
            }
        }
        
        internal NBTElement(T element)
        {
            this.element = element;
        }

        internal NBTElement() { }

        public static implicit operator T(NBTElement<T> element)
        {
            return element.Value;
        }

        public static implicit operator NBTElement<T>(T element)
        {
            return new NBTElement<T>(element);
        }

        /// <summary>
        /// 从数组生成一个NBTListElement列表
        /// </summary>
        /// <param name="element">包含此元素的数组</param>
        /// <returns></returns>
        internal static List<NBTElement<T>> ToList(T[] element)
        {
            List<NBTElement<T>> result = new List<NBTElement<T>>();
            foreach (T t in element)
            {
                result.Add(new NBTElement<T>(t));
            }
            return result;
        }

        public override string ToString()
        {
            if (element is string)
            {
                return "\"" + element + "\"";
            }
            else if(element is double)
            {
                return element + "d";
            }
            else if(element is List<int> element1)
            {
                string re = "[I;";
                foreach(int i in element1)
                {
                    re += i + ",";
                }
                re = re.Substring(0, re.Length - 1) + "]";
                return re;
            }else if(element is Dictionary<string, NBTTag> dic)
            {
                string result = "{";
                foreach (NBTTag i in dic.Values)
                {
                    result += i.ToString() + ",";
                }
                result = result.Substring(0, result.Length - 1);
                result += "}";
                return result;
            }
            else
            {
                return element.ToString();
            }
        }
    }
}
