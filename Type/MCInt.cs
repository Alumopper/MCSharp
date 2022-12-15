using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 整数，用于计算。实质为计分板的值
    /// </summary>
    public class MCInt : SbValue
    {
        int value;
        public MCInt(int value) : base(value, DatapackInfo.name + ".intvar." + "", SbObject.MCS_intvar) { }
        public MCInt(string name, int value) : base(value, DatapackInfo.name + ".intvar." + name, SbObject.MCS_intvar) { }
    }
}
