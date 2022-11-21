using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Util
{
    public class U
    {
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
    }
}
