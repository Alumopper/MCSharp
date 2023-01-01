using System.Diagnostics;
using System.Net.Http.Headers;
using MCSharp.Exception;
using MCSharp.Type;
using MCSharp.Type.CommandArg;
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
        public static Advancement AdvancementGrankEveryThing(Selector target, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement = new Advancement("grant", target, "everything");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement);
            }
            return advancement;
        }

        public static Advancement AdvancementGrankOnly(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("grant", target, "only", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementGrankOnly(Selector target, string advancement, string criterion, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("grant", target, "only", advancement, criterion);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementGrankFrom(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("grant", target, "from", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementGrankThrough(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("grant", target, "through", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementGrankUntil(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("grant", target, "until", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementRevokeEverything(Selector target, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement = new Advancement("revoke", target, "everything");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement);
            }
            return advancement;
        }

        public static Advancement AdvancementRevokeOnly(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("revoke", target, "only", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementRevokeOnly(Selector target, string advancement, string criterion, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("revoke", target, "only", advancement, criterion);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementRevokeFrom(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("revoke", target, "from", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementRevokeThrough(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("revoke", target, "through", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        public static Advancement AdvancementRevokeUntil(Selector target, string advancement, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Advancement advancement1 = new Advancement("revoke", target, "until", advancement);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(advancement1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(advancement1);
            }
            return advancement1;
        }

        #endregion

        #region attribute

        public static Attribute AttributeGet(Selector entity, string attrubute, double scale = 1.0, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Attribute attribute = new Attribute(entity, attrubute, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(attribute);
            }
            return attribute;
        }

        public static Attribute AttributeGetBase(Selector entity, string attribute, double scale = 1.0, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Attribute attribute1 = new Attribute(entity, attribute, "get", scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(attribute1);
            }
            return attribute1;
        }

        public static Attribute AttributeSetBase(Selector entity, string attribute, double value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Attribute attribute1 = new Attribute(entity, attribute, "set", value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(attribute1);
            }
            return attribute1;
        }

        public static Attribute AttributeAddModifier(Selector target, string attribute, UUID uuid, string name, double value, string add__multiply__multiply_base, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Attribute attribute1 = new Attribute(target, attribute, uuid, name, value, add__multiply__multiply_base);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(attribute1);
            }
            return attribute1;
        }

        public static Attribute AttributeRemoveModifier(Selector target, string attribute, UUID uuid, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Attribute attribute1 = new Attribute(target, attribute, uuid);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(attribute1);
            }
            return attribute1;
        }

        public static Attribute AttributeGetModifier(Selector target, string attribute, UUID uuid, double scale = 1.0, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Attribute attribute1 = new Attribute(target, attribute, uuid, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(attribute1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(attribute1);
            }
            return attribute1;
        }

        #endregion

        #region ban
        public static Ban BanPlayer(string player, string reason = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Ban ban = new Ban(player, reason);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(ban);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(ban);
            }
            return ban;
        }
        #endregion

        #region ban-ip
        public static Ban_ip BanIp(string ip, string reason = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Ban_ip ban_Ip = new Ban_ip(ip, reason);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(ban_Ip);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(ban_Ip);
            }
            return ban_Ip;
        }
        #endregion

        #region banlist
        public static Banlist BanlistPlayers(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Banlist banlist = new Banlist("players");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(banlist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(banlist);
            }
            return banlist;
        }

        public static Banlist BanlistIps(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Banlist banlist = new Banlist("ips");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(banlist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(banlist);
            }
            return banlist;
        }
        #endregion

        #region bossbar
        public static Bossbar BossbarAdd(ID id, string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarRemove(ID id, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarGetValue(ID id, string value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarGetPlayers(ID id, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, "players");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarGetMax(ID id, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, "max");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarGetVisible(ID id, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, "visible");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarSetColor(ID id, Type.Bossbar.Color color, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, color);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarSetMax(ID id, int max, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, "max", max);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarSetValue(ID id, int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, "value", value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarSetName(ID id, JsonText name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarSetStyle(ID id, Style style, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, style);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarSetVisible(ID id, bool visible, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, visible);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        public static Bossbar BossbarAddPlayer(ID id, Selector selector, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Bossbar bossbar = new Bossbar(id, "set", selector);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(bossbar);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(bossbar);
            }
            return bossbar;
        }

        #endregion

        #region clear
        public static Clear Clear(Selector target, ItemStack itemStack = null, int? count = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
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
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clear);
            }
            return clear;
        }

        #endregion
        
        #region clone
        public static Clone CloneReplaceForce(Pos begin, Pos end, Pos destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, "replace", "force");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneReplaceMove(Pos begin, Pos end, Pos destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, "replace", "move");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneReplaceNormal(Pos begin, Pos end, Pos destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, "replace", "normal");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneMaskedForce(Pos begin, Pos end, Pos destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, "masked", "force");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneMaskedMove(Pos begin, Pos end, Pos destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, "masked", "move");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneMaskedNormal(Pos begin, Pos end, Pos destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, "masked", "normal");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneFilteredForce(Pos begin, Pos end, Pos destination, BlockPredicate filter, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, filter, "force");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        public static Clone CloneFilteredMove(Pos begin, Pos end, Pos destination, BlockPredicate filter, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, filter, "move");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }


        public static Clone CloneFilteredNormal(Pos begin, Pos end, Pos destination, BlockPredicate filter, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Clone clone = new Clone(begin, end, destination, filter, "normal");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(clone);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(clone);
            }
            return clone;
        }

        #endregion

        #region data
        public static Data DataGet(NBTTag target, double? scale = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data = new Data(target.Container, target.Path, scale);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataMerge(DataArg targetPos, NBTTag nbt, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data = new Data(targetPos, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }
        
        public static Data DataModifySet(NBTTag target, NBTTag source, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, "set", source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, "set", source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataModifyPrepend<T>(NBTList<T> target, NBTTag source, bool serialize = true) where T : NBTTag
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, "prepend", source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, "prepend", source);
            }
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }
        
        public static Data DataModifyAppend<T>(NBTList<T> target, NBTTag source, bool serialize = true) where T : NBTTag
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, "append", source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, "append", source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataModifyPrepend<T>(NBTArray<T> target, NBTTag source, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            else if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, "prepend", source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, "prepend", source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataModifyAppend<T>(NBTArray<T> target, NBTTag source, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            else if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, "append", source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, "append", source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataModifyMerge(NBTCompound target, NBTTag source, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, "merge", source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, "merge", source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataModifyInsert<T>(NBTList<T> target, NBTTag source, int index, bool serialize = true) where T : NBTTag
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, index, source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, index, source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }
        
        public static Data DataModifyInsert<T>(NBTArray<T> target, NBTTag source, int index, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            else if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data;
            if (source.IsDynamic)
            {
                data = new Data(target.Container, target.Path, index, source.Container, source.Path);
            }
            else
            {
                data = new Data(target.Container, target.Path, index, source);
            };
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataRemove(NBTTag target, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data = new Data(target.Container, target.Path);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataRemove(Selector target, string path, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data = new Data(target, path);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }

        public static Data DataRemove(ID target, string path, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Data data = new Data(target, path);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(data);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(data);
            }
            return data;
        }
        #endregion

        #region datapack
        public static Datapack DatapackDisable(string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("disable", name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackEnable(string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("enable", name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackEnableAtFirst(string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("enable", name, "first");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackEnableAtLast(string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("enable", name, "last");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackEnableBefore(string name, string exist, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("enable", name, "before", exist);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackEnableAfter(string name, string exist, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("enable", name, "after", exist);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackList(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("list");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackListAvailable(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("list", "available");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        public static Datapack DatapackListEnabled(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Datapack datapack = new Datapack("list", "enabled");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(datapack);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(datapack);
            }
            return datapack;
        }

        #endregion

        #region debug

        public static Debug DebugStart(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Debug debug = new Debug("start");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(debug);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(debug);
            }
            return debug;
        }

        public static Debug DebugStop(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Debug debug = new Debug("stop");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(debug);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(debug);
            }
            return debug;
        }

        public static Debug DebugFunction(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Debug debug = new Debug("function");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(debug);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(debug);
            }
            return debug;
        }

        #endregion

        #region defaultgamemode

        public static Defaultgamemode DefaultgamemodeSet(Gamemodes gamemode, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Defaultgamemode defaultgamemode = new Defaultgamemode(gamemode);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(defaultgamemode);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(defaultgamemode);
            }
            return defaultgamemode;
        }

        #endregion

        #region deop
        public static Deop Deop(string player, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Deop deop = new Deop(player);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(deop);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(deop);
            }
            return deop;
        }
        #endregion

        #region difficulty

        public static Difficulty DifficultySet(Difficulties? difficulty = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Difficulty difficulty1 = new Difficulty(difficulty);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(difficulty1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(difficulty1);
            }
            return difficulty1;
        }

        #endregion

        #region effect
        public static Effect EffectGive(Selector player, ID effect, int seconds = 30, int amplifier = 0, bool hideParticles = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Effect effect1 = new Effect(player, effect, seconds, amplifier, hideParticles);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(effect1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(effect1);
            }
            return effect1;
        }

        public static Effect EffectClear(Selector player = null, ID effect = null, bool serialize = true)
        {
            
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Effect effect1 = new Effect("clear", player, effect);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(effect1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(effect1);
            }
            return effect1;
        }
        #endregion

        #region enchant
        public static Enchant Enchant(Selector player, ID enchantment, int level = 1, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Enchant enchant = new Enchant(player, enchantment, level);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(enchant);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(enchant);
            }
            return enchant;
        }
        #endregion

        #region experience
        public static Experience ExperienceAdd(Selector player, int amount, bool levels = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Experience experience = new Experience("add", player, amount, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(experience);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(experience);
            }
            return experience;
        }

        public static Experience ExperienceSet(Selector player, int amount, bool levels = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Experience experience = new Experience("set", player, amount, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(experience);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(experience);
            }
            return experience;
        }

        public static Experience ExperienceQuery(Selector player, bool levels = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Experience experience = new Experience(player, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(experience);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(experience);
            }
            return experience;
        }
        #endregion

        #region fill
        public static Fill FillDestory(Pos from, Pos to, BlockState block, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fill fill = new Fill(from, to, block, "destroy");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fill);
            }
            return fill;
        }

        public static Fill FillHollow(Pos from, Pos to, BlockState block, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fill fill = new Fill(from, to, block, "hollow");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fill);
            }
            return fill;
        }

        public static Fill FillKeep(Pos from, Pos to, BlockState block, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fill fill = new Fill(from, to, block, "keep");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fill);
            }
            return fill;
        }

        public static Fill FillOutline(Pos from, Pos to, BlockState block, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fill fill = new Fill(from, to, block, "outline");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fill);
            }
            return fill;
        }

        public static Fill FillReplace(Pos from, Pos to, BlockState block, BlockPredicate filter = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fill fill = new Fill(from, to, block, filter);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fill);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fill);
            }
            return fill;
        }
        #endregion

        #region fillbiome
        public static Fillbiome Fillbiome(Pos from = null, Pos to = null, ID biome = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fillbiome fillbiome = new Fillbiome(from, to, biome);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fillbiome);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fillbiome);
            }
            return fillbiome;
        }

        public static Fillbiome ReplaceBiome(Pos from = null, Pos to = null, ID biome = null, ID filter = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Fillbiome fillbiome = new Fillbiome("", from, to, biome, filter);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(fillbiome);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(fillbiome);
            }
            return fillbiome;
        }
        #endregion

        #region forceload
        public static Forceload ForceloadAdd(Pos from, Pos to, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Forceload forceload = new Forceload("add", from, to);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(forceload);
            }
            return forceload;
        }

        public static Forceload ForceloadRemove(Pos from, Pos to, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Forceload forceload = new Forceload("remove", from, to);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(forceload);
            }
            return forceload;
        }

        public static Forceload ForceLoadRemoveAll(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Forceload forceload = new Forceload();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(forceload);
            }
            return forceload;
        }

        public static Forceload ForceLoadQuery(Pos pos, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Forceload forceload = new Forceload("query", pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(forceload);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(forceload);
            }
            return forceload;
        }

        #endregion

        #region function
        public static Function Function(ID functionID, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Function function = new Function(functionID);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(function);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(function);
            }
            return function;
        }
        #endregion

        #region gamemode
        public static Gamemode GamemodeSet(Gamemodes gamemode, Selector target = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Gamemode gamemode1 = new Gamemode(gamemode, target);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(gamemode1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(gamemode1);
            }
            return gamemode1;
        }
        #endregion

        #region gamerule
        public static Gamerule Gamerule(string rule, string value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Gamerule gamerule = new Gamerule(rule, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(gamerule);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(gamerule);
            }
            return gamerule;
        }
        #endregion

        #region give 
        public static Give Give(Selector target, ItemStack item, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Give give = new Give(target, item);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(give);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(give);
            }
            return give;
        }
        #endregion

        #region help
        public static Help Help(string command = "", bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Help help = new Help(command);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(help);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(help);
            }
            return help;
        }
        #endregion

        #region item
        public static Item ItemModify(Pos pos, Slot slot, ID modifier, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(pos, slot, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemModify(Selector target, Slot slot, ID modifier, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(target, slot, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemReplace(Pos pos, Slot slot, ItemStack item, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(pos, slot, item);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemReplace(Selector target, Slot slot, ItemStack item, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(target, slot, item);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemReplaceFrom(Pos pos, Slot slot, Selector target, Slot slot2, ID modifier = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(pos, slot, target, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemReplaceFrom(Selector target, Slot slot, Selector target2, Slot slot2, ID modifier = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(target, slot, target2, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemReplaceFrom(Pos pos, Slot slot, Pos pos2, Slot slot2, ID modifier = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(pos, slot, pos2, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }

        public static Item ItemReplaceFrom(Selector target, Slot slot, Pos pos2, Slot slot2, ID modifier = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Item item1 = new Item(target, slot, pos2, slot2, modifier);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(item1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(item1);
            }
            return item1;
        }
        #endregion

        #region jfr
        public static Jfr JfrStart(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Jfr jfr = new Jfr("start");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(jfr);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(jfr);
            }
            return jfr;
        }

        public static Jfr JfrStop(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Jfr jfr = new Jfr("stop");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(jfr);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(jfr);
            }
            return jfr;
        }
        #endregion

        #region kick
        public static Kick Kick(Selector target, string reason = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Kick kick = new Kick(target, reason);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(kick);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(kick);
            }
            return kick;
        }
        #endregion

        #region kill
        public static Kill Kill(Selector target, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Kill kill = new Kill(target);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(kill);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(kill);
            }
            return kill;
        }
        #endregion

        #region list
        public static List List(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            List list = new List(null);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(list);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(list);
            }
            return list;
        }

        public static List ListUUID(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            List list = new List(114514);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(list);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(list);
            }
            return list;
        }

        #endregion

        #region locate
        public static Locate LocateBiome(ID biome, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Locate locate = new Locate("biome", biome);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(locate);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(locate);
            }
            return locate;
        }

        public static Locate LocatePoi(ID poi, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Locate locate = new Locate("poi", poi);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(locate);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(locate);
            }
            return locate;
        }

        public static Locate LocateStructure(ID structure, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Locate locate = new Locate("structure", structure);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(locate);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(locate);
            }
            return locate;
        }
        #endregion

        #region me
        public static Me Me(string action, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Me me = new Me(action);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(me);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(me);
            }
            return me;
        }
        #endregion

        #region msg
        public static Msg Msg(Selector player, string message, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Msg msg = new Msg(player, message);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(msg);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(msg);
            }
            return msg;
        }
        #endregion

        #region op
        public static Op Op(Selector player, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Op op = new Op(player);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(op);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(op);
            }
            return op;
        }
        #endregion

        #region pardon
        public static Pardon Pardon(string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Pardon pardon = new Pardon(name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(pardon);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(pardon);
            }
            return pardon;
        }

        public static Pardon PardonUUID(UUID uuid, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Pardon pardon = new Pardon(uuid);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(pardon);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(pardon);
            }
            return pardon;
        }
        #endregion

        #region pardon-ip
        public static Pardon_ip Pardon_ip(string ip, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Pardon_ip pardon_ip = new Pardon_ip(ip);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(pardon_ip);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(pardon_ip);
            }
            return pardon_ip;
        }
        #endregion

        #region particle
        public static Particle Particle(ID particle, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(particle, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle(ID particle, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(particle, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_dust(Type.Color color, float size, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(color, size, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_dust(Type.Color color, float size, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(color, size, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_dust_color_transition(Type.Color color1, float size, Type.Color color2, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(color1, size, color2, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_dust_color_transition(Type.Color color1, float size, Type.Color color2, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(color1, size, color2, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_block(BlockState block, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle("minecraft:block", block, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_block(BlockState block, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle("minecraft:block", block, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_falling_dust(BlockState block, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle("minecraft:falling_dust", block, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_falling_dust(BlockState block, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle("minecraft:falling_dust", block, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_item(ItemStack item, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(item, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_item(ItemStack item, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(item, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_shriek(int second, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(second, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }

        public static Particle Particle_shriek(int second, Pos pos, Vector3<float> delta, float speed, int count, bool force = false, Selector viewers = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Particle particle1 = new Particle(second, pos, delta, speed, count, force ? "force" : "normal", viewers);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(particle1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(particle1);
            }
            return particle1;
        }
        #endregion

        #region perf
        public static Perf PerfStart(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Perf perfStart1 = new Perf("start");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(perfStart1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(perfStart1);
            }
            return perfStart1;
        }

        public static Perf PerfStop(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Perf perfStart1 = new Perf("stop");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(perfStart1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(perfStart1);
            }
            return perfStart1;
        }
        #endregion

        #region place
        public static Place PlaceFeature(ID feature, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Place place = new Place(feature, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(place);
            }
            return place;
        }

        public static Place PlaceJigsaw(ID pool, ID target, int max_depth, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Place place = new Place(pool, target, max_depth, pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(place);
            }
            return place;
        }

        public static Place PlaceStructure(ID structure, Pos pos = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Place place = new Place(structure, pos, 114514);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(place);
            }
            return place;
        }

        public static Place PlaceTemplate(ID template, Pos pos = null, Rot rot = Rot._none, Mirror mirror = Mirror.none, float integrity = 1.0f, long? seed = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Place place = new Place(template, pos, rot, mirror, integrity, seed);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(place);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(place);
            }
            return place;
        }
        #endregion

        #region playsound
        public static Playsound Playsound(ID sound, Playsound.Source source, Selector targets, Pos pos = null, float volume = 1.0f, float pitch = 1.0f, float minvolumn = 0, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Playsound playsound = new Playsound(sound, source, targets, pos, volume, pitch, minvolumn);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(playsound);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(playsound);
            }
            return playsound;
        }
        #endregion

        #region publish
        public static Publish Publish(bool allowCommands = false, Gamemodes gamemode = Gamemodes.survival, int? port = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Publish publish = new Publish(allowCommands, gamemode, port);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(publish);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(publish);
            }
            return publish;
            {
            }
        }
        #endregion

        #region recipe
        public static Recipe RecipeGive(Selector targets, ID recipe = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Recipe recipe1 = new Recipe(Recipe.gt.give, targets, recipe);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(recipe1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(recipe1);
            }
            return recipe1;
        }

        public static Recipe RecipeTake(Selector targets, ID recipe = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Recipe recipe1 = new Recipe(Recipe.gt.take, targets, recipe);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(recipe1);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(recipe1);
            }
            return recipe1;
        }
        #endregion

        #region reload
        public static Reload Reload(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Reload reload = new Reload();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(reload);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(reload);
            }
            return reload;
        }
        #endregion

        #region save-all
        public static Save_all Save_All(bool flush = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Save_all save_All = new Save_all(flush);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(save_All);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(save_All);
            }
            return save_All;
        }
        #endregion

        #region save-off
        public static Save_off Save_Off(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Save_off save_Off = new Save_off();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(save_Off);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(save_Off);
            }
            return save_Off;
        }
        #endregion

        #region save-on
        public static Save_on Save_On(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Save_on save_On = new Save_on();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(save_On);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(save_On);
            }
            return save_On;
        }
        #endregion

        #region say
        /// <summary>
        /// /say
        /// </summary>
        /// <param name="text">要发送的文本</param>
        public static Say Say(string text, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Say say = new Say(text);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(say);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(say);
            }
            return say;
        }
        #endregion

        #region schedule
        public static Schedule ScheduleAppend(ID function, string time, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Schedule schedule = new Schedule(function, time, Schedule.ar.append);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(schedule);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(schedule);
            }
            return schedule;
        }

        public static Schedule ScheduleReplace(ID function, string time, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Schedule schedule = new Schedule(function, time, Schedule.ar.replace);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(schedule);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(schedule);
            }
            return schedule;
        }

        public static Schedule ScheduleClear(ID function, bool serialize = true)
        {

            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Schedule schedule = new Schedule(function);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(schedule);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(schedule);
            }
            return schedule;
        }
        #endregion

        #region scoreboard
        public static Scoreboard SbObjectAdd(SbObject sbObject, string rule, JsonText display = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(sbObject, rule, display);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbObjectList(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbObjectModifyDisplayName(string rule, JsonText display, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(rule, display);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbObjectModifyRenderType(SbObject objective, Scoreboard.hi renderType, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(objective, renderType);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbObjectRemove(SbObject objective, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbObjectSetdisplay(Scoreboard.DisplaySlot displaySlot, SbObject objective, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(displaySlot, objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerAdd(string target, SbObject objective, int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(Scoreboard.ars.add, target, objective, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerEnableTrigger(string target, SbObject trigger, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(target, trigger);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerGet(string target, SbObject objective, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(Scoreboard.eg.get, target, objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerList(string target, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(target);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerOperation(SbValue a, string operation, SbValue b, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(a.playerName, a.@object, operation, b.playerName, b.@object);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerRemove(string target, SbObject objective, int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(ars.remove, target, objective, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerReset(string target, SbObject objective = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(target, objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }

        public static Scoreboard SbPlayerSet(SbValue a, int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Scoreboard scoreboard = new Scoreboard(ars.set, a.playerName, a.@object, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(scoreboard);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(scoreboard);
            }
            return scoreboard;
        }
        #endregion

        #region seed
        public static Seed Seed(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Seed seed = new Seed();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(seed);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(seed);
            }
            return seed;
        }
        #endregion

        #region setblock
        public static Setblock Setblock(Pos pos, BlockState state = null, Setblock.dkr mode = Cmds.Setblock.dkr.replace, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Setblock setblock = new Setblock(pos, state, mode);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(setblock);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(setblock);
            }
            return setblock;
        }
        #endregion

        #region setidletimeout
        public static Setidletimeout Setidletimeout(int time, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Setidletimeout setidletimeout = new Setidletimeout(time);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(setidletimeout);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(setidletimeout);
            }
            return setidletimeout;
        }
        #endregion

        #region setworldspawn
        public static Setworldspawn Setworldspawn(Pos pos = null, Rotation angle = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Setworldspawn setworldspawn = new Setworldspawn(pos, angle);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(setworldspawn);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(setworldspawn);
            }
            return setworldspawn;
        }
        #endregion

        #region spawnpoint
        public static Spawnpoint Spawnpoint(Selector target, Pos pos = null, Rotation angle = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Spawnpoint spawnpoint = new Spawnpoint(target, pos, angle);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(spawnpoint);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(spawnpoint);
            }
            return spawnpoint;
        }
        #endregion

        #region spectate
        public static Spectate Spectate(Selector target, Selector source = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Spectate spectate = new Spectate(target, source);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(spectate);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(spectate);
            }
            return spectate;
        }

        public static Spectate StopSpectate(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Spectate spectate = new Spectate();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(spectate);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(spectate);
            }
            return spectate;
        }
        #endregion

        #region spreadplayers
        public static Spreadplayers SpreadPlayers(Pos2D pos, float spreadDistance, float maxRange, bool respectTeams, Selector targets, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Spreadplayers spreadplayers = new Spreadplayers(pos, spreadDistance, maxRange, respectTeams, targets);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(spreadplayers);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(spreadplayers);
            }
            return spreadplayers;
        }

        public static Spreadplayers SpreadPlayers(Pos2D pos, float spreadDistance, float maxRange, float maxheight, bool respectTeams, Selector targets, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Spreadplayers spreadplayers = new Spreadplayers(pos, spreadDistance, maxRange, maxheight, respectTeams, targets);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(spreadplayers);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(spreadplayers);
            }
            return spreadplayers;
        }
        #endregion

        #region stop
        public static Stop Stop(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Stop stop = new Stop();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(stop);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(stop);
            }
            return stop;
        }
        #endregion

        #region stopsound
        public static Stopsound Stopsound(Selector target, Stopsound.Source source = Cmds.Stopsound.Source.master, string sound = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Stopsound stopsound = new Stopsound(target, source, sound);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(stopsound);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(stopsound);
            }
            return stopsound;
        }
        #endregion

        #region summon
        public static Summon Summon(ID entity, Pos pos = null, NBTTag nbt = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Summon summon = new Summon(entity, pos, nbt);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(summon);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(summon);
            }
            return summon;
        }
        #endregion

        #region tag
        public static Tag TagAdd(Selector targets, string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tag tag = new Tag(targets, Tag.ar.add, name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tag);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tag);
            }
            return tag;
        }

        public static Tag TagRemove(Selector targets, string name, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tag tag = new Tag(targets, Tag.ar.remove, name);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tag);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tag);
            }
            return tag;
        }

        public static Tag TagList(Selector targets, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tag tag = new Tag(targets);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tag);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tag);
            }
            return tag;
        }
        #endregion

        #region team
        public static Team TeamList(string team = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamAdd(string team, JsonText displayName = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, displayName);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamRemove(string team, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(Team.re.remove, team);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamEmpty(string team, bool serialize = true)
        {

            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(Team.re.empty, team);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamJoin(string team, Selector members = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, members);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamLeave(Selector members, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(members);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyDisplayName(string team, JsonText displayName, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionJSON.displayName, displayName);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyColor(string team, Type.Color.Colors color, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionColor.color, color);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyFriendlyFire(string team, bool allowed, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionBool.friendlyFire, allowed);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifySeeFriendlyInvisibles(string team, bool allowed, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionBool.seeFriendlyInvisibles, allowed);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyNametagVisibility(string team, Team.ArgVisibility visibility, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionVisibility.nametagVisibility, visibility);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyDeathMessageVisibility(string team, Team.ArgVisibility visibility, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionVisibility.deathMessageVisibility, visibility);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyCollisionRule(string team, Team.ArgCollision rule, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionCollision.collisionRule, rule);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifyPrefix(string team, JsonText prefix, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionJSON.prefix, prefix);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }

        public static Team TeamModifySuffix(string team, JsonText suffix, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Team teamcmd = new Team(team, Team.OptionJSON.suffix, suffix);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teamcmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teamcmd);
            }
            return teamcmd;
        }
        #endregion

        #region teammsg
        public static Teammsg Teammsg(string msg, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Teammsg teammsg = new Teammsg(msg);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teammsg);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teammsg);
            }
            return teammsg;
        }
        #endregion

        #region teleport
        public static Teleport Teleport(Selector destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Teleport teleport = new Teleport(destination);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teleport);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teleport);
            }
            return teleport;
        }

        public static Teleport Teleport(Selector target, Selector destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Teleport teleport = new Teleport(target, destination);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teleport);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teleport);
            }
            return teleport;
        }

        public static Teleport Teleport(Selector targets, Pos location, Rotation rotation = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Teleport teleport = new Teleport(targets, location, rotation);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teleport);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teleport);
            }
            return teleport;
        }

        public static Teleport Teleport(Selector targets, Pos location, Pos facingLocation, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Teleport teleport = new Teleport(targets, location, facingLocation);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teleport);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teleport);
            }
            return teleport;
        }

        public static Teleport Teleport(Selector targets, Pos location, Selector facingEntity, Teleport.ef facingEntityAnchor = Cmds.Teleport.ef.feet, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Teleport teleport = new Teleport(targets, location, facingEntity, facingEntityAnchor);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(teleport);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(teleport);
            }
            return teleport;
        }
        #endregion

        #region tell
        public static Tell Tell(Selector target, string msg, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tell tell = new Tell(target, msg);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tell);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tell);
            }
            return tell;
        }
        #endregion

        #region tellraw
        public static Tellraw Tellraw(Selector target, JsonText message, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tellraw tellraw = new Tellraw(target, message);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tellraw);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tellraw);
            }
            return tellraw;
        }
        #endregion

        #region time
        public static Time TimeAddBySecond(int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Time time = new Time(value + "s");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(time);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(time);
            }
            return time;
        }
        
        public static Time TimeAddByDay(int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Time time = new Time(value + "d");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(time);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(time);
            }
            return time;
        }
        
        public static Time TimeAddByTick(int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Time time = new Time(value + "t");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(time);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(time);
            }
            return time;
        }
        
        public static Time TimeSet(int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Time time = new Time(value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(time);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(time);
            }
            return time;
        }
        
        public static Time TimeSet(Time.TimeSpec value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Time time = new Time(value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(time);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(time);
            }
            return time;
        }
        
        public static Time TimeQuery(Time.TimeType timeType, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Time time = new Time(timeType);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(time);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(time);
            }
            return time;
        }
        #endregion

        #region title
        public static Title TitleClear(Selector player, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Title title = new Title(player, Title.Option.clear);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(title);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(title);
            }
            return title;
        }

        public static Title TitleReset(Selector player, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Title title = new Title(player, Title.Option.reset);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(title);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(title);
            }
            return title;
        }

        public static Title TitleAtTitle(Selector player, JsonText title, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Title titleCmd = new Title(player, Title.TitleType.title, title);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(titleCmd);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(titleCmd);
            }
            return titleCmd;
        }

        public static Title TitleAtSubtitle(Selector player, JsonText subtitle, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Title title = new Title(player, Title.TitleType.subtitle, subtitle);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(title);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(title);
            }
            return title;
        }

        public static Title TitleAtActionbar(Selector player, JsonText actionbar, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Title title = new Title(player, Title.TitleType.actionbar, actionbar);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(title);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(title);
            }
            return title;
        }

        public static Title TitleWithFade(Selector player, int fadeIn, int stay, int fadeOut, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Title title = new Title(player, fadeIn, stay, fadeOut);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(title);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(title);
            }
            return title;
        }
        #endregion

        #region tm
        public static Tm Tm(string msg, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tm tm = new Tm(msg);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tm);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tm);
            }
            return tm;
        }
        #endregion

        #region tp
        public static Tp Tp(Selector destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tp tp = new Tp(destination);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tp);
            }
            return tp;
        }

        public static Tp Tp(Selector target, Selector destination, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tp tp = new Tp(target, destination);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tp);
            }
            return tp;
        }

        public static Tp Tp(Selector targets, Pos location, Rotation rotation = null, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tp tp = new Tp(targets, location, rotation);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tp);
            }
            return tp;
        }

        public static Tp Tp(Selector targets, Pos location, Pos facingLocation, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tp tp = new Tp(targets, location, facingLocation);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tp);
            }
            return tp;
        }

        public static Tp Tp(Selector targets, Pos location, Selector facingEntity, Tp.ef facingEntityAnchor = Cmds.Tp.ef.feet, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Tp tp = new Tp(targets, location, facingEntity, facingEntityAnchor);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(tp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(tp);
            }
            return tp;
        }
        #endregion

        #region trigger
        public static Trigger TriggerAdd(SbObject objective, int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Trigger trigger = new Trigger(objective, Trigger.As.add, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(trigger);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(trigger);
            }
            return trigger;
        }

        public static Trigger TriggerSet(SbObject objective, int value, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Trigger trigger = new Trigger(objective, Trigger.As.set, value);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(trigger);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(trigger);
            }
            return trigger;
        }

        public static Trigger TriggerCheck(SbObject objective, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Trigger trigger = new Trigger(objective);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(trigger);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(trigger);
            }
            return trigger;
        }
        #endregion

        #region w
        public static W W(Selector target, string msg, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            W w = new W(target, msg);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(w);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(w);
            }
            return w;
        }
        #endregion

        #region weather
        public static Weather Weather(Weather.WeatherType weatherType, int duration = 300, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Weather weather = new Weather(weatherType, duration);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(weather);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(weather);
            }
            return weather;
        }
        #endregion

        #region whitelist
        public static Whitelist WhitelistAdd(Selector player, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Whitelist whitelist = new Whitelist(player, Whitelist.ar.add);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(whitelist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(whitelist);
            }
            return whitelist;
        }

        public static Whitelist WhitelistRemove(Selector player, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Whitelist whitelist = new Whitelist(player, Whitelist.ar.remove);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(whitelist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(whitelist);
            }
            return whitelist;
        }

        public static Whitelist WhitelistList(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Whitelist whitelist = new Whitelist(Whitelist.loor.list);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(whitelist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(whitelist);
            }
            return whitelist;
        }

        public static Whitelist WhitelistOn(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Whitelist whitelist = new Whitelist(Whitelist.loor.on);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(whitelist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(whitelist);
            }
            return whitelist;
        }

        public static Whitelist WhitelistOff(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Whitelist whitelist = new Whitelist(Whitelist.loor.off);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(whitelist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(whitelist);
            }
            return whitelist;
        }

        public static Whitelist WhitelistReload(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Whitelist whitelist = new Whitelist(Whitelist.loor.reload);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(whitelist);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(whitelist);
            }
            return whitelist;
        }
        #endregion
        
        #region worldborder
        public static Worldborder WorldborderAdd(double distance, int time = 0, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(Worldborder.As.add, distance, time);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        public static Worldborder WorldborderCenter(Pos2D pos, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(pos);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        public static Worldborder WorldborderSetDamageAmount(float damagePerBlock, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(damagePerBlock);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        public static Worldborder WorldborderSetDamageBuffer(double distance, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(distance);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        public static Worldborder WorldborderGet(bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder();
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        public static Worldborder WorldborderSet(double distance, int time = 0, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(Worldborder.As.set, distance, time);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        public static Worldborder WorldborderSetWarningDistance(int distance, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(Worldborder.dt.distance, distance);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }
        
        public static Worldborder WorldborderSetWarningTime(int time, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Worldborder worldborder = new Worldborder(Worldborder.dt.time, time);
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(worldborder);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(worldborder);
            }
            return worldborder;
        }

        #endregion

        #region xp
        public static Xp XpAdd(Selector player, int amount, bool levels = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Xp xp = new Xp("add", player, amount, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(xp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(xp);
            }
            return xp;
        }

        public static Xp XpSet(Selector player, int amount, bool levels = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Xp xp = new Xp("set", player, amount, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(xp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(xp);
            }
            return xp;
        }

        public static Xp XpQuery(Selector player, bool levels = false, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return null;
            }
            Xp xp = new Xp(player, levels ? "levels" : "points");
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(xp);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(xp);
            }
            return xp;
        }
        #endregion

        public static void Comment(string comment)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }else if(DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return;
            }
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(new Comment(comment));
        }

        /// <summary>
        /// 将一个已有的命令添加到当前的命令函数中
        /// </summary>
        /// <param name="command">要添加的命令</param>
        /// <param name="serialize">是否序列化。默认为是</param>
        public static void AddCommand(Command command, bool serialize = true)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            else if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return;
            }
            DatapackInfo.functions[StackManager.GetStackName()[0]].AddCommand(command);
            if (serialize)
            {
                DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(command);
            }
        }
        
        /// <summary>
        /// 将当前命令函数的最后一行命令删除
        /// </summary>
        /// <exception cref="FunctionNotRegistryException"></exception>
        public static void RemoveCommand()
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            else if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return;
            }
            DatapackInfo.functions[StackManager.GetStackName()[0]].RemoveCommand();
        }

        /// <summary>
        /// 将当前命令函数中的此未序列化的命令序列化
        /// </summary>
        /// <param name="command"></param>
        public static void Serialize(Command command)
        {
            if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.UnRegestered)
            {
                throw new FunctionNotRegistryException("未注册的函数:" + new StackFrame(1).GetMethod().Name);
            }
            else if (DatapackInfo.GetFunctionState() == DatapackInfo.FunctionState.Forbidden)
            {
                return;
            }
            DatapackInfo.functions[StackManager.GetStackName()[0]].Serialize(command);
        }

    }
}
