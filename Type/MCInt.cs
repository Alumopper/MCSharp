using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCsharp.Type
{
    public class MCInt : SbValue
    {
        int value;
        public MCInt(int value) : base(Datapack.name+".intvar."+Datapack.GetID()+"", "MCS_intvar"){}
        public MCInt(String name, int value) : base(Datapack.name+".intvar."+name, "MCS_intvar") { }
    }
}
