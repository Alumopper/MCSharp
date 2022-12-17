using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 强制使区块不断加载
    /// <code>
    /// forceload add &lt;from> [&lt;to>]
    /// forceload remove &lt;from> [&lt;to>]
    /// forceload remove all
    /// forceload query [&lt;pos>]
    /// </code>
    /// </summary>
    public class Forceload : Command
    {
        string add_remove;
        Pos from;
        Pos to;
        Pos pos;
        bool qwq;

        private static string[] ar = new string[] { "add", "remove" };

        /// <summary>
        /// forceload （add|remove) &lt;from> [&lt;to>]
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Forceload(string add_remove, Pos from, Pos to)
        {
            if (!ar.Contains(add_remove))
            {
                throw new ArgumentNotMatchException("参数错误:" + add_remove + "。应当为\"add\"或\"remove\"");
            }
            this.add_remove = add_remove;
            this.from = from;
            this.to = to;
        }

        /// <summary>
        /// forceload query [&lt;pos>]
        /// </summary>
        public Forceload(string query, Pos pos = null)
        {
            this.pos = pos;
        }

        /// <summary>
        /// forceload remove all
        /// </summary>
        public Forceload() 
        {
            qwq = true;
        }

        public override string ToString()
        {
            if(from != null)
            {
                return "forceload " + add_remove + " " + from + (to == null ? "" : (" " + to));
            }else if (qwq)
            {
                return "forceload remove all";
            }
            else
            {
                return "forceload query" + (pos == null ? "" : " " + pos);
            }
        }
    }
}
