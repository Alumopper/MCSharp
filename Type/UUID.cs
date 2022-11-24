using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    public class UUID
    {
        string uuid;

        public static bool IsLegal(string str)
        {
            return Regex.IsMatch(str, "[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}");
        }

        public UUID(string uuid)
        {
            if (!IsLegal(uuid))
            {
                throw new IllegalUUIDException("不合法的UUID:" + uuid);
            }
            this.uuid = uuid;
        }

        public override string ToString()
        {
            return uuid;
        }
    }
}
