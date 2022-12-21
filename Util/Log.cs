using MCSharp.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Util
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log
    {
        private struct L
        {
            public string msg;
            public Level level;
            public string @class;

            public L(Level level, string msg, string @class)
            {
                this.msg = msg;
                this.level = level;
                this.@class = @class;
            }
        }

        /// <summary>
        /// 日志等级
        /// </summary>
        public enum Level
        {
            DEBUG,
            INFO,
            WARN,
            ERROR
        }

        private Level outputLevel;
        /// <summary>
        /// 日志输出的时候最低会输出的日志等级
        /// </summary>
        public Level Outputlevel
        {
            get
            {
                return outputLevel;
            }
            set
            {
                if(value < Level.DEBUG)
                {
                    outputLevel = Level.DEBUG;
                }else if(value > Level.ERROR)
                {
                    outputLevel = Level.ERROR;
                }
            }
        }

        private ArrayList ls;

        /// <summary>
        /// 新建一个日志对象
        /// </summary>
        public Log()
        {
            ls = new ArrayList();
        }

        /// <summary>
        /// 向此日志对象中添加一行日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="msg"></param>
        public void AddLog(Level level,string msg)
        {
            StackFrame sf = new StackFrame(1);
            ls.Add(new L(level, msg , sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name));
        }

        /// <summary>
        /// 将此日志对象中的日志输出到控制台
        /// </summary>
        public void Print()
        {
            foreach(L l in ls)
            {
                if(l.level >= outputLevel)
                {
                    switch (l.level)
                    {
                        case Level.DEBUG:
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("[DEBUG/");
                                break;
                            }
                        case Level.INFO:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("[INFO/");
                                break;
                            }
                        case Level.WARN:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("[WARN/");
                                break;
                            }
                        case Level.ERROR:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("[ERROR/");
                                break;
                            }
                    }
                    Console.WriteLine(l.@class + "]" + l.msg);
                    Console.ResetColor();
                }
            }
        }
    }
}
