using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Util
{
    /// <summary>
    /// 工具类。杂七杂八的东西都堆在里面的好
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 两个列表在排序和内容上是否相同
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ListEqualBySort<T>(List<T> a,List<T> b)
        {
            if(a.Count == b.Count)
            {
                if (a.Count == 0) return true;
                for(int i = 0;i < a.Count; i++)
                {
                    if (!a[i].Equals(b[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据枚举量的名称获取字符串
        /// </summary>
        /// <param name="qwq"></param>
        /// <returns></returns>
        public static string getEnumString(Enum qwq)
        {
            return Enum.GetName(qwq.GetType(), qwq);
        }
    }
}
