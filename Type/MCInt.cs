using MCSharp.Cmds;
using MCSharp.Util;
using System;

namespace MCSharp.Type
{
    /// <summary>
    /// 整数，用于计算。实质为计分板的值
    /// </summary>
    public class MCInt : SbValue, MCType
    {
        public MCInt(int value)
        {
            this.playerName = DatapackInfo.name + ".intvar." + GetHashCode();
            this.@object = SbObject.MCS_intvar;
            this.value = value;
            Commands.SbPlayerSet(playerName, SbObject.MCS_intvar, value);
        }

        public MCInt(string name, int value = 0) : base(value, DatapackInfo.name + ".intvar." + name, SbObject.MCS_intvar) { }

        public MCInt(SbValue x, string name = null)
        {
            this.@object = SbObject.MCS_intvar;
            this.playerName = name == null ? Guid.NewGuid().ToString("N") : name;
            this.value = x.value;
            Commands.SbPlayerSet(playerName, SbObject.MCS_intvar, value == null ? 0 : value.Value);
            Commands.SbPlayerOperation(this, "=", x);
        }

        public MCInt Set(SbValue x)
        {
            this.value = x.value;
            Commands.SbPlayerOperation(this, "=", x);
            return this;
        }

        public static implicit operator MCInt(int x)
        {
            return new MCInt(x);
        }
    }
}
