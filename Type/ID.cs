using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class ID
    {
        public static bool IsLegal(string str)
        {
            return Regex.IsMatch(str, "[a-z0-9_]*[:]?[a-z0-9_]*");
        }
    }
}