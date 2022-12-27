using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using fNbt;

namespace MCSharp.Type
{
    /// <summary>
    /// NBT标签
    /// </summary>
    public class NBT
    {
        /// <summary>
        /// 属性的穷尽字符串数组
        /// </summary>
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
    
        /// <summary>
        /// 反序列化一段nbt字符串，从字符串中解析nbt
        /// </summary>
        /// <param name="nbt"></param>
        /// <returns>反序列化出的nbt字符串</returns>
        public static Storage Prase(string nbt)
        {
            return null;
        }
    
    }
}
