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
    /// </code>
    /// </summary>
    public class Fillbiome : Command
    {
        Pos from;
        Pos to;
        ID biome;

        /// <summary>
        /// fillbiome [&lt;from>] [&lt;to>] [&lt;biome>]
        /// </summary>
        public Fillbiome(Pos from, Pos to, ID biome)
        {
            this.from = from;
            this.to = to;
            this.biome = biome;
        }

        public override string ToString()
        {
            return "fillbiome " + from + " " + to + " " + biome;
        }
    }
}
