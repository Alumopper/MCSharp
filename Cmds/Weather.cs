using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 更改游戏中的天气。
    /// <code>
    /// weather (clear|rain|thunder) [&lt;duration>]
    /// </code>
    /// </summary>
    public class Weather : Command
    {
        WeatherType type;
        int duration;


        public enum WeatherType{
            clear,
            rain,
            thunder
        }
        /// <summary>
        /// weather (clear|rain|thunder) [&lt;duration>]
        /// </summary>
        /// <param name="type">指定要更改的天气类型</param>
        /// <param name="duration">指定天气持续的时间，单位为秒，可选</param>
        public Weather(WeatherType type, int duration = 300)
        {
            this.type = type;
            this.duration = duration;
        }

        public override string ToString()
        {
            return "weather " + Tools.GetEnumString(type) + " " + duration;
        }
    }
}
