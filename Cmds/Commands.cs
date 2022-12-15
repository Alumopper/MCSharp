using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MCSharp;
using MCSharp.Exception;
using MCSharp.Type;

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
        
        
        public static Function Function(ID functionID)
        {
            if (!DatapackInfo.FunctionHasRegistry())
            {
                throw new FunctionNotRegistryException("未注册的函数:"+ new StackFrame(1).GetMethod().Name);
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
