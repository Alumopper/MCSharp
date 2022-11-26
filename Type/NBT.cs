using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class NBT
    {

        public static string[] attributes = new string[]
        {
            "generic.max_health",
            "generic.follow_range",
            "generic.knockback_resistance",
            "generic.movement_speed",
            "generic.attack_damage",
            "generic.attack_knockback",
            "generic.armor",
            "generic.armor_toughness"
        };

        /// <summary>
        /// 检查一个nbt路径是否合法
        /// </summary>
        /// <param name="path">一个nbt路径</param>
        public static bool IsLegalPath(string path)
        {
            string[] paths = path.Split('.');
            foreach(string i in paths)
            {
                if(!Regex.IsMatch(i, "^[a-zA-Z0-9_]+([\\[](([0-9]+)|([\"][a-zA-Z_]+[\"]))[\\]])*$") || i == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
