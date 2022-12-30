using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class BlockInfo: DataArg
    {
        Pos pos;
        public Pos Position
        {
            get
            {
                return pos;
            }
        }
    }
}
