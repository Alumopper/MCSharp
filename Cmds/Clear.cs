using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 清除玩家物品栏的物品。
    /// <code>
    /// clear [&lt;targets>] [&lt;item>] [&lt;maxCount>]
    /// </code>
    /// </summary>
    public class Clear : Command
    {
        Entity targets;
        ID item;
        int maxCount = -1;

        public Clear(Entity targets)
        {
            this.targets = targets;
        }

        public Clear(Entity targets, ID item)
        {
            this.targets = targets;
            this.item = item;
        }

        public Clear(Entity targets, ID item, int maxCount)
        {
            this.targets = targets;
            this.item = item;
            if(maxCount < 0)
            {
                DatapackInfo.log.AddLog(Util.Log.Level.ERROR, "maxCount(" + maxCount + ")必须为非负数");
                this.maxCount = 0;
            }
            else
            {
                this.maxCount = maxCount;
            }
        }

        public override string ToString()
        {
            string re = "clear " + targets;
            if (item != null)
            {
                re += " " + item;
                if( maxCount != -1)
                {
                    re += " " + maxCount;
                }
            }
            return re;
        }
    }
}
