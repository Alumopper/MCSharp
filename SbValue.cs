using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp.Type
{
    public class SbValue
    {
        /// <summary>
        /// 值
        /// </summary>
        public String playerName;
        /// <summary>
        /// 计分板名字
        /// </summary>
        public String objectName;

        public SbValue(String playerName, String objectName)
        {
            this.playerName = playerName;
            this.objectName = objectName;
        }

    }
}
