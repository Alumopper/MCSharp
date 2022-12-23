﻿using MCSharp.Type.CommandArg;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 目标选择器的构造类
    /// </summary>
    public class SelectorBuilder
    {
        private Selector selector;
        
        public SelectorBuilder(Selector.SelectorType type)
        {
            selector = new Selector(type);
        }

        public SelectorBuilder Append(SelectorArgument arg) 
        {
            if(selector.args == null)
            {
                selector.args = new List<SelectorArgument>();
            }
            selector.args.Add(arg);
            return this;
        }

        public Selector Build()
        {
            return this.selector;    
        }

    }
    public interface SelectorArgument { }

    public class x : SelectorArgument
    {
        double value;
        public x(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "x=" + value;
        }
    }

    public class y : SelectorArgument
    {
        double value;
        public y(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "y=" + value;
        }
    }

    public class z : SelectorArgument
    {
        double value;
        public z(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "z=" + value;
        }
    }

    public class distance : SelectorArgument
    {
        double value;
        public distance(double distance)
        {
            this.value = distance;
        }
        public override string ToString()
        {
            return "distance=" + value;
        }
    }

    public class dx : SelectorArgument
    {
        double value;
        public dx(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "dx=" + value;
        }
    }

    public class dy : SelectorArgument
    {
        double value;
        public dy(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "dy=" + value;
        }
    }

    public class dz : SelectorArgument
    {
        double value;
        public dz(double value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return "dz=" + value;
        }
    }

    public class scores : SelectorArgument
    {
        string objective;
        IntRange value;

        public scores(SbObject objective, IntRange range)
        {
            this.objective = objective.name;
            this.value = range;
        }

        internal scores(string objective, IntRange range)
        {
            this.objective = objective;
            this.value = range;
        }

        public override string ToString()
        {
            return "scores={" + objective + "=" + value + "}";
        }
    }

    public class tag : SelectorArgument
    {
        string value;
        bool fit;
        public tag(string tag, bool fit = true)
        {
            this.value = tag;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "tag=" + (fit ? "" : "!") + value;
        }
    }

    public class team : SelectorArgument
    {
        string value;
        bool fit;
        public team(string team, bool fit = true)
        {
            this.value = team;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "team=" + (fit ? "" : "!") + value;
        }
    }

    public class name : SelectorArgument
    {
        string value;
        bool fit;
        public name(string name, bool fit = true)
        {
            this.value = name;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "name=" + (fit ? "" : "!") + value;
        }
    }

    public class type : SelectorArgument
    {
        ID value;
        bool fit;
        public type(ID type, bool fit = true)
        {
            this.value = type;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "type=" + (fit ? "" : "!") + value;
        }
    }

    public class predicate : SelectorArgument
    {
        ID value;
        bool fit;
        public predicate(ID predicate, bool fit = true)
        {
            this.value = predicate;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "predicate=" + (fit ? "" : "!") + value;
        }
    }

    public class x_rotation : SelectorArgument
    {
        IntRange value;
        public x_rotation(IntRange range)
        {
            this.value = range;
        }
        public override string ToString()
        {
            return "x_rotation=" + value;
        }
    }

    public class y_rotation : SelectorArgument
    {
        IntRange value;
        public y_rotation(IntRange range)
        {
            this.value = range;
        }
        public override string ToString()
        {
            return "y_rotation=" + value;
        }
    }

    public class nbt : SelectorArgument
    {
        NBT value;
        bool fit;
        public nbt(NBT nbt, bool fit = true)
        {
            this.value = nbt;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "nbt=" + (fit ? "" : "!") + value;
        }
    }

    public class level : SelectorArgument
    {
        IntRange value;
        public level(IntRange level)
        {
            this.value = level;
        }
        public override string ToString()
        {
            return "level=" + value;
        }
    }

    public class gamemode : SelectorArgument
    {
        Gamemodes value;
        bool fit;
        public gamemode(Gamemodes gamemode, bool fit = true)
        {
            this.value = gamemode;
            this.fit = fit;
        }
        public override string ToString()
        {
            return "gamemode=" + (fit ? "" : "!") + Tools.GetEnumString(value);
        }
    }

    public class advancements : SelectorArgument
    {
        ID advancement;
        string criteria = null;
        bool fit;

        public advancements(ID advancement, bool fit = true)
        {
            this.advancement = advancement;
            this.fit = fit;
        }

        public advancements(ID advancement, string criteria, bool fit = true)
        {
            this.advancement = advancement;
            this.criteria = criteria;
            this.fit = fit;
        }

        public override string ToString()
        {
            if (criteria == null)
            {
                return "advancements={" + advancement + "=" + fit + "}";
            }
            else
            {
                return "advancements={" + advancement + "={" + criteria + "=" + fit + "}}";
            }
        }
    }

    public class limit : SelectorArgument
    {
        int value;
        public limit(int limit)
        {
            this.value = limit;
        }
        public override string ToString()
        {
            return "limit=" + value;
        }
    }

    public class sort : SelectorArgument
    {
        string value;
        public sort(string sort)
        {
            this.value = sort;

        }
        public override string ToString()
        {
            return "sort=" + value;
        }
    }
}
