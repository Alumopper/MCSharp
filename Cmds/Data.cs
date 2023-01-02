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
        IDataArg target;
        string path;
        double? scale;
        NBTTag nbt;
        string targetPath;
        string append_prepend_merge_set;
        NBTTag value;
        string sourcePath;
        IDataArg source;
        int index;
        int type;
        #endregion
        
        private static string[] amps = new string[] { "append", "prepend", "merge", "set" };

        #region get
        /// <summary>
        /// data get block &lt;targetPos> [&lt;path>] [&lt;scale>]
        /// </summary>
        /// type - 0
        public Data(IDataArg target,string path = null, double? scale = null)
        {
            this.target = target;
            this.path = path;
            this.scale = scale;
            this.type = 0;
        }

        #endregion

        #region merge
        /// <summary>
        /// data merge &lt;block:targetPos> &lt;nbt>
        /// </summary>
        /// type - 3
        public Data(IDataArg target, NBTTag nbt)
        {
            this.target = target;
            this.nbt = nbt;
            type = 3;
        }
        #endregion

        #region modify
        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> (append|prepend|merge|set) from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 6
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(IDataArg target, string targetPath, string append_prepend_merge_set, IDataArg source, string sourcePath)
        {
            this.target = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_prepend_merge_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_prepend_merge_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_prepend_merge_set = append_prepend_merge_set;
            this.source = source;
            this.sourcePath = sourcePath;
            type = 6;
        }
        
        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> (append|prepend|merge|set) value &lt;value>
        /// </summary>
        /// type - 15
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(IDataArg target, string targetPath, string append_prepend_merge_set, NBTTag value)
        {
            this.target = target;
            this.targetPath = targetPath;
            if (!amps.Contains(append_prepend_merge_set))
            {
                throw new ArgumentNotMatchException("参数错误:" + append_prepend_merge_set + "。应当为\"append\", \"merge\", \"prepend\"或\"set\"");
            }
            this.append_prepend_merge_set = append_prepend_merge_set;
            this.value = value;
            type = 15;
        }
        
        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> from block &lt;sourcePos> [&lt;sourcepath>]
        /// </summary>
        /// type - 18
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(IDataArg target, string targetPath, int index, IDataArg source, string sourcePath)
        {
            this.target = target;
            this.targetPath = targetPath;
            this.index = index;
            this.source = source;
            this.sourcePath = sourcePath;
            type = 18;
        }

        /// <summary>
        /// data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value>
        /// </summary>
        /// type - 27
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(IDataArg target, string targetPath, int index, NBTTag value)
        {
            this.target = target;
            this.targetPath = targetPath;
            this.index = index;
            this.value = value;
            type = 27;
        }
        #endregion

        #region remove
        /// <summary>
        /// data remove block &lt;targetPos> &lt;path>
        /// </summary>
        /// type - 30
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Data(IDataArg target, string path)
        {
            this.target = target;
            this.path = path;
            type = 30;
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
                        re = "data get " + getTypeString(target) + " " + target + " " + (path == null ? "" : (path + " ")) + (scale == null ? "" : (scale + " "));
                        break;
                    }
                #endregion
                #region merge
                case 3:
                    {
                        //data merge &lt;block:targetPos> &lt;nbt>
                        re = "data merge " + getTypeString(target) + " " + target + " " + nbt.ValueString;
                        break;
                    }
                #endregion
                #region modify
                case 6:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify " + getTypeString(target) + " " + target +" " + targetPath + " " + append_prepend_merge_set + " from " + getTypeString(source) + " " + source + " " + sourcePath;
                        break;
                    }
                case 15:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> (append|merge|prepend|set) value <value>
                        re = "data modify " + getTypeString(target) + " " + target + " " + targetPath + " " + append_prepend_merge_set + " value " + value.ValueString;
                        break;
                    }
                case 18:
                    {
                        //data modify block &lt;targetPos> &lt;targetPath> insert &lt;index> value &lt;value> from block &lt;sourcePos> [&lt;sourcepath>]
                        re = "data modify " + getTypeString(target) + " " + target + " " + targetPath + " insert " + index + " from " + getTypeString(source) + " " + source + " " + sourcePath;
                        break;
                    }
                case 27:
                    {
                        //data modify entity &lt;target> &lt;targetPath> insert &lt;index> value &lt;value>
                        re = "data modify " + getTypeString(target) + " " + target + " " + targetPath + " insert " + index + " value " + value.ValueString;
                        break;
                    }
                #endregion
                #region remove
                case 30:
                    {
                        //data remove block &lt;targetPos> &lt;path>
                        re = "data remove " + getTypeString(target) + " " + target + " " + path;
                        break;
                    }
                    #endregion
            }
            return re;
        }

        private static string getTypeString(object o)
        {
            if(o is Pos)
            {
                return "block";
            }else if(o is Selector)
            {
                return "entity";
            }else if(o is ID)
            {
                return "storage";
            }
            else
            {
                return null;
            }
        } 
    }
}
