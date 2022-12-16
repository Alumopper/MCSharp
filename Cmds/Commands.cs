using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MCSharp;
using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
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
    }
}
