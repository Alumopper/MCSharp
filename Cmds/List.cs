using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 列出在服务器上的玩家。
    /// <code>
    /// list
    /// list uuids
    /// </code>
    /// </summary>
    public class List : Command
    {
        object o;

        /// <summary>
        /// <para> list </para>
        /// list uuids
        /// </summary>
        /// <param name="o">随便填啥。只要不是null就是list uuids</param>
        public List(object o = null)
        {
            this.o = o;
        }

        public override string ToString()
        {
            return "list" + (o == null ? "" : (" uuid"));
        }
    }
}
