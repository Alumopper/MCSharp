using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double this[int i]
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
                return Double.MaxValue;
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
    }
}
