using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class NBTList<T> : NBTTag, IEnumerable<NBTElement<T>> where T : NBTTag 
    {
        List<NBTElement<T>> value = new List<NBTElement<T>>();
        public int IndexOf(T item)
        {
            return value.IndexOf(item);
        }
        
        public IEnumerator<NBTElement<T>> GetEnumerator() => value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => value.GetEnumerator();
    }
}
