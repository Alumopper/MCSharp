using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCSharp;
using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
using static System.Net.Mime.MediaTypeNames;
using static MCSharp.Cmds.Execute;
using static MCSharp.Cmds.Loot;
using static MCSharp.Cmds.Place;
using static MCSharp.Cmds.Scoreboard;
using static MCSharp.Type.Bossbar;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 命令总类，提供了大量用于生成命令的方法，避免频繁的新建类（调用命令类的各种极度抽象的构造方法（x
    /// </summary>
    public class Commands
    {
        #region advancement
        public static Advancement GrankEveryThing(Entity target)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement = new Advancement("grant", target, "everything");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement);
            return advancement;
        }

        public static Advancement GrankOnly(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("grant", target, "only", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement GrankOnly(Entity target, string advancement, string criterion)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("grant", target, "only", advancement, criterion);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement GrankFrom(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("grant", target, "from", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement GrankThrough(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("grant", target, "through", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement GrankUntil(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("grant", target, "until", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement RevokeEverything(Entity target)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement = new Advancement("revoke", target, "everything");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement);
            return advancement;
        }

        public static Advancement RevokeOnly(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("revoke", target, "only", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement RevokeOnly(Entity target, string advancement, string criterion)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("revoke", target, "only", advancement, criterion);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement RevokeFrom(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("revoke", target, "from", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement RevokeThrough(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("revoke", target, "through", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        public static Advancement RevokeUntil(Entity target, string advancement)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Advancement advancement1 = new Advancement("revoke", target, "until", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            return advancement1;
        }

        #endregion

        #region attribute

        public static Attribute GetAttribute(Entity entity, string attrubute, double scale = 1.0)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Attribute attribute = new Attribute(entity, attrubute, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute);
            return attribute;
        }

        public static Attribute GetBaseAttribute(Entity entity,string attribute, double scale = 1.0)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Attribute attribute1 = new Attribute(entity, attribute, "get", scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            return attribute1;
        }

        public static Attribute SetBaseAttribute(Entity entity, string attribute, double value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Attribute attribute1 = new Attribute(entity, attribute, "set", value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            return attribute1;
        }

        public static Attribute AddAttriModifier(Entity target, string attribute, UUID uuid, string name, double value, string add__multiply__multiply_base)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Attribute attribute1 = new Attribute(target, attribute, uuid, name, value, add__multiply__multiply_base);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            return attribute1;
        }

        public static Attribute RemoveAttriModifier(Entity target, string attribute, UUID uuid)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Attribute attribute1 = new Attribute(target, attribute, uuid);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            return attribute1;
        }

        public static Attribute GetAttriModifierValue(Entity target, string attribute, UUID uuid, double scale = 1.0)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Attribute attribute1 = new Attribute(target, attribute, uuid, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            return attribute1;
        }

        #endregion

        #region ban
        public static Ban BanPlayer(string player, string reason = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Ban ban = new Ban(player,reason);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(ban);
            return ban;
        }
        #endregion

        #region ban-ip
        public static Ban_ip BanIp(string ip, string reason = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Ban_ip ban_Ip = new Ban_ip(ip, reason);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(ban_Ip);
            return ban_Ip;
        }
        #endregion

        #region banlist
        public static Banlist BanlistPlayers()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Banlist banlist = new Banlist("players");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(banlist);
            return banlist;
        }

        public static Banlist BanlistIps()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Banlist banlist = new Banlist("ips");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(banlist);
            return banlist;
        }
        #endregion

        #region bossbar
        public static Bossbar AddBossBar(ID id,string name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar RemoveBossBar(ID id)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar GetBossBarValue(ID id, string value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar GetBossBarPlayers(ID id)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, "players");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar GetBossBarMax(ID id)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, "max");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar GetBossBarVisible(ID id)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, "visible");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar SetBossBarColor(ID id, Type.Bossbar.Color color)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, color);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar SetBossBarMax(ID id, int max)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, "max", max);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar SetBossBarValue(ID id, int value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, "value", value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar SetBossBarName(ID id, JsonText name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar SetBossBarStyle(ID id, Type.Bossbar.Style style)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, style);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar SetBossBarVisible(ID id, bool visible)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id, visible);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        public static Bossbar AddBossBarPlayer(ID id, Entity selector)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Bossbar bossbar = new Bossbar(id,"set", selector);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            return bossbar;
        }

        #endregion

        #region clear
        public static Clear Clear(Entity target, ItemStack itemStack = null, int? count = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clear clear;
            if (count == null)
            {
                clear = new Clear(target, itemStack);
            }
            else
            {
                clear = new Clear(target, itemStack, count.Value);
            }
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clear);
            return clear;
        }

        #endregion

        #region clone
        public static Clone CloneReplaceForce(Pos begin, Pos end, Pos destination)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, "replace", "force");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneReplaceMove(Pos begin, Pos end, Pos destination)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, "replace", "move");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneReplaceNormal(Pos begin, Pos end, Pos destination)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, "replace", "normal");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneMaskedForce(Pos begin, Pos end, Pos destination)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, "masked", "force");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneMaskedMove(Pos begin, Pos end, Pos destination)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, "masked", "move");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneMaskedNormal(Pos begin, Pos end, Pos destination)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, "masked", "normal");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneFilteredForce(Pos begin, Pos end, Pos destination, BlockPredicate filter)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, filter, "force");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        public static Clone CloneFilteredMove(Pos begin, Pos end, Pos destination, BlockPredicate filter)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, filter, "move");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }


        public static Clone CloneFilteredNormal(Pos begin, Pos end, Pos destination, BlockPredicate filter)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Clone clone = new Clone(begin, end, destination, filter, "normal");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            return clone;
        }

        #endregion

        #region data
        public static Data GetData(Pos targetPos, string path = null, double? scale = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data GetData(Entity target, string path = null, double? scale = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data GetData(ID target, string path = null, double? scale = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data MergeData(Pos targetPos, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data MergeData(Entity target, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data MergeData(ID target, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(Pos targetPos, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "append", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(Pos targetPos, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "append", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(Pos targetPos, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "append", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(Pos targetPos, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "merge", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(Pos targetPos, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "merge", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(Pos targetPos, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "merge", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(Pos targetPos, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "prepend", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(Pos targetPos, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "prepend", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(Pos targetPos, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "prepend", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(Pos targetPos, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "set", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(Pos targetPos, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(Pos targetPos, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(targetPos, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(Entity target, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(Entity target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(Entity target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(Entity target, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(Entity target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(Entity target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(Entity target, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(Entity target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(Entity target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(Entity target, string path, Pos source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(Entity target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(Entity target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(ID target, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(ID target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppendFrom(ID target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(ID target, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(ID target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMergeFrom(ID target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(ID target, string path, Pos sourcePos, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", sourcePos, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(ID target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrependFrom(ID target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(ID target, string path, Pos source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(ID target, string path, Entity source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSetFrom(ID target, string path, ID source, string sourcePath)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSet(Pos target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSet(Entity target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataSet(ID target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "set", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrepend(Pos target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrepend(Entity target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataPrepend(ID target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "prepend", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppend(Pos target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppend(Entity target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataAppend(ID target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "append", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMerge(Pos target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMerge(Entity target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataMerge(ID target, string path, NBT nbt)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, "merge", nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(Pos target, string path, Pos source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(Pos target, string path, Entity source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(Pos target, string path, ID source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(Entity target, string path, Pos source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(Entity target, string path, Entity source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(Entity target, string path, ID source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(ID target, string path, Pos source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(ID target, string path, Entity source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsertFrom(ID target, string path, ID source, string sourcePath, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, source, sourcePath);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsert(Pos target, string path, NBT nbt, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsert(Entity target, string path, NBT nbt, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data ModifyDataInsert(ID target, string path, NBT nbt, int index)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path, index, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data RemoveData(Pos target, string path)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data RemoveData(Entity target, string path)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }

        public static Data RemoveData(ID target, string path)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Data data = new Data(target, path);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            return data;
        }
        #endregion

        #region datapack
        public static Datapack DisableDatapack(string name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("disable", name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }

        public static Datapack EnableDatapack(string name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("enable", name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }
        
        public static Datapack EnableDatapackAtFirst(string name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("enable", name, "first");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }

        public static Datapack EnableDatapackAtLast(string name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("enable", name, "last");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }

        public static Datapack EnableDatapackBefore(string name, string exist)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("enable", name, "before", exist);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }
        
        public static Datapack EnableDatapackAfter(string name, string exist)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("enable", name, "after", exist);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }

        public static Datapack ListDatapack()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("list");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }

        public static Datapack ListAvailableDatapack()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("list","available");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }
        
        public static Datapack ListEnabledDatapack()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Datapack datapack = new Datapack("list", "enabled");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            return datapack;
        }

        #endregion

        #region debug
        
        public static Debug StartDebug()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Debug debug = new Debug("start");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(debug);
            return debug;
        }

        public static Debug StopDebug()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Debug debug = new Debug("stop");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(debug);
            return debug;
        }

        public static Debug FunctionDebug()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Debug debug = new Debug("function");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(debug);
            return debug;
        }

        #endregion

        #region defaultgamemode

        public static Defaultgamemode SetDefaultgamemode(Gamemodes gamemode)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Defaultgamemode defaultgamemode = new Defaultgamemode(gamemode);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(defaultgamemode);
            return defaultgamemode;
        }

        #endregion

        #region deop
        public static Deop Deop(string player)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Deop deop = new Deop(player);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(deop);
            return deop;
        }
        #endregion

        #region difficulty

        public static Difficulty SetDifficulty(Difficulties? difficulty = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Difficulty difficulty1 = new Difficulty(difficulty);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(difficulty1);
            return difficulty1;
        }

        #endregion

        #region effect
        public static Effect GiveEffect(Entity player, ID effect, int seconds = 30, int amplifier = 0, bool hideParticles = false)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Effect effect1 = new Effect(player, effect, seconds, amplifier, hideParticles);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(effect1);
            return effect1;
        }

        public static Effect ClearEffect(Entity player = null, ID effect = null)
        {
            {
                if (!DatapackInfo.FunctionHasRegistry())
                {
                    throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
                }
                Effect effect1 = new Effect("clear", player, effect);
                DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(effect1);
                return effect1;
            }
        }
        #endregion

        #region enchant
        public static Enchant Enchant(Entity player, ID enchantment, int level = 1)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Enchant enchant = new Enchant(player, enchantment, level);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(enchant);
            return enchant;
        }
        #endregion

        #region experience
        public static Experience AddExperience(Entity player, int amount, bool levels = false)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Experience experience = new Experience("add", player, amount, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(experience);
            return experience;
        }

        public static Experience SetExperience(Entity player, int amount, bool levels = false)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Experience experience = new Experience("set", player, amount, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(experience);
            return experience;
        }

        public static Experience QueryExperience(Entity player, bool levels = false)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Experience experience = new Experience(player, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(experience);
            return experience;
        }
        #endregion

        #region fill
        public static Fill FillDestory(Pos from, Pos to, BlockState block)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fill fill = new Fill(from, to, block,"destroy");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            return fill;
        }

        public static Fill FillHollow(Pos from, Pos to, BlockState block)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fill fill = new Fill(from, to, block, "hollow");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            return fill;
        }

        public static Fill FillKeep(Pos from, Pos to, BlockState block)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fill fill = new Fill(from, to, block, "keep");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            return fill;
        }

        public static Fill FillOutline (Pos from, Pos to, BlockState block)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fill fill = new Fill(from, to, block, "outline");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            return fill;
        }
        
        public static Fill FillReplace(Pos from, Pos to, BlockState block, BlockPredicate filter = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fill fill = new Fill(from, to, block, filter);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            return fill;
        }
        #endregion

        #region fillbiome
        public static Fillbiome Fillbiome(Pos from = null, Pos to = null, ID biome = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fillbiome fillbiome = new Fillbiome(from, to, biome);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fillbiome);
            return fillbiome;
        }

        public static Fillbiome ReplaceBiome(Pos from = null, Pos to = null, ID biome = null, ID filter = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Fillbiome fillbiome = new Fillbiome("" , from, to, biome, filter);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fillbiome);
            return fillbiome;
        }
        #endregion

        #region forceload
        public static Forceload AddForceload(Pos from, Pos to)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Forceload forceload = new Forceload("add", from, to);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            return forceload;
        }

        public static Forceload RemoveForceload(Pos from, Pos to)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Forceload forceload = new Forceload("remove", from, to);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            return forceload;
        }
        
        public static Forceload RemoveAllForceLoad()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Forceload forceload = new Forceload();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            return forceload;
        }

        public static Forceload QueryForceLoad(Pos pos)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Forceload forceload = new Forceload("query", pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            return forceload;
        }

        #endregion

        #region function
        public static Function Function(ID functionID)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Function function = new Function(functionID);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(function);
            return function;
        }
        #endregion

        #region gamemode
        public static Gamemode SetGamemode(Gamemodes gamemode, Entity target = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Gamemode gamemode1 = new Gamemode(gamemode, target);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(gamemode1);
            return gamemode1;
            {
            }
        }
        #endregion

        #region gamerule
        public static Gamerule Gamerule(string rule, string value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Gamerule gamerule = new Gamerule(rule, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(gamerule);
            return gamerule;
        }
        #endregion

        #region give 
        public static Give Give(Entity target, ItemStack item)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Give give = new Give(target, item);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(give);
            return give;
        }
        #endregion

        #region help
        public static Help Help(string command = "")
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Help help = new Help(command);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(help);
            return help;
        }
        #endregion

        #region item
        public static Item ModifyItem(Pos pos, Slot slot, ID modifier)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(pos, slot, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ModifyItem(Entity target, Slot slot, ID modifier)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(target, slot, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ReplaceItem(Pos pos, Slot slot, ItemStack item)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(pos, slot, item);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ReplaceItem(Entity target, Slot slot, ItemStack item)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(target, slot, item);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ReplaceItemFrom(Pos pos, Slot slot, Entity target, Slot slot2, ID modifier = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(pos, slot, target, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ReplaceItemFrom(Entity target, Slot slot, Entity target2, Slot slot2, ID modifier = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(target, slot, target2, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ReplaceItemFrom(Pos pos, Slot slot, Pos pos2, Slot slot2, ID modifier = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(pos, slot, pos2, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }

        public static Item ReplaceItemFrom(Entity target, Slot slot, Pos pos2, Slot slot2, ID modifier = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Item item1 = new Item(target, slot, pos2, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            return item1;
        }
        #endregion

        #region jfr
        public static Jfr JfrStart()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Jfr jfr = new Jfr("start");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(jfr);
            return jfr;
        }

        public static Jfr JfrStop()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Jfr jfr = new Jfr("stop");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(jfr);
            return jfr;
        }
        #endregion

        #region kick
        public static Kick Kick(Entity target, string reason = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Kick kick = new Kick(target,reason);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(kick);
            return kick;
        }
        #endregion

        #region kill
        public static Kill Kill(Entity target)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Kill kill = new Kill(target);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(kill);
            return kill;
        }
        #endregion

        #region list
        public static List List()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            List list = new List(null);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(list);
            return list;
        }

        public static List ListUUID()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            List list = new List(114514);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(list);
            return list;
        }

        #endregion

        #region locate
        public static Locate LocateBiome(ID biome)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Locate locate = new Locate("biome",biome);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(locate);
            return locate;
        }

        public static Locate LocatePoi(ID poi)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Locate locate = new Locate("poi", poi);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(locate);
            return locate;
        }

        public static Locate LocateStructure(ID structure)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Locate locate = new Locate("structure", structure);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(locate);
            return locate;
        }
        #endregion

        #region me
        public static Me Me(string action)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Me me = new Me(action);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(me);
            return me;
        }
        #endregion

        #region msg
        public static Msg Msg(Entity player, string message)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Msg msg = new Msg(player, message);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(msg);
            return msg;
        }
        #endregion

        #region op
        public static Op Op(Entity player)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Op op = new Op(player);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(op);
            return op;
        }
        #endregion

        #region pardon
        public static Pardon Pardon(string name)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Pardon pardon = new Pardon(name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(pardon);
            return pardon;
        }

        public static Pardon PardonUUID(UUID uuid)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Pardon pardon = new Pardon(uuid);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(pardon);
            return pardon;
        }
        #endregion

        #region pardon-ip
        public static Pardon_ip Pardon_ip(string ip)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Pardon_ip pardon_ip = new Pardon_ip(ip);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(pardon_ip);
            return pardon_ip;
        }
        #endregion

        #region particle
        public static Particle Particle(ID particle, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(particle, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle(ID particle, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers= null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(particle, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_dust(Type.Color color, float size, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(color, size, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_dust(Type.Color color, float size, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(color, size, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_dust_color_transition(Type.Color color1, float size, Type.Color color2, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(color1, size, color2, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_dust_color_transition(Type.Color color1, float size, Type.Color color2, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(color1, size, color2, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_block(BlockState block, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle("minecraft:block", block, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_block(BlockState block, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle("minecraft:block", block, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_falling_dust(BlockState block, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle("minecraft:falling_dust", block, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_falling_dust(BlockState block, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle("minecraft:falling_dust", block, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_item(ItemStack item, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(item, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_item(ItemStack item, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(item, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_shriek(int second, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(second, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }

        public static Particle Particle_shriek(int second, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Entity viewers = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Particle particle1 = new Particle(second, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            return particle1;
        }
        #endregion

        #region perf
        public static Perf PerfStart()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Perf perfStart1 = new Perf("start");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(perfStart1);
            return perfStart1;
        }

        public static Perf PerfStop()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Perf perfStart1 = new Perf("stop");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(perfStart1);
            return perfStart1;
        }
        #endregion

        #region place
        public static Place PlaceFeature(ID feature, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Place place = new Place(feature, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            return place;
        }

        public static Place PlaceJigsaw(ID pool, ID target, int max_depth, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Place place = new Place(pool, target , max_depth, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            return place;
        }

        public static Place PlaceStructure(ID structure, Pos pos = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Place place = new Place(structure, pos, 114514);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            return place;
        }

        public static Place PlaceTemplate(ID template, Pos pos = null, Rot rot = Rot._none, Mirror mirror = Mirror.none, float integrity = 1.0f, long? seed = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Place place = new Place(template, pos, rot, mirror, integrity, seed);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            return place;
        }
        #endregion

        #region playsound
        public static Playsound Playsound(ID sound, Playsound.Source source, Entity targets, Pos pos = null, float volume = 1.0f, float pitch = 1.0f, float minvolumn = 0)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Playsound playsound = new Playsound(sound , source, targets, pos, volume, pitch, minvolumn);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(playsound);
            return playsound;
        }
        #endregion

        #region publish
        public static Publish Publish(bool allowCommands = false, Gamemodes gamemode = Gamemodes.survival, int? port = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Publish publish = new Publish(allowCommands, gamemode, port);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(publish);
            return publish;
            {
            }
        }
        #endregion

        #region recipe
        public static Recipe RecipeGive(Entity targets,ID recipe = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Recipe recipe1 = new Recipe(Recipe.gt.give,targets, recipe);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(recipe1);
            return recipe1;
        }

        public static Recipe RecipeTake(Entity targets, ID recipe = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Recipe recipe1 = new Recipe(Recipe.gt.take, targets, recipe);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(recipe1);
            return recipe1;
        }
        #endregion

        #region reload
        public static Reload Reload()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Reload reload = new Reload();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(reload);
            return reload;
        }
        #endregion

        #region save-all
        public static Save_all Save_All(bool flush = false)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Save_all save_All = new Save_all(flush);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(save_All);
            return save_All;
        }
        #endregion

        #region save-off
        public static Save_off Save_Off()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Save_off save_Off = new Save_off();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(save_Off);
            return save_Off;
        }
        #endregion

        #region save-on
        public static Save_on Save_On()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Save_on save_On = new Save_on();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(save_On);
            return save_On;
        }
        #endregion

        #region say
        /// <summary>
        /// /say
        /// </summary>
        /// <param name="text">要发送的文本</param>
        public static Say Say(string text)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Say say = new Say(text);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(say);
            return say;
        }
        #endregion

        #region schedule
        public static Schedule ScheduleAppend(ID function, string time)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Schedule schedule = new Schedule(function, time, Schedule.ar.append);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(schedule);
            return schedule;
        }

        public static Schedule ScheduleReplace(ID function, string time)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Schedule schedule = new Schedule(function, time, Schedule.ar.replace);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(schedule);
            return schedule;
        }

        public static Schedule ScheduleClear(ID function)
        {

            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Schedule schedule = new Schedule(function);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(schedule);
            return schedule;
        }
        #endregion

        #region scoreboard
        public static Scoreboard SbObjectAdd(SbObject sbObject, string rule, JsonText display = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(sbObject, rule, display);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbObjectList()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbObjectModifyDisplayName(string rule, JsonText display)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(rule, display);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbObjectModifyRenderType(SbObject objective, Scoreboard.hi renderType)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(objective, renderType);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbObjectRemove(SbObject objective)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbObjectSetdisplay(Scoreboard.DisplaySlot displaySlot, SbObject objective)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(displaySlot, objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbPlayerAdd(string target, SbObject objective, int value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(Scoreboard.ars.add , target, objective, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbEnableTrigger(string target, SbObject trigger)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(target, trigger);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbGet(string target, SbObject objective)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(Scoreboard.eg.get,target, objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbList(string target)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(target);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbOperation(string target, SbObject targetObject, string operation, string source, SbObject sourceObject)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(target, targetObject, operation, source, sourceObject);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbRemove(string target, SbObject objective, int value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(ars.remove, target, objective, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbReset(string target, SbObject objective = null)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(target, objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }

        public static Scoreboard SbSet(string target, SbObject objective, int value)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Scoreboard scoreboard = new Scoreboard(ars.set, target, objective, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            return scoreboard;
        }
        #endregion

        #region seed
        public static Seed Seed()
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Seed seed = new Seed();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(seed);
            return seed;
        }
        #endregion

        #region setblock
        public static Setblock Setblock(Pos pos, BlockState state = null, Setblock.dkr mode = Cmds.Setblock.dkr.replace)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            Setblock setblock = new Setblock(pos, state, mode);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(setblock);
            return setblock;
        }
        #endregion
    }
}
