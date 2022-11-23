using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 用于更改或读取属性
    /// <code>
    /// attribute &lt;target&gt; &lt;attribute&gt; [base] get [&lt;scale&gt;]
    /// attribute &lt;target&gt; &lt;attribute&gt; base set &lt;value&gt;
    /// attribute &lt;target&gt; &lt;attribute&gt; modifier add &lt;uuid&gt; &lt;name&gt; &lt;value&gt; (add|multiply|multiply_base)
    /// attribute &lt;target&gt; &lt;attribute&gt; modifier remove &lt;uuid&gt;
    /// attribute &lt;target&gt; &lt;attribute&gt; modifier value get &lt;uuid&gt; [&lt;scale&gt;]
    /// </code>
    /// </summary>
    public class Atrribute
    {
        Entity target;
        string attribute;
        double @base;

        public Atrribute(Entity target,string attribute, double @base, string get, params int[] scale)
        {
            this.target = target;
            if (NBT.attributes.Contains(attribute))
            {
                this.attribute = attribute;
            }
            else
            {
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "未知属性" + attribute);
            }
            if(@base < 0)
            {
                throw new ArgumentNotMatchException(@base + "至少应该为正数");
            }
            else
            {
                this.@base = @base;
            }
            if (!get.Equals("get"))
            {
                throw new ArgumentNotMatchException("参数错误:\"" + get + "\"。应该为\"get\"")
            }
            if ()
        }
    }
}
