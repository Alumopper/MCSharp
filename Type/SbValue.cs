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
        public string playerName;
        /// <summary>
        /// 计分板名字
        /// </summary>
        public string objectName;

        public SbValue(string playerName, string objectName)
        {
            this.playerName = playerName;
            this.objectName = objectName;
        }

    }
}
