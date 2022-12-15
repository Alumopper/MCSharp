using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 停止声音播放。
    /// <code>
    /// stopsound &lt;targets> [&lt;source>] [&lt;sound>]
    /// </code>
    /// </summary>
    public class Stopsound : Command
    {
        Entity targets;
        Source? source;
        ID sound;

        /// <summary>
        /// 声音来源的枚举。用于命令参数
        /// </summary>
        public enum Source
        {
            master, music, record, weather, block, hostile, neutral, player, ambient, voice, all
        }

        /// <summary>
        /// stopsound &lt;targets> [&lt;source>] [&lt;sound>]]]
        /// </summary>
        /// <param name="targets">指定目标。</param>
        /// <param name="source">指定声音来源。</param>
        /// <param name="sound">指定声音。</param>
        public Stopsound(Entity targets, Source? source = null, ID sound = null)
        {
            this.targets = targets;
            this.source = source;
            this.sound = sound;
        }

        public override string ToString()
        {
            return "stopsound " + targets.ToString() + " " + (Tools.getEnumString(source).Equals("all") ? "*" : Tools.getEnumString(source)) + " " + (sound == null ? "" : sound.ToString());
        }
    }
}
