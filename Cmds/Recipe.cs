using MCSharp.Exception;
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
    /// 给予或剥夺（解锁或锁定）玩家的合成配方。
    /// <code>
    /// recipe (give|take) &lt;targets> (&lt;recipe>|*)
    /// </code>
    /// </summary>
    public class Recipe : Command
    {
        gt give_take;
        Selector targets;
        ID recipe;

        public enum gt
        {
            give,take
        }

        /// <summary>
        /// recipe (give|take) &lt;targets> (&lt;recipe>|*)
        /// </summary>
        /// <param name="give_take">若为give，则对玩家给予（解锁）指定的合成配方；若为take，则对玩家剥夺（锁定）指定的合成配方。</param>
        /// <param name="targets">指定给予或剥夺合成配方的对象。</param>
        /// <param name="recipe">合成配方的物品ID。若指定为null，则表示*，玩家会被给予或剥夺全部合成配方。</param>
        /// <exception cref="ArgumentNotMatchException"></exception>
        public Recipe(gt give_take, Selector targets, ID recipe = null)
        {
            this.give_take = give_take;
            this.targets = targets;
            if(recipe != null && recipe.isTag)
            {
                throw new ArgumentNotMatchException("参数错误: " + recipe + "。不应当为标签");
            }
        }

        public override string ToString()
        {
            return "recipe " + Tools.GetEnumString(give_take) + " " + targets + " " + (recipe == null ? "*" : recipe.ToString());
        }
    }
}
