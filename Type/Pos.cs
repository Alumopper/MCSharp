using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class Pos : Vector3<double>
    {
        bool related;

        public Pos(double x = 0,double y = 0,double z = 0, bool related = false) : base(x,y,z)
        {
            this.related = related;
        }
    }
}
