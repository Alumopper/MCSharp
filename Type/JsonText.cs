using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MCsharp.Type
{
    public class JsonText
    {
        public JsonObject root = new JsonObject();

        public JsonText(String text)
        {
            root["text"] = text;
        }
    }
}
