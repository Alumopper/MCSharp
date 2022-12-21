using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;
using System.IO;

namespace MCSharp
{
    //函数标签
    public class FunctionTag
    {
        ID tag;

        public List<string> functionNames;
        public string[] values
        {
            get
            {
                return functionNames.ToArray();
            }
            set
            {
                values = value;
            }
        }

        /// <summary>
        /// 根据命名空间id创建一个函数标签
        /// </summary>
        /// <param name="tag"></param>
        public FunctionTag(ID tag)
        {
            this.tag = tag;
            functionNames = new List<string>();
        }

        /// <summary>
        /// 创建这个函数标签的文件
        /// </summary>
        /// <param name="path">数据包的根路径</param>
        public void CreateFunctionTag(string path)
        {
            string tagPath = path + "\\" + DatapackInfo.name + "\\data\\" + tag.@namespace + "\\tags\\functions\\";
            if (!Directory.Exists(tagPath))
            {
                Directory.CreateDirectory(tagPath);
            }
            tagPath += tag.name + ".json";
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
            DatapackInfo.log.AddLog(Util.Log.Level.DEBUG, "文件" + tagPath);
            File.WriteAllText(tagPath, json);
        }

        public override bool Equals(object obj)
        {
            if (obj is FunctionTag)
            {
                return tag.Equals(((FunctionTag)obj).tag);
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return tag.ToString();
        }
    }
}
