using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type.CommandArg
{
    /// <summary>
    /// 代表某类方块状态的判据。
    /// 精确匹配某种方块状态，或者包含指定NBT的方块实体NBT。不能使用标签。
    /// <para>一些例子</para>
    /// <list type="bullet">
    /// <item>stone</item>
    /// <item>minecraft:stone</item>
    /// <item>stone[foo=bar]</item>
    /// <item>foo{bar:baz}</item>
    /// </list>
    /// 注意，例子中使用的方块状态，方块id或者方块nbt并不一定是游戏中实际存在的，仅用于格式参考。
    /// </summary>
    public class BlockState
    {
        /// <summary>
        /// 能直接被Minecraft解析的方块状态。
        /// </summary>
        public string pre;

        public BlockState(string pre)
        {
            if (pre.Contains('{'))
            {
                string[] qwq = pre.Split('{');
                string a = qwq[0];  //非nbt
                string b = qwq[1];  //nbt部分
                if (!Regex.IsMatch(a, "^([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+([\\[][a-z0-9_]+[=][a-z0-9_]+[\\]])*$"))
                {
                    throw new IllegalFormatException("无法解析字符串" + pre + "为方块状态");
                }
                NBT w = new NBT(b); //尝试
            }
            else
            {
                if (!Regex.IsMatch(pre, "^([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+([\\[][a-z0-9_]+[=][a-z0-9_]+[\\]])*$"))
                {
                    throw new IllegalFormatException("无法解析字符串" + pre + "为方块状态");
                }
            }
            this.pre = pre;
        }

        public override string ToString()
        {
            return pre;
        }
    }
}
