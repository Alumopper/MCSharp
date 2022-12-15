using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type.CommandArg
{
    public class IntRange
    {
        int? max;
        int? min;

        public IntRange(int? min, int? max)
        {
            this.min = min;
            this.max = max;
            if(min == null && max == null)
            {
                throw new ArgumentException("最大值和最小值不能同时为空。");
            }
        }

        public bool InRange(int x)
        {
            if (min != null && x < min)
                return false;
            if (max != null && x > max)
                return false;
            return true;
        }

        public override string ToString()
        {
            if (min == null)
            {
                return ".." + max;
            }else if(max == null)
            {
                return min + "..";
            }
            else
            {
                return min + ".." + max;
            }
        }
    }
}
