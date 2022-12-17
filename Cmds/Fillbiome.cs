using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 设置指定区域的生物群系。
    /// <code>
    /// fillbiome [&lt;from>] [&lt;to>] [&lt;biome>]
    /// /fillbiome [&lt;from>] [&lt;to>] [&lt;biome>] replace [&lt;filter>]
    /// </code>
    /// </summary>
    public class Fillbiome : Command
    {
        Pos from;
        Pos to;
        ID biome;
        ID fliter;

        /// <summary>
        /// fillbiome [&lt;from>] [&lt;to>] [&lt;biome>]
        /// </summary>
        public Fillbiome(Pos from = null, Pos to = null, ID biome = null)
        {
            this.from = from;
            this.to = to;
            this.biome = biome;
        }

        public Fillbiome(string replace, Pos from = null, Pos to = null, ID biome = null, ID fliter = null)
        {
            this.from = from;
            this.to = to;
            this.biome = biome;
            this.fliter = fliter;
        }

        public override string ToString()
        {
            if (from == null)
            {
                return "fillbiome";
            }
            else if (to == null)
            {
                return "fillbiome " + from;
            }else if(biome == null)
            {
                return "fillbiome " + from + " " + to;
            }
            else
            {
                return "fillbiome " + from + " " + to + " " + biome;
            }
        }
    }
}
