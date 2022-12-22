using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type.CommandArg
{
    /// <summary>
    /// 整数范围，用于判断计分板或者nbt中的数值是否在范围内
    /// </summary>
    public class IntRange
    {
        int? max;
        int? min;

        /// <summary>
        /// 根据最大值和最小值创建一个整数范围。注意最大值和最小值都是可选的，如果不需要某个值，可以传入null，但是不能同时为null
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <exception cref="ArgumentException">若最大值和最小值同时为null或者最大值小于最小值的时候抛出</exception>
        public IntRange(int? min, int? max)
        {
            this.min = min;
            this.max = max;
            if(min == null && max == null)
            {
                throw new ArgumentException("最大值和最小值不能同时为空。");
            }
            if(min != null && max != null && min > max)
            {
                throw new ArgumentException("最大值不能小于最小值。");
            }
        }

        public IntRange(string range)
        {
            //2..   ..2     2..3
            string[] min_max = range.Split('.');
            this.max = min_max[2] == "" ? null : (int?)int.Parse(min_max[2]);
            this.min = min_max[0] == "" ? null : (int?)int.Parse(min_max[0]);
            if(max == null && min == null)
            {
                throw new ArgumentException("最大值和最小值不能同时为空。");
            }
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
