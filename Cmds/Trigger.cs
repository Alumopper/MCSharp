using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 修改一个准则为“触发器”的记分板目标。一般配合原始JSON文本使用，使无命令执行权限的玩家能够激活管理员或地图制作者设计的系统。
    /// <code>
    /// trigger &lt;objective> [(add|set)] [&lt;value>]
    /// </code>
    /// </summary>
    public class Trigger:Command
    {
        SbObject objective;
        As add_set;
        int value;

        public enum As
        {
            add,set
        }

        /// <summary>
        /// trigger &lt;objective> [(add|set)] [&lt;value>]
        /// </summary>
        /// <param name="objective"></param>
        /// <param name="add_set"></param>
        /// <param name="value"></param>
        public Trigger(SbObject objective, As add_set = As.add, int value = 1)
        {
            this.objective = objective;
            this.add_set = add_set;
            this.value = value;
        }

        public override string ToString()
        {
            return "trigger " + objective + (add_set == As.add ? " add " : " set ") + value;
        }
    }
}
