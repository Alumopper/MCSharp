using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class Vector3<T>
    {
        public T x;
        public T y;
        public T z;

        public Vector3(T x, T y, T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public T this[int i]
        {
            get
            {
                if(i > 2)
                {
                    throw new IndexOutOfRangeException("索引过大: " + i + "。只含有三个元素");
                }
                if (i < 0)
                {
                    throw new IndexOutOfRangeException("索引应当为非负数: " + i);
                }
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                }
                return default;
            }
            set
            {
                if (i > 2)
                {
                    throw new IndexOutOfRangeException("索引过大: " + i + "。只含有三个元素");
                }
                if (i < 0)
                {
                    throw new IndexOutOfRangeException("索引应当为非负数: " + i);
                }
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return x + " " + y + " " + z;   
        }
    }
}
