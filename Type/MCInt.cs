using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class MCInt : SbValue
    {
        int value;
        public MCInt(int value) : base(Datapack.name + ".intvar." + "", "MCS_intvar") { }
        public MCInt(string name, int value) : base(Datapack.name + ".intvar." + name, "MCS_intvar") { }
    }
}
