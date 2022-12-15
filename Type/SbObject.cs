using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 一个计分板对象。
    /// </summary>
    public class SbObject
    {
        public string name;
        public string rule;

        /// <summary>
        /// MCSharp数学计算使用的计分板对象。
        /// </summary>
        public static readonly SbObject MCS_intvar = new SbObject("MCS_intvar");

        public SbObject(string name)
        {
            this.name = name;
        }
    }
}
