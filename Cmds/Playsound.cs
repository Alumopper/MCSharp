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
    /// 播放一段声音。
    /// <code>
    /// playsound &lt;sound> &lt;source> &lt;targets> [&lt;pos>] [&lt;volume>] [&lt;pitch>] [&lt;minVolume>]
    /// </code>
    /// </summary>
    public class Playsound : Command
    {
        ID sound;
        Source source;
        Entity targets;
        Pos pos;
        float volume;
        float pitch;
        float minVolume;

        public enum Source
        {
            master,music,record,weather,block,hostile,neutral,player,ambient,voice
        }

        /// <summary>
        /// playsound &lt;sound> &lt;source> &lt;targets> [&lt;pos>] [&lt;volume>] [&lt;pitch>] [&lt;minVolume>]
        /// </summary>
        /// <param name="sound">指定要播放的声音。必须为在sounds.json中被定义的一个声音项目（例如，entity.pig.ambient）。</param>
        /// <param name="source">指定播放声音所属的类别，对应于游戏选项中“音乐和声音”设置的分类。必须为以下之一：master、music、record、weather、block、hostile、neutral、player、ambient或voice。</param>
        /// <param name="targets">指定播放声音的目标。必须是一个玩家名、目标选择器或UUID。且目标选择器只允许玩家</param>
        /// <param name="pos">指定声音发出的方位。</param>
        /// <param name="volume">指定声音能被听见的距离。</param>
        /// <param name="pitch">指定声音的音调。</param>
        /// <param name="minVolume">指定在声音可闻范围外的目标能听到的音量。</param>
        public Playsound(ID sound, Source source, Entity targets, Pos pos = null, float volume = 1.0f, float pitch = 1.0f, float minVolume = 0.0f)
        {
            this.sound = sound;
            this.source = source;
            this.targets = targets;
            this.pos = pos;
            this.volume = volume;
            this.pitch = pitch;
            this.minVolume = minVolume;
        }

        public override string ToString()
        {
            return "playsound " + source + " " + Tools.GetEnumString(source) + " " + targets + " " + pos + " " + volume + " " + pitch + " " + minVolume;
        }
    }
}
