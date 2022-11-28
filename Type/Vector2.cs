using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class Vector2<T>
    {
        public T x;
        public T y;

        public Vector2(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        public T this[int i]
        {
            get
            {
                if (i > 1)
                {
                    throw new IndexOutOfRangeException("索引过大: " + i + "。只含有两个元素");
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
                }
                return default;
            }
            set
            {
                if (i > 1)
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
                }
            }
        }
    }
}
