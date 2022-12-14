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
    /// 代表世界中某类方块的判据。
    /// 检查方块状态属性和（方块实体）NBTTag数据。允许用方块标签筛选方块类型。
    /// <para>
    /// 一些例子:
    /// <list type="bullet">
    /// <item>stone</item>
    /// <item>minecraft:stone</item>
    /// <item>stone[foo=bar]</item>
    /// <item>#stone</item>
    /// <item>#stone[foo=bar]{baz:nbt}</item>
    /// </list>
    /// </para>
    /// <seealso cref="BlockState"/>
    /// </summary>
    public class BlockPredicate
    {
        /// <summary>
        /// 能直接被Minecraft解析的方块判据。
        /// </summary>
        public string pre;

        //todo
        public NBTTag nbt;

        /// <summary>
        /// 创建一个方块判据。
        /// </summary>
        /// <param name="pre"></param>
        /// <exception cref="IllegalFormatException"></exception>
        public BlockPredicate(string pre, NBTTag nbt)
        {
            if (!Regex.IsMatch(pre, "^[#]?([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+([\\[][a-z0-9_]+[=][a-z0-9_]+[\\]])*$"))
            {
                throw new IllegalFormatException("无法解析字符串" + pre + "为方块谓词");
            }
            this.pre = pre;
            this.nbt = nbt;
        }

        public override string ToString()
        {
            return pre + "{" + nbt + "}";
        }
    }
}
