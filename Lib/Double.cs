using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Lib
{
    public class Double
    {
        double value;

        public double Value
        {
            get => value;
            set => this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public Double(double value)
        {
            this.value = value;
        }
        
        public static implicit operator Double(double value)
        {
            return new Double(value);
        }

        public static implicit operator double(Double value)
        {
            return value.value;
        }
    }
}
