using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// <c>/data</c>命令允许执行者获取、合并、修改或是移除方块、实体或命令存储的NBT数据。
    /// 
    /// /data有四个子命令（get，merge，modify，remove）。
    /// <code>
    /// data ...
    ///     ... get (block &lt;targetPos>|entity &lt;target>|storage &lt;target>) [&lt;path>] [&lt;scale>]
    ///     获取指定NBT的值。
    ///     ... merge (block &lt;targetPos>|entity &lt;target>|storage &lt;target>) &lt;nbt>
    ///     将指定NBT与&lt;nbt> 合并。
    ///     ... modify (block &lt;targetPos>|entity &lt;target>|storage &lt;target>) &lt;targetPath> ...
    ///     修改指定NBT...
    ///         ...append...
    ///         ...在列表最后插入一个值...
    ///         ...insert &lt;index>...
    ///         ...在列表指定位置插入一个值...
    ///         ...merge...
    ///         ...将指定的复合NBT与另一个值合并...
    ///         ...prepend...
    ///         ...在列表最前面插入一个值...
    ///         ...set...
    ///         ...将NBT覆盖为新的值...
    ///             ...from(block &lt;sourcePos>|entity &lt;source>|storage &lt;source>) [&lt;sourcePath>]
    ///             ...使用指定的方块、实体、或存储的指定NBT。
    ///             ... value &lt;value>
    ///             ...使用 &lt;value>。
    ///     ... remove(block &lt;targetPos>|entity &lt;target>|storage &lt;target>) &lt;path>
    ///     删除指定NBT。
    /// </code>
    /// </summary>
    public class Data : Command
    {
        #region 参数
        Pos targetpos;
        Selector targetentity;
        ID targetid;
        string path;
        double? scale;
        NBTTag nbt;
        string targetPath;
        string append_merge_prepend_set;
        string sourcePath;
        Pos sourcepos;
        Selector sourceentity;
        ID sourceid;
        NBTTag value;
        int index;
        int type;
        #endregion

        private static string[] amps = new string[] { "append", "merge", "prepend", "set" };

        #region get
        /// <summary>
        /// data get block &lt;targetPos> [&lt;path>] [&lt;scale>]
        /// </summary>
        /// type - 0
        public Data(Pos targetpos,string path = null, double? scale = null)
        {
            this.targetpos = targetpos;
            this.path = path;
            this.scale = scale;
            this.type = 0;
        }


        /// <summary>
        /// data get entity &lt;target> [&lt;path>] [&lt;scale>]
        /// </summary>
        /// type - 1
        public Data(Selector target, string path = null, double? scale = null)
        {
            this.targetentity = target;
            this.path = path;
            this.scale = scale;
            type = 1;
        }


        /// <summary>
        /// data get storage &lt;targetPos> [&lt;path>] [&lt;scale>]
        /// </summary>
        /// type - 2
        public Data(ID target, string path = null, double? scale = null)
        {
            this.targetid = target;
            this.path = path;
            this.scale = scale;
            type = 2;
        }

        #endregion

        #region merge
        /// <summary>
        /// data merge &lt;block:targetPos> &lt;nbt>
        /// </summary>
        /// type - 3
        public Data(Pos targetpos, NBTTag nbt)
        {
            this.targetpos = targetpos;
            this.nbt = nbt;
            type = 3;
        }

        /// <summary>
        /// data merge &lt;entity:target> &lt;nbt>
        /// </summary>
        /// type - 4
        public Data(Selector target, NBTTag nbt)
        {
            this.targetentity = target;
            this.nbt = nbt;
            type = 4;
        }

        /// <summary>
        /// data merge &lt;storage:target> &lt;nbt>
        /// </summary>
        /// type - 5
        public Data(ID target, NBTTag nbt)
        {
            this.targetid = target;
            this.nbt = nbt;
            this.type = 5;
        }
        #endregion

        #region modify
        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 6
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, string append_merge_prepend_set, Pos sourcepos, string sourcePath)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourcepos = sourcepos;
            this.sourcePath = sourcePath;
            type = 6;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 7
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, string append_merge_prepend_set, Pos sourcepos, string sourcePath)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourcepos = sourcepos;
            this.sourcePath = sourcePath;
            type = 7;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 8
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, string append_merge_prepend_set, Pos sourcepos, string sourcePath)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourcepos = sourcepos;
            this.sourcePath = sourcePath;
            type = 8;
        }

        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from entity &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 9
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, string append_merge_prepend_set, Selector source, string sourcePath)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourceentity = source;
            this.sourcePath = sourcePath;
            this.type = 9;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> (append|merge|prepend|set) from entity &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 10
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, string append_merge_prepend_set, Selector source, string sourcePath)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourceentity = source;
            this.sourcePath = sourcePath;
            type = 10;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> (append|merge|prepend|set) from entity &lt;source>
        /// </summary>
        /// type - 11
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, string append_merge_prepend_set, Selector source, string sourcePath)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourceentity = source;
            this.sourcePath = sourcePath;
            type = 11;
        }


        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from storage &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 12
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, string append_merge_prepend_set, ID source, string sourcePath)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourceid = source;
            this.sourcePath = sourcePath;
            type = 12;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> (append|merge|prepend|set) from storage &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 13
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, string append_merge_prepend_set, ID source, string sourcePath)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourceid = source;
            this.sourcePath = sourcePath;
            type = 13;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> (append|merge|prepend|set) from storage &lt;source>
        /// </summary>
        /// type - 14
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, string append_merge_prepend_set, ID source, string sourcePath)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.sourceid = source;
            this.sourcePath = sourcePath;
            type = 14;
        }

        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) value &lt;value>
        /// </summary>
        /// type - 15
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, string append_merge_prepend_set, NBTTag value)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.value = value;
            type = 15;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> (append|merge|prepend|set) value &lt;value>
        /// </summary>
        /// type - 16
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, string append_merge_prepend_set, NBTTag value)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.value = value;
            type = 16;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> (append|merge|prepend|set) value &lt;value>
        /// </summary>
        /// type - 17
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, string append_merge_prepend_set, NBTTag value)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_merge_prepend_set = append_merge_prepend_set;
            this.value = value;
            type = 17;
        }

        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 18
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, int index, Pos sourcepos, string sourcePath)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            if (!amps.Contains(append_merge_prepend_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_merge_prepend_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.index = index;
            this.sourcepos = sourcepos;
            this.sourcePath = sourcePath;
            type = 18;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> insert &lt;index> from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 19
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, int index, Pos sourcepos, string sourcePath)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            this.index = index;
            this.sourcepos = sourcepos;
            this.sourcePath = sourcePath;
            this.type = 19;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> insert &lt;index> from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 20
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, int index, Pos sourcepos, string sourcePath)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            this.index = index;
            this.sourcepos = sourcepos;
            this.sourcePath = sourcePath;
            type = 20;
        }

        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from entity &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 21
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, int index, Selector source, string sourcePath)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            this.index = index;
            this.sourceentity = source;
            this.sourcePath = sourcePath;
            type = 21;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value> from entity &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 22
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, int index, Selector source, string sourcePath)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            this.index = index;
            this.sourceentity = source;
            this.sourcePath = sourcePath;
            type = 22;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> insert &lt;index> value &lt;value> from entity &lt;source>
        /// </summary>
        /// type - 23
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, int index, Selector source, string sourcePath)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            this.index = index;
            this.sourceentity = source;
            this.sourcePath = sourcePath;
            type = 23;
        }


        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from storage &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 24
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, int index, ID source, string sourcePath)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            this.index = index;
            this.sourceid = source;
            this.sourcePath = sourcePath;
            type = 24;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value> from storage &lt;source> [&lt;sourcepath>]
        /// </summary>
        /// type - 25
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, int index, ID source, string sourcePath)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            this.index = index;
            this.sourceid = source;
            this.sourcePath = sourcePath;
            type = 25;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
        /// </summary>
        /// type - 26
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, int index, ID source, string sourcePath)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            this.index = index;
            this.sourceid = source;
            this.sourcePath = sourcePath;
            type = 26;
        }

        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value>
        /// </summary>
        /// type - 27
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string targetPath, int index, NBTTag value)
        {
            this.targetpos = targetpos;
            this.targetPath = targetPath;
            this.index = index;
            this.value = value;
            type = 27;
        }

        /// <summary>
        /// data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
        /// </summary>
        /// type - 28
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string targetPath, int index, NBTTag value)
        {
            this.targetentity = target;
            this.targetPath = targetPath;
            this.index = index;
            this.value = value;
            type = 28;
        }

        /// <summary>
        /// data modify storage &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
        /// </summary>
        /// type - 29
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string targetPath, int index, NBTTag value)
        {
            this.targetid = target;
            this.targetPath = targetPath;
            this.index = index;
            this.value = value;
            type = 29;
        }
        #endregion

        #region remove
        /// <summary>
        /// data remove block &lt;targetPos> &lt;path>
        /// </summary>
        /// type - 30
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Pos targetpos, string path)
        {
            this.targetpos = targetpos;
            this.path = path;
            type = 30;
        }

        /// <summary>
        /// data remove entity &lt;target> &lt;path>
        /// </summary>
        /// type - 31
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(Selector target, string path)
        {
            this.targetentity = target;
            this.path = path;
            type = 31;
        }

        /// <summary>
        /// data remove storage &lt;target> &lt;path>
        /// </summary>
        /// type - 32
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(ID target, string path)
        {
            this.targetid = target;
            this.path = path;
            type = 32;
        }
        #endregion

        public override string ToString()
        {
            string re = "#喵喵喵？这里应该是一个data命令，如果你看到了这个注释，说明MC#出现了一些问题！";
            switch (type)
            {
                #region get
                case 0:
                    {
                        //data get block &lt;:targetPos> [&lt;path>] [&lt;scale>]
                        re = "data get block " + targetpos + " " + (path == null ? "" : (path + " ")) + (scale == null ? "" : (scale + " "));
                        break;
                    }
                case 1:
                    {
                        //data get block &lt;:targetPos> [&lt;path>] [&lt;scale>]
                        re = "data get entity " + targetentity + " " + path == null ? "" : (path + " ") + (scale == null ? "" : (scale + " ")); ;
                        break;
                    }
                case 2:
                    {
                        //data get block &lt;:targetPos> [&lt;path>] [&lt;scale>]
                        re = "data get storage " + targetid + " " + path == null ? "" : (path + " ") + (scale == null ? "" : (scale + " ")); ;
                        break;
                    }
                #endregion
                #region merge
                case 3:
                    {
                        //data merge &lt;block:targetPos> &lt;nbt>
                        re = "data merge block " + targetpos + " " + nbt;
                        break;
                    }
                case 4:
                    {
                        //data merge &lt;block:targetPos> &lt;nbt>
                        re = "data merge entity " + targetentity + " " + nbt;
                        break;
                    }
                case 5:
                    {
                        //data merge &lt;block:targetPos> &lt;nbt>
                        re = "data merge storage " + targetid + " " + nbt;
                        break;
                    }
                #endregion
                #region modify
                case 6:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify block " + targetpos +" " + targetPath + " " + append_merge_prepend_set + " from block " + sourcepos + " " + sourcePath;
                        break;
                    }
                case 7:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify entity " + targetentity + " " + targetPath + " " + append_merge_prepend_set + " from block " + sourcepos + " " + sourcePath;
                        break;
                    }
                case 8:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify storage " + targetid + " " + targetPath + " " + append_merge_prepend_set + " from block " + sourcepos + " " + sourcePath;
                        break;
                    }
                case 9:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify block " + targetpos + " " + targetPath + " " + append_merge_prepend_set + " from entity " + sourceentity + " " + sourcePath;
                        break;
                    }
                case 10:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify entity " + targetentity + " " + targetPath + " " + append_merge_prepend_set + " from entity " + sourceentity + " " + sourcePath;
                        break;
                    }
                case 11:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify storage " + targetid + " " + targetPath + " " + append_merge_prepend_set + " from entity " + sourceentity + " " + sourcePath;
                        break;
                    }
                case 12:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify block " + targetpos + " " + targetPath + " " + append_merge_prepend_set + " from storage " + sourceid + " " + sourcePath;
                        break;
                    }
                case 13:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify entity " + targetentity + " " + targetPath + " " + append_merge_prepend_set + " from storage " + sourceid + " " + sourcePath;
                        break;
                    }
                case 14:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify storage " + targetid + " " + targetPath + " " + append_merge_prepend_set + " from storage " + sourceid + " " + sourcePath;
                        break;
                    }
                case 15:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) value <value>
                        re = "data modify block " + targetpos + " " + targetPath + " " + append_merge_prepend_set + " value " + value.ValueString();
                        break;
                    }
                case 16:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) value <value>
                        re = "data modify entity " + targetentity + " " + targetPath + " " + append_merge_prepend_set + " value " + value.ValueString();
                        break;
                    }
                case 17:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) value <value>
                        re = "data modify storage " + targetid + " " + targetPath + " " + append_merge_prepend_set + " value " + value.ValueString();
                        break;
                    }
                case 18:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify block " + targetpos +" " + targetPath + " insert " + index + " from block " + sourcepos + " " + sourcePath;
                        break;
                    }
                case 19:
                    {
                        //data modify entity &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify entity " + targetentity + " " + targetPath +" insert " + index + " from block " + sourcepos + " " + sourcePath;
                        break;
                    }
                case 20:
                    {
                        //data modify entity &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify storage " + targetid + " " + targetPath + " insert " + index + " from block " + sourcepos + " " + sourcePath;
                        break;
                    }
                case 21:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify block " + targetpos + " " + targetPath + " insert " + index + " from entity " + sourceentity + " " + sourcePath;
                        break;
                    }
                case 22:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify entity " + targetentity + " " + targetPath + " insert " + index + " from entity " + sourceentity + " " + sourcePath;
                        break;
                    }
                case 23:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify storage " + targetid + " " + targetPath + " insert " + index + " from entity " + sourceentity + " " + sourcePath;
                        break;
                    }
                case 24:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify block " + targetpos + " " + targetPath + " insert " + index + " from storage " + sourceid + " " + sourcePath;
                        break;
                    }
                case 25:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify entity " + targetentity + " " + targetPath + " insert " + index + " from storage " + sourceid + " " + sourcePath;
                        break;
                    }
                case 26:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify storage " + targetid + " " + targetPath + " insert " + index + " from storage " + sourceid + " " + sourcePath;
                        break;
                    }
                case 27:
                    {
                        //data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
                        re = "data modify block " + targetpos +" " + targetPath + " insert " + index + " value " + value.ValueString();
                        break;
                    }
                case 28:
                    {
                        //data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
                        re = "data modify entity " + targetentity + " " + targetPath + " insert " + index + " value " + value.ValueString();
                        break;
                    }
                case 29:
                    {
                        //data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
                        re = "data modify storage " + targetid + " " + targetPath + " insert " + index + " value " + value.ValueString();
                        break;
                    }
                #endregion
                #region remove
                case 30:
                    {
                        //data remove block &lt;targetPos> &lt;path>
                        re = "data remove block " + targetpos + " " + path;
                        break;
                    }
                case 31:
                    {
                        //data remove block &lt;targetPos> &lt;path>
                        re = "data remove entity " + targetentity + " " + path;
                        break;
                    }
                case 32:
                    {
                        //data remove block &lt;targetPos> &lt;path>
                        re = "data remove storage " + targetid + " " + path;
                        break;
                    }
                    #endregion
            }
            return re;
        }
    }
}
