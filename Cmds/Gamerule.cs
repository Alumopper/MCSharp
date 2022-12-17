using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 设置或查询游戏规则
    /// </summary>
    public class Gamerule : Command
    {
        #region gamerule
        /// <summary>
        /// 是否在聊天框中公告玩家进度的达成
        /// </summary>
        public static string announceAdvancements = "announceAdvancements";
        /// <summary>
        /// 命令方块执行命令时是否在聊天框中向管理员显示
        /// </summary>
        public static string commandBlockOutput = "commandBlockOutput";
        /// <summary>
        /// 是否让服务器停止检查使用鞘翅玩家的移动速度。有助于减轻因服务器延迟而导致的飞行卡顿，但有可能导致生存模式下玩家飞行过快（作弊）
        /// </summary>
        public static string disableElytraMovementCheck = "disableElytraMovementCheck";
        /// <summary>
        /// 是否禁用袭击
        /// </summary>
        public static string disableRaids = "disableRaids";
        /// <summary>
        /// 是否进行昼夜更替和月相变化
        /// </summary>
        public static string doDaylightCycle = "doDaylightCycle";
        /// <summary>
        /// 非生物实体是否掉落物品
        /// </summary>
        public static string doEntityDrops = "doEntityDrops";
        /// <summary>
        /// 火是否蔓延及自然熄灭
        /// </summary>
        public static string doFireTick = "doFireTick";
        /// <summary>
        /// 玩家死亡时是否不显示死亡界面直接重生
        /// </summary>
        public static string doImmediateRespawn = "doImmediateRespawn";
        /// <summary>
        /// 幻翼是否在夜晚生成
        /// </summary>
        public static string doInsomnia = "doInsomnia";
        /// <summary>
        /// 玩家的合成配方是否需要解锁才能使用
        /// </summary>
        public static string doLimitedCrafting = "doLimitedCrafting";
        /// <summary>
        /// 生物在死亡时是否掉落物品
        /// </summary>
        public static string doMobLoot = "doMobLoot";
        /// <summary>
        /// 生物是否自然生成。不影响刷怪笼
        /// </summary>
        public static string doMobSpawning = "doMobSpawning";
        /// <summary>
        /// 控制灾厄巡逻队的生成
        /// </summary>
        public static string doPatrolSpawning = "doPatrolSpawning";
        /// <summary>
        /// 方块被破坏时是否掉落物品
        /// </summary>
        public static string doTileDrops = "doTileDrops";
        /// <summary>
        /// 控制流浪商人的生成
        /// </summary>
        public static string doTraderSpawning = "doTraderSpawning";
        /// <summary>
        /// 监守者是否生成
        /// </summary>
        public static string doWardenSpawning = "doWardenSpawning";
        /// <summary>
        /// 天气是否变化
        /// </summary>
        public static string doWeatherCycle = "doWeatherCycle";
        /// <summary>
        /// 玩家是否承受窒息伤害
        /// </summary>
        public static string drowningDamage = "drowningDamage";
        /// <summary>
        /// 玩家是否承受跌落伤害
        /// </summary>
        public static string fallDamage = "fallDamage";
        /// <summary>
        /// 玩家是否承受火焰伤害
        /// </summary>
        public static string fireDamage = "fireDamage";
        /// <summary>
        /// 当被激怒的条件敌对生物的目标玩家死亡时，该生物是否恢复未激怒状态
        /// </summary>
        public static string forgiveDeadPlayers = "forgiveDeadPlayers";
        /// <summary>
        /// 玩家是否承受冰冻伤害
        /// </summary>
        public static string freezeDamage = "freezeDamage";
        /// <summary>
        /// 玩家死亡后是否保留物品栏物品、经验（死亡时物品不掉落、经验不清空）
        /// </summary>
        public static string keepInventory = "keepInventory";
        /// <summary>
        /// 是否在服务器日志中记录管理员使用过的命令
        /// </summary>
        public static string logAdminCommands = "logAdminCommands";
        /// <summary>
        /// 决定了连锁型命令方块能连锁执行的总数量
        /// </summary>
        public static string maxCommandChainLength = "maxCommandChainLength";
        /// <summary>
        /// 玩家或生物能同时推动其他可推动实体的数量，超过此数量时将承受每半秒3的窒息伤害。设置成0可以停用这个规则。此规则影响生存模式和冒险模式的玩家，以及除蝙蝠外的所有生物。可推动实体包括非旁观模式玩家、除蝙蝠外的所有生物、船和矿车
        /// </summary>
        public static string maxEntityCramming = "maxEntityCramming";
        /// <summary>
        /// 生物是否能够进行破坏性行为，包括苦力怕、僵尸、末影人、恶魂、凋灵、末影龙、兔子、绵羊、村民和雪傀儡是否能放置、修改或破坏方块，生物是否能捡拾物品，以及唤魔者是否能将蓝色的绵羊变为红色[仅Java版]。这个规则也会影响生物（如僵尸猪灵和溺尸）寻找海龟蛋的能力。这还将会阻止村民的繁殖。这一游戏规则不会影响非生物实体，包括TNT和末地水晶。
        /// </summary>
        public static string mobGriefing = "mobGriefing";
        /// <summary>
        /// 玩家是否能在饥饿值足够时自然恢复生命值（不影响外部治疗效果，如金苹果、生命恢复状态效果等）。
        /// </summary>
        public static string naturalRegeneration = "naturalRegeneration";
        /// <summary>
        /// 设置跳过夜晚所需的入睡玩家所占百分比。设置为0时，1个玩家入睡即可跳过夜晚。设置为大于100的值会使玩家无法通过入睡跳过夜晚。
        /// </summary>
        public static string playersSleepingPercentage = "playersSleepingPercentage";
        /// <summary>
        /// 每游戏刻每区段中随机的方块刻发生的频率（例如植物生长，树叶腐烂等）。为0时禁用随机刻，较高的数字将增大随机刻频率。
        /// </summary>
        public static string randomTickSpeed = "randomTickSpeed";
        /// <summary>
        /// 调试屏幕是否简化而非显示详细信息；同时影响实体碰撞箱（通过F3 + B查看）和区块边界（通过F3 + G查看）效果的显示。
        /// </summary>
        public static string reducedDebugInfo = "reducedDebugInfo";
        /// <summary>
        /// 玩家执行命令的返回信息是否在聊天框中显示。同时影响命令方块是否保存命令输出文本。
        /// </summary>
        public static string sendCommandFeedback = "sendCommandFeedback";
        /// <summary>
        /// 是否在聊天框中显示玩家的死亡信息。同样影响是否在宠物（狼、猫和鹦鹉）死亡时通知它的主人。
        /// </summary>
        public static string showDeathMessages = "showDeathMessages";
        /// <summary>
        /// 首次进入服务器的玩家和没有重生点的死亡玩家在重生时与世界重生点坐标的距离。
        /// </summary>
        public static string spawnRadius = "spawnRadius";
        /// <summary>
        /// 是否允许旁观模式的玩家生成区块
        /// </summary>
        public static string spectatorsGenerateChunks = "spectatorsGenerateChunks";
        /// <summary>
        /// 被激怒的条件敌对生物是否攻击附近任何玩家（而非只攻击激怒它们的玩家）。当forgiveDeadPlayers关闭时会有更好的效果。
        /// </summary>
        public static string universalAnger = "universalAnger";
        /// <summary>
        /// 由方块源（除TNT）爆炸炸毁的方块是否会有概率不掉落。
        /// </summary>
        public static string blockExplosionDropDecay = "blockExplosionDropDecay";
        /// <summary>
        /// 玩家是否能听到可无视距离播放给全部玩家的特定游戏事件音效。
        /// </summary>
        public static string globalSoundEvents = "globalSoundEvents";
        /// <summary>
        /// 流动的熔岩是否可产生熔岩源。
        /// </summary>
        public static string lavaSourceConversion = "lavaSourceConversion";
        /// <summary>
        /// 由生物源爆炸炸毁的方块是否会有概率不掉落。
        /// </summary>
        public static string mobExplosionDropDecay = "mobExplosionDropDecay";
        /// <summary>
        /// 下雪时可在一格方块空间内堆积的雪的最高层数。
        /// </summary>
        public static string snowAccumulationHeight = "snowAccumulationHeight";
        /// <summary>
        /// 由TNT爆炸炸毁的方块是否会有概率不掉落。
        /// </summary>
        public static string tntExplosionDropDecay = "tntExplosionDropDecay";
        /// <summary>
        /// 流动的水是否可产生水源。
        /// </summary>
        public static string waterSourceConversion = "waterSourceConversion";
        #endregion

        string[] rules = new string[]
        {
            "announceAdvancements",
            "commandBlockOutput",
            "disableElytraMovementCheck",
            "disableRaids",
            "doDaylightCycle",
            "doEntityDrops",
            "doFireTick",
            "doLimitedCrafting",
            "doMobLoot",
            "doMobSpawning",
            "doPatrolSpawning",
            "doTileDrops",
            "doTraderSpawning",
            "doWeatherCycle",
            "drowningDamage",
            "fallDamage",
            "fireDamage",
            "forgiveDeadPlayers",
            "keepInventory",
            "logAdminCommands",
            "maxCommandChainLength",
            "maxEntityCramming",
            "mobGriefing",
            "naturalRegeneration",
            "randomTickSpeed",
            "reducedDebugInfo",
            "sendCommandFeedback",
            "showDeathMessages",
            "spectatorsGenerateChunks",
            "universalAnger",
            "blockExplosionDropDecay",
            "globalSoundEvents",
            "lavaSourceConversion",
            "mobExplosionDropDecay",
            "snowAccumulationHeight",
            "tntExplosionDropDecay",
            "waterSourceConversion",
        };

        string gamerule;
        object value;

        /// <summary>
        /// gamerule &lt;gamerule> [value]
        /// </summary>
        public Gamerule(string gamerule, object value)
        {
            if (!rules.Contains(gamerule))
            {
                throw new ArgumentNotMatchException("参数错误: " + gamerule + "不存在的游戏规则");
            }
            this.gamerule = gamerule;
            this.value = value;
        }

        public override string ToString()
        {
            return "gamerule " + gamerule + (value == null ? "" : (" " + value));
        }
    }
}
