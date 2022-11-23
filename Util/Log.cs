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
    public class Log
    {
        private struct L
        {
            public string msg;
            public Level level;
            public string @class;
            public int line;

            public L(Level level, string msg, string @class, int line)
            {
                this.msg = msg;
                this.level = level;
                this.@class = @class;
                this.line = line;
            }
        }

        public enum Level
        {
            DEBUG,
            INFO,
            WARN,
            ERROR
        }

        private Level outputLevel;
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

        public Log()
        {
            ls = new ArrayList();
        }

        public void AddLog(Level level,string msg)
        {
            //TODO：判断日志产生文件的地方有误
            StackFrame sf = new StackFrame(1);
            ls.Insert(0,new L(level, msg , sf.GetFileName(), sf.GetFileColumnNumber()));
        }

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
                    Console.WriteLine(l.@class + ":" + l.line + "]" + l.msg);
                    Console.ResetColor();
                }
            }
        }
    }
}
