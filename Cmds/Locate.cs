using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 在聊天框中为命令执行者显示给定类型结构、生物群系或兴趣点的最近坐标和距离。返回的坐标可以点击以自动在聊天框中输入/tp @s 坐标。
    /// <code>
    /// locate (biome|poi|structure) &lt;id>
    /// </code>
    /// </summary>
    public class Locate : Command
    {
        string biome_poi_structure;
        ID id;

        private static string[] bps = new string[] { "biome", "poi", "structure" };
        
        /// <summary>
        /// locate (biome|poi|structure) &lt;id>
        /// </summary>
        public Locate(string biome_poi_structure, ID id)
        {
            if (!bps.Contains(biome_poi_structure))
            {
                throw new ArgumentNotMatchException("参数错误:" + biome_poi_structure + "。应当为\"biome\", \"poi\"或\"structure\"");
            }
            this.biome_poi_structure = biome_poi_structure;
            this.id = id;
        }

        public override string ToString()
        {
            return "locate " + biome_poi_structure + " " + id;
        }
    }
}
