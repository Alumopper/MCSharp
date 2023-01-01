using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 用于更改或读取属性
    /// <code>
    /// attribute &lt;target&gt; &lt;attribute&gt; base get &lt;scale&gt;
    /// attribute &lt;target&gt; &lt;attribute&gt; base set &lt;value&gt;
    /// attribute &lt;target&gt; &lt;attribute&gt; modifier add &lt;uuid&gt; &lt;name&gt; &lt;value&gt; (add|multiply|multiply_base)
    /// attribute &lt;target&gt; &lt;attribute&gt; modifier remove &lt;uuid&gt;
    /// attribute &lt;target&gt; &lt;attribute&gt; modifier value get &lt;uuid&gt; &lt;scale&gt;
    /// </code>
    /// </summary>
    public class Attribute : Command
    {
        #region 变量
        Selector target;
        string attribute;
        double scale;
        int type;
        double value;
        UUID uuid;
        string name;
        string add_multiply_multiply_base;

        private static string[] amb = new string[] { "add", "multiply", "multiply_base" };
        private static string[] gs = new string[] { "get", "set" };
        #endregion

        #region 构造方法
        /// <summary>
        /// attribute &lt;target&gt; &lt;attribute&gt; base get [&lt;scale];
        /// </summary>
        /// <param name="target"></param>
        /// <param name="attribute"></param>
        /// <param name="scale"></param>
        public Attribute(Selector target, string attribute, double scale = 1.0)
        {
            this.target = target;
            this.attribute = attribute;
            this.scale = scale;
            type = -1;
        }

        /// <summary>
        /// attribute &lt;target&gt; &lt;attribute&gt; base (get|set) &lt;scale/value&gt;
        /// </summary>
        /// type - 0
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Attribute(Selector target, string attribute, string get_set, double scale_value)
        {
            this.target = target;
            if (NBTTag.attributes.Contains(attribute))
            {
                this.attribute = attribute;
            }
            else
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "未知属性" + attribute);
            }
            if (!get_set.Contains(get_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + get_set + "。应当为\"get\", \"set\"。");
            }
            if (get_set.Equals("get"))
            {
                this.scale = scale_value;
                this.type = 0;
            }
            else
            {
                this.value = scale_value;
                this.type = 1;
            }
        }

        /// <summary>
        /// attribute &lt;target&gt; &lt;attribute&gt; modifier add &lt;uuid&gt; &lt;name&gt; &lt;value&gt; (add|multiply|multiply_base)
        /// </summary>
        /// type - 4
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Attribute(Selector target,string attribute, UUID uuid, string name, double value, string add_multiply_multiply_base)
        {
            this.target = target;
            if (NBTTag.attributes.Contains(attribute))
            {
                this.attribute = attribute;
            }
            else
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "未知属性" + attribute);
            }
            this.uuid = uuid;
            if (!ID.IsLegal(name))
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "不是合法的命名空间id:" + name);
            }
            this.name = name;
            this.value = value;
            if (!amb.Contains(add_multiply_multiply_base))
            {
                throw new ArgumentNotMatchException("参数错误:" + uuid + "。应当为\"add\", \"multiply\"或\"multiply_base\"");
            }
            this.add_multiply_multiply_base = add_multiply_multiply_base;
            this.type = 4;
        }

        /// <summary>
        /// attribute &lt;target&gt; &lt;attribute&gt; modifier remove &lt;uuid&gt;
        /// </summary>
        /// type - 5
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Attribute(Selector target,string attribute, UUID uuid)
        {
            this.target = target;
            if (NBTTag.attributes.Contains(attribute))
            {
                this.attribute = attribute;
            }
            else
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "未知属性" + attribute);
            }
            this.uuid = uuid;
            this.type = 5;
        }

        /// <summary>
        /// attribute &lt;target&gt; &lt;attribute&gt; modifier value get &lt;uuid&gt; &lt;scale&gt;
        /// </summary>
        /// type - 6
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Attribute(Selector target,string attribute, UUID uuid, double scale)
        {
            this.target = target;
            if (NBTTag.attributes.Contains(attribute))
            {
                this.attribute = attribute;
            }
            else
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "未知属性" + attribute);
            }
            this.uuid = uuid;
            this.scale = scale;
            this.type = 6;
        }

        #endregion

        public override string ToString()
        {
            string re = "#喵喵喵？这里应该是一个attribute命令，如果你看到了这个注释，说明MC#出现了一些问题！";
            switch (type)
            {
                case -1:
                    {
                        //attribute <target> <attribute> get [<scale>]
                        re = "attribute " + target + " " + attribute + " get " + scale;
                        break;
                    }
                case 0:
                    {
                        //attribute <target> <attribute> [base] get [<scale>]
                        re = "attribute " + target + " " + attribute + " base get " + scale;
                        break;
                    }
                case 1:
                    {
                        //attribute <target> <attribute> base set <value>
                        re = "attribute " + target + " " + attribute + " base set " + value;
                        break;
                    }
                case 4:
                    {
                        //attribute <target> <attribute> modifier add <uuid> <name> <value> (add|multiply|multiply_base)
                        re = "attribute " + target + " " + attribute + " modifier add " + uuid + " " + name + " " + value + " " + add_multiply_multiply_base;
                        break;
                    }
                case 5:
                    {
                        //attribute <target> <attribute> modifier remove <uuid>
                        re = "attribute " + target + " " + attribute + " modifier remove " + uuid;
                        break;
                    }
                case 6:
                    {
                        //attribute <target> <attribute> modifier value get <uuid> <scale>
                        re = "attribute " + target + " " + attribute + " modifier value get " + uuid + " " + scale;
                        break;
                    }
            }
            return re;
        }
    }
}
