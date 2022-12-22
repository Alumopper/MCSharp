using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type.CommandArg
{
    /// <summary>
    /// 游戏模式，作为命令中设置玩家游戏模式或者判断游戏模式的参数
    /// </summary>
    public enum Gamemodes
    {
        survival,
        creative,
        adventure,
        specture
    }

    public class TGamemode
    {
        public static Gamemodes? GetGamemodes(string mode)
        {
            switch (mode)
            {
                case "survival":
                    return Gamemodes.survival;
                case "creative":
                    return Gamemodes.creative;
                case "adventure":
                    return Gamemodes.adventure;
                case "specture":
                    return Gamemodes.specture;
                default:
                    throw new ArgumentException("无效的游戏模式: " + mode);
            }
        }
    }
}
