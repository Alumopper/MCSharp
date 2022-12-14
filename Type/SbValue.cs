using MCSharp.Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MCSharp.Attribute;

namespace MCSharp.Type
{

    [Inline]
    public class SbValue : MCType
    {
        /// <summary>
        /// 值
        /// </summary>
        public int? value = null;
        /// <summary>
        /// 计分对象的名字
        /// </summary>
        public string playerName;
        /// <summary>
        /// 计分板名字
        /// </summary>
        public SbObject @object;

        public SbValue() {}

        public SbValue(int value, string playerName, SbObject @object = null)
        {
            this.value = value;
            this.playerName = playerName;
            if(@object == null)
            {
                this.@object = SbObject.MCS_default;
            }
            else
            {
                this.@object = @object;
            }
            //命令
            Commands.SbPlayerSet(this, value);
        }

        public SbValue(string playerName, SbObject @object = null)
        {
            this.playerName = playerName;
            if (@object == null)
            {
                this.@object = SbObject.MCS_default;
            }
            else
            {
                this.@object = @object;
            }
            //命令
            Commands.SbPlayerSet(this, 0);
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="sbValue">需要被设置为的值</param>
        public SbValue Set(SbValue sbValue)
        {
            this.value = sbValue.value;
            Commands.SbPlayerOperation(this, "=", sbValue);
            return this;
        }

        public override bool Equals(object obj)
        {
            return obj is SbValue value &&
                   playerName == value.playerName &&
                   EqualityComparer<SbObject>.Default.Equals(@object, value.@object);
        }

        public override int GetHashCode()
        {
            int hashCode = -1402998315;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(playerName);
            hashCode = hashCode * -1521134295 + EqualityComparer<SbObject>.Default.GetHashCode(@object);
            return hashCode;
        }

        public static SbValue operator+ (SbValue a, SbValue b)
        {
            SbValue qwq = new SbValue(0, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "=", a);
            Commands.SbPlayerOperation(qwq, "+=", b);
            return qwq;
        }

        public static SbValue operator -(SbValue a, SbValue b)
        {
            SbValue qwq = new SbValue(0, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "=", a);
            Commands.SbPlayerOperation(qwq, "-=", b);
            return qwq;
        }

        public static SbValue operator *(SbValue a, SbValue b)
        {
            SbValue qwq = new SbValue(0, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "=", a);
            Commands.SbPlayerOperation(qwq, "*=", b);
            return qwq;
        }

        public static SbValue operator /(SbValue a, SbValue b)
        {
            SbValue qwq = new SbValue(0, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "=", a);
            Commands.SbPlayerOperation(qwq, "/=", b);
            return qwq;
        }

        public static SbValue operator %(SbValue a, SbValue b)
        {
            SbValue qwq = new SbValue(0, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "=", a);
            Commands.SbPlayerOperation(qwq, "%=", b);
            return qwq;
        }
        
        public static SbValue operator +(SbValue a, int b)
        {
            SbValue qwq = new SbValue(b, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "+=", a);
            return qwq;
        }

        public static SbValue operator -(SbValue a, int b)
        {
            SbValue qwq = new SbValue(b, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "-=", a);
            return qwq;
        }

        public static SbValue operator *(SbValue a, int b)
        {
            SbValue qwq = new SbValue(b, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "*=", a);
            return qwq;
        }

        public static SbValue operator /(SbValue a, int b)
        {
            SbValue qwq = new SbValue(b, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "/=", a);
            return qwq;
        }

        public static SbValue operator %(SbValue a, int b)
        {
            SbValue qwq = new SbValue(b, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "%=", a);
            return qwq;
        }

        public static SbValue operator +(int a, SbValue b)
        {
            SbValue qwq = new SbValue(a, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "+=", b);
            return qwq;
        }
        
        public static SbValue operator -(int a, SbValue b)
        {
            SbValue qwq = new SbValue(a, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "-=", b);
            return qwq;
        }
        
        public static SbValue operator *(int a, SbValue b)
        {
            SbValue qwq = new SbValue(a, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "*=", b);
            return qwq;
        }
        
        public static SbValue operator /(int a, SbValue b)
        {
            SbValue qwq = new SbValue(a, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "/=", b);
            return qwq;
        }

        public static SbValue operator %(int a, SbValue b)
        {
            SbValue qwq = new SbValue(a, Guid.NewGuid().ToString("N"));
            Commands.SbPlayerOperation(qwq, "%=", b);
            return qwq;
        }

    }
}
