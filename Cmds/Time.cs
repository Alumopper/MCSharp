using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MCSharp.Exception;
using MCSharp.Util;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 更改或查询世界的游戏时间。
    /// <code>
    /// time (add|query|set) &lt;时间>
    /// </code>
    /// </summary>
    public class Time : Command
    {
        int time;
        string time2;
        TimeSpec? spec = null;
        TimeType? timeType = null;

        public enum TimeType
        {
            daytime,gametime,day
        }

        public enum TimeSpec
        {
            day, night, noon, midnight
        }

        /// <summary>
        /// time add &lt;time[t/s/d]>
        /// </summary>
        /// <param name="time"></param>
        /// <param name="type"></param>
        public Time(string time)
        {
            if (!Regex.IsMatch(time, "^[1-9]+[0-9]*[tsd]?$"))
            {
                throw new ArgumentNotMatchException("参数错误: " + time + "。非法的时间值");
            }
            time2 = time;    
        }

        /// <summary>
        /// time set &lt;time>
        /// </summary>
        /// <param name="time"></param>
        public Time(int time)
        {
            this.time = time;
        }

        /// <summary>
        /// time add &lt;timeSpec>
        /// </summary>
        /// <param name="timeSpec">day, night, noon, midnight</param>
        public Time(TimeSpec timeSpec)
        {
            this.spec = timeSpec;
        }

        /// <summary>
        /// time query &lt;timeType>
        /// </summary>
        /// <param name="timeType">daytime,gametime,day</param>
        public Time(TimeType timeType)
        {
            this.timeType = timeType;
        }

        public override string ToString()
        {
            if(time2 != null)
            {
                return "time add " + time2;
            }else if(timeType != null)
            {
                return "time query " + Tools.getEnumString(timeType);
            }else if(spec != null)
            {
                return "time set " + Tools.getEnumString(spec);
            }
            else
            {
                return "time set " + time; 
            }
        }
    }
}
