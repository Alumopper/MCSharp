using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 啥用没用，表示这个东西可以被塞到data里面去
    /// </summary>
    public interface IDataArg
    {
        void Merge(NBTTag nbt);
        string DataCmdStr();
    }
}
