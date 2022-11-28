using MCSharp.Exception;
using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 管理玩家及其他实体上的状态效果
    /// <code>
    /// effect clear [&lt;targets>] [&lt;effect>]
    /// effect give &lt;targets> &lt;effect> [&lt;seconds>] [&lt;amplifier>] [&lt;hideParticles>]
    /// </code>
    /// </summary>
    public class Effect : Command
    {
        string clear_give;
        Entity targets;
        ID effect;
        int seconds = -1;
        int amplifier = -1;
        bool hideParticles = false;

        private static string[] cg = new string[] { "clear", "give" };

        /// <summary>
        /// effect clear [&lt;targets>] [&lt;effect>]
        /// effect give &lt;targets> &lt;effect>
        /// </summary>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Effect(string clear_give, Entity targets, ID effect)
        {
            this.clear_give = clear_give;
            if(clear_give.Equals("give") && (targets == null || effect == null))
            {
                throw new ArgumentNotMatchException("参数错误: effect give中target和effect不能为null");
            }
            if(targets == null && effect != null)
            {
                throw new ArgumentNotMatchException("参数错误: 不能在没有targets的情况下指定effect");
            }
            this.targets = targets;
            this.effect = effect;
        }

        /// <summary>
        /// effect give &lt;targets> &lt;effect> &lt;seconds>
        /// </summary>
        public Effect(Entity targets, ID effect, int seconds)
        {
            this.targets = targets;
            this.effect = effect;
            if(seconds < 0)
            {
                seconds = 0;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~1000000之间，却传入了" + seconds);
            }
            if (seconds > 1000000)
            {
                seconds = 1000000;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~1000000之间，却传入了" + seconds);
            }
            this.seconds = seconds;
        }

        /// <summary>
        /// effect give &lt;targets> &lt;effect> &lt;seconds> &lt;amplifier>
        /// </summary>
        /// <param name="amplifier"></param>
        public Effect(Entity targets, ID effect, int seconds, int amplifier)
        {
            this.targets = targets;
            this.effect = effect;
            if (seconds < 0)
            {
                seconds = 0;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~1000000之间，却传入了" + seconds);
            }
            if (seconds > 1000000)
            {
                seconds = 1000000;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~1000000之间，却传入了" + seconds);
            }
            this.seconds = seconds;
            if (amplifier < 0)
            {
                amplifier = 0;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~255之间，却传入了" + amplifier);
            }
            if (amplifier > 255)
            {
                amplifier = 255;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~255，却传入了" + amplifier);
            }
            this.seconds = amplifier;
        }

        /// <summary>
        /// effect give &lt;targets> &lt;effect> &lt;seconds> &lt;amplifier> &lt;hideParticles>
        /// </summary>
        public Effect(Entity targets, ID effect, int seconds, int amplifier, bool hideParticles)
        {
            this.targets = targets;
            this.effect = effect;
            if (seconds < 0)
            {
                seconds = 0;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~1000000之间，却传入了" + seconds);
            }
            if (seconds > 1000000)
            {
                seconds = 1000000;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~1000000之间，却传入了" + seconds);
            }
            this.seconds = seconds;
            if (amplifier < 0)
            {
                amplifier = 0;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~255之间，却传入了" + amplifier);
            }
            if (amplifier > 255)
            {
                amplifier = 255;
                DatapackInfo.log.AddLog(Util.Log.Level.WARN, "参数需在0~255，却传入了" + amplifier);
            }
            this.seconds = amplifier;
            this.hideParticles = hideParticles;
        }

        public override string ToString()
        {
            string re = "#喵喵喵？这里应该是一个effect命令，如果你看到了这个注释，说明MC#出现了一些问题！";
            if (clear_give.Equals("clear"))
            {
                re = "effect clear" + (targets == null ? "" : (" " + targets)) + (effect == null ? "" : (" " + effect));
            } else
            {
                re = "effect give " + targets + " " + effect + "" + (seconds == -1 ? " 30" : (" " + seconds)) + (amplifier == -1 ? " 0" : (" " + amplifier)) + hideParticles;
            }
            return re;
        }

    }
}
