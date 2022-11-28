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
    public class BlockPredicate
    {
        public string pre;

        public BlockPredicate(string pre)
        {
            if (pre.Contains('{'))
            {
                string[] qwq = pre.Split('{');
                string a = qwq[0];  //非nbt
                string b = qwq[1];  //nbt部分
                if (!Regex.IsMatch(a, "^[#]?([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+([\\[][a-z0-9_]+[=][a-z0-9_]+[\\]])*$"))
                {
                    throw new IllegalFormatException("无法解析字符串" + pre + "为方块谓词");
                }
                NBT w = new NBT(b); //尝试
            }
            else
            {
                if (!Regex.IsMatch(pre, "^[#]?([a-z0-9_]+|([a-z0-9_]+[:][a-z0-9_]+))+([\\[][a-z0-9_]+[=][a-z0-9_]+[\\]])*$"))
                {
                    throw new IllegalFormatException("无法解析字符串" + pre + "为方块谓词");
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
