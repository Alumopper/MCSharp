using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class SbValue
    {
        /// <summary>
        /// 值
        /// </summary>
        public int value;
        /// <summary>
        /// 计分对象的名字
        /// </summary>
        public string playerName;
        /// <summary>
        /// 计分板名字
        /// </summary>
        public SbObject @object;

        public SbValue(int value, string playerName, SbObject @object)
        {
            this.value = value;
            this.playerName = playerName;
            this.@object = @object;
        }

    }
}
