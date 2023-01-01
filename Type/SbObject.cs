using MCSharp.Attribute;
using MCSharp.Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 一个计分板对象。
    /// </summary>
    [Inline]
    public class SbObject
    {
        public string name;
        public string rule;
        public JsonText display;

        /// <summary>
        /// MCSharp数学计算使用的计分板对象。
        /// </summary>
        public static SbObject MCS_intvar;

        /// <summary>
        /// MCSharp默认的计分板变量
        /// </summary>
        public static SbObject MCS_default;

        public SbObject(string name, string rule = "dummy", JsonText display = null)
        {
            this.name = name.ToLower();
            this.rule = rule.ToLower();
            this.display = display;
            //命令执行
            Commands.SbObjectAdd(this, this.rule, display);
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            return obj is SbObject @object &&
                   name == @object.name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }
    }
}
