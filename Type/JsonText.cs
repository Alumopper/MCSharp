using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 一段Json原始文本
    /// </summary>
    public class JsonText
    {
        public JsonObject root = new JsonObject();

        public JsonText(string text)
        {
            root["text"] = text;
        }

        public override string ToString()
        {
            return root.ToJsonString();
        }
    }
}
