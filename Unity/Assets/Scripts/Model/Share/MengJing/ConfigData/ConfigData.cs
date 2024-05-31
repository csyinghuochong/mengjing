using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    public static class ConfigData
    {
        // 个人副本  gm账号显示副本和新地图,大于等于指定副本id不显示
        [StaticField]
        public static int GMDungeonId = 1060003;

        [StaticField]
        public static string ChangeOccItem = "10000178;1";

        [StaticField]
        public static int BuChangZone = 5;

        [StaticField]
        public static int BuChangEnd = 20221130;

        [StaticField]
        public static bool NetVersion = true;

        //副本深渊模式创建怪物   参数：场景ID,MonsterPositionConfigID
        [StaticField]
        public static Dictionary<int, int> ShenYuanCreateConfig = new Dictionary<int, int>()
        {
            { 110001, 90011 },
            { 110002, 90012 },
            { 110003, 90013 },
            { 110004, 90014 },
            { 110005, 90015 },
        };

        [StaticField]
        public static bool IsShowLieOpen = false;

        /// <summary>
        /// 赛季开始时间 . 已废弃
        /// </summary>
        //public static long SeasonOpenTime = 1701360000000;

        //赛季结束时间 . 已废弃
        //public static long SeasonCloseTime = 1713715200000;

        /// <summary>
        /// 赛季开时间
        /// </summary>
        [StaticField]
        public static List<KeyValuePairLong> SeasonTimeList = new List<KeyValuePairLong>()
        {
            new KeyValuePairLong() { KeyId = 0, Value = 1701360000000, Value2 = 1713715200000 },
            new KeyValuePairLong() { KeyId = 1, Value = 1713715200001, Value2 = 1721577600000 }
        };

        /// <summary>
        /// 新人抽奖 //KeyId权重 value道具..     第七天是武器ComHelp.GetWelfareWeapon
        /// </summary>
        [StaticField]
        public static List<KeyValuePair> WelfareDrawList = new List<KeyValuePair>
        {
            //第一天
            new KeyValuePair() { KeyId = 10, Value = "10000161;2" },
            //第二天
            new KeyValuePair() { KeyId = 10, Value = "11200000;1" },
            //第三天
            new KeyValuePair() { KeyId = 0, Value = "10010072;1" },
            //第四天
            new KeyValuePair() { KeyId = 10, Value = "10010033;1" },
            //第五天
            new KeyValuePair() { KeyId = 0, Value = "10010093;1" },
            //第六天
            new KeyValuePair() { KeyId = 10, Value = "10010073;1" },
            //第七天
            new KeyValuePair() { KeyId = 0, Value = "1;1" },
        };

        /// <summary>
        /// 投资金额, 只可以投六天，第七天领取奖励。  投资金额-》礼包
        /// </summary>
        [StaticField]
        public static List<KeyValuePair> WelfareInvestList = new List<KeyValuePair>()
        {
            new KeyValuePair() { KeyId = 50000, Value = "10000122;1" },
            new KeyValuePair() { KeyId = 100000, Value = "10010088;1" },
            new KeyValuePair() { KeyId = 150000, Value = "10010083;5" },
            new KeyValuePair() { KeyId = 200000, Value = "10010033;1" },
            new KeyValuePair() { KeyId = 250000, Value = "10000158;1" },
            new KeyValuePair() { KeyId = 300000, Value = "10010046;1" },
        };

        /// <summary>
        /// 完成每天目标任务的奖励
        /// </summary>
        [StaticField]
        public static List<string> WelfareTaskReward = new List<string>()
        {
            "10000161;1@10010033;1@10010092;1",
            "10000161;1@10010051;1@10010093;1",
            "10000161;1@10000158;1@10010046;1",
            "10000161;1@10010033;1@10010086;1",
            "10000161;1@10010040;1@10000158;1",
            "10000161;1@10000143;3@10010086;1",
            "10000161;1@10049003;1@10010052;1"
        };

        /// <summary>
        /// key权重  value道具
        /// </summary>
        [StaticField]
        public static List<KeyValuePair> ExpToItemList = new List<KeyValuePair>()
        {
            new KeyValuePair() { KeyId = 100, Value = "10010040;1" }, //高级藏宝图
            new KeyValuePair() { KeyId = 100, Value = "10000141;1" }, //洗炼袋子
            new KeyValuePair() { KeyId = 100, Value = "10000152;1" }, //璀璨传承
            new KeyValuePair() { KeyId = 50, Value = "10000165;1" }, //神话之灵
            new KeyValuePair() { KeyId = 200, Value = "10010045;1" }, //金条
            new KeyValuePair() { KeyId = 100, Value = "10010094;1" }, //超级宠物蛋
            new KeyValuePair() { KeyId = 100, Value = "10010093;1" }, //珍贵宠物蛋
            new KeyValuePair() { KeyId = 50, Value = "10010096;1" }, //超级宠之晶
            new KeyValuePair() { KeyId = 50, Value = "10000150;1" }, //深渊凭证
            new KeyValuePair() { KeyId = 50, Value = "10000135;1" }, //金盒
        };

        /// <summary>
        /// 累充奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> RechargeReward =
                new Dictionary<int, string>()
                {
                    { 50, "10031014;1@10000143;5@10010045;1@10010086;2@10000141;1" },
                    { 98, "10000202;1@10000143;12@10010045;2@10010086;3@10000150;1" }
                };

        //家园相关
        //开启牧场地块花费 0开始
        [StaticField]
        public static Dictionary<int, int> JiaYuanFarmOpen =
                new Dictionary<int, int>()
                {
                    { 4, 5000 },
                    { 5, 10000 },
                    { 6, 20000 },
                    { 7, 30000 },
                    { 8, 40000 },
                    { 9, 55000 },
                    { 10, 70000 },
                    { 11, 85000 },
                    { 12, 100000 },
                    { 13, 120000 },
                    { 14, 150000 },
                    { 15, 180000 },
                    { 16, 210000 },
                    { 17, 250000 },
                    { 18, 300000 },
                    { 19, 400000 }
                };

        /// <summary>
        /// 消费钻石奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> ConsumeDiamondReward =
                new Dictionary<int, string>() { { 100, "1;1000" }, { 200, "1;1000" } };

        /// <summary>
        /// 红包奖励
        /// </summary>
        [StaticField]
        public static int HongBaoDropId = 601901001;

        /// <summary>
        /// 抽奖次数奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> ChouKaNumberReward = new Dictionary<int, string>() { { 1, "1;1" }, { 3, "1;3" }, { 10, "1;10" }, };

        /// <summary>
        /// 单个兑换奖励. 单个字可以兑换10万金币
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> DuiHuanWordReward = new Dictionary<int, string>()
        {
            { 10030013, "1;100000" }, { 10030014, "1;100000" }, { 10030015, "1;100000" }, { 10030016, "1;100000" },
        };

        /// <summary>
        /// 抽卡消耗道具(幸运卷轴)
        /// </summary>
        [StaticField]
        public static int Chou2CostItem = 10030013;

        //一套字可以兑换一个金条.  DuiHuanWordReward.keys
        [StaticField]
        public static string GroupsWordReward = "10010045;1";

        [StaticField]
        public static List<string> WelfareChouKaList = new List<string>()
        {
            "15305001;1@10024002;1",
            "15305001;1@15305002;1",
            "15305001;1",
            "10045105;1",
            "15305001;1@10024002;1",
            "15305001;1@15305002;1",
            "15305001;1",
            "10045105;1",
        };

        /// <summary>
        /// 单笔充值奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> SingleRechargeReward = new Dictionary<int, string>()
        {
            { 6, "1;100000@10000122;1@10010086;1" },
            { 30, "10000141;1@10000164;1@10000158;1" },
            { 50, "10010045;1@10000164;1@10000158;2@10010079;1" },
            { 98, "10000135;1@10000164;1@10010086;2@10010079;1" },
            { 198, "10000134;1@10000150;1@10010026;1@10000137;1@10010053;1" },
            { 298, "10000134;1@10000150;1@10010026;1@10000138;1@10010094;1" },
            { 488, "10049101;1@10000150;1@10010026;1@10000137;2@10000143;5" },
            { 648, "10000134;1@10049101;1@10000150;1@10010026;1@10000138;2@10000143;10" }
        };

        /// <summary>
        /// 每日礼包
        /// </summary>
        [StaticField]
        public static Dictionary<int, KeyValuePair> LiBaoList =
                new Dictionary<int, KeyValuePair>()
                {
                    { 1, new KeyValuePair() { Value = "3;900", Value2 = "10030013;1@10030013;1" } }, //Value消耗钻石Value2道具
                    { 2, new KeyValuePair() { Value = "3;900", Value2 = "10030013;1@10030013;1" } },
                    { 3, new KeyValuePair() { Value = "3;900", Value2 = "10030013;1@10030013;1" } },
                };

        /// <summary>
        /// 在野外击败怪物时会掉落元宵和饺子, 喂食道具会获得奖励哦
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> FeedItemReward = new Dictionary<int, string>() { { 10030013, "1;100000" }, { 10030014, "1;100000" }, };

        /// <summary>
        /// 抽奖消耗道具
        /// </summary>
        [StaticField]
        public static string ChouKaCostItem = "1;100";

        /// <summary>
        /// 施法前吟唱时给自己添加一个buff
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> SingingBuffList =
                new Dictionary<int, int>
                {
                    //驭剑士光能击吟唱为霸体状态
                    { 61022102, 80001033 },
                    { 61022103, 80001033 },
                    { 61022104, 80001033 },
                    { 61022105, 80001033 },
                    { 61022106, 80001033 },
                };

        /// <summary>
        /// 序列号奖励 奖励最多不超过五个格子 
        /// </summary>
        [StaticField]
        public static Dictionary<long, string> SerialReward =
                new Dictionary<long, string>()
                {
                    //评论奖励   金币100000  钻石 500    藏宝图 * 1   领主刷新券 * 1
                    { 1, "1;100000@3;500@10010039;1@10010046;1" },
                    { 2, "1;100000@3;500@10010039;1@10010046;1" },
                    { 3, "1;50000@10000101;1" },
                    { 4, "1;100000@3;500@10010039;1@10010046;1" },
                    { 5, "1;100000@3;500@10010039;1@10010046;1" },
                    { 6, "1;100000@3;500@10010039;1@10010046;1" },
                    { 7, "1;100000@3;500@10010039;1@10010046;1" },
                };

        //购买背包
        [StaticField]
        public static List<BuyCellCost> BuyBagCellCosts = new List<BuyCellCost>
        {
            new BuyCellCost { Cost = "10000156;1", Get = "10010041;5" },
            new BuyCellCost { Cost = "10000156;1", Get = "10010046;1" },
            new BuyCellCost { Cost = "10000156;1", Get = "10010093;1" },
            new BuyCellCost { Cost = "10000156;1", Get = "10000104;1" },
            new BuyCellCost { Cost = "10000156;1", Get = "10000143;5" },
            new BuyCellCost { Cost = "10000156;1", Get = "10010088;2" },
            new BuyCellCost { Cost = "10000156;1", Get = "10000150;1" },
            new BuyCellCost { Cost = "10000156;1", Get = "10000141;1" },
            new BuyCellCost { Cost = "10000156;1", Get = "10010086;2" },
            new BuyCellCost { Cost = "10000156;1", Get = "10010026;1" },
        };

        //购买仓库
        [StaticField]
        public static List<BuyCellCost> BuyStoreCellCosts = new List<BuyCellCost>()
        {
            //仓库1
            new BuyCellCost { Cost = "3;360", Get = "10010083;5" },
            new BuyCellCost { Cost = "3;360", Get = "10010085;200" },
            new BuyCellCost { Cost = "3;360", Get = "10010039;1" },
            new BuyCellCost { Cost = "3;360", Get = "10010046;1" },
            new BuyCellCost { Cost = "3;360", Get = "10000143;2" },
            new BuyCellCost { Cost = "3;360", Get = "10010041;1" },
            new BuyCellCost { Cost = "3;360", Get = "10000101;1" },
            new BuyCellCost { Cost = "3;360", Get = "10000122;1" },
            new BuyCellCost { Cost = "3;360", Get = "10000132;10" },
            new BuyCellCost { Cost = "3;360", Get = "10000143;2" },

            //仓库2
            new BuyCellCost { Cost = "3;480", Get = "10010042;5" },
            new BuyCellCost { Cost = "3;480", Get = "10000102;1" },
            new BuyCellCost { Cost = "3;480", Get = "10010092;1" },
            new BuyCellCost { Cost = "3;480", Get = "10010098;10" },
            new BuyCellCost { Cost = "3;480", Get = "10000155;1" },
            new BuyCellCost { Cost = "3;480", Get = "10010052;1" },
            new BuyCellCost { Cost = "3;480", Get = "10010088;2" },
            new BuyCellCost { Cost = "3;480", Get = "10000123;1" },
            new BuyCellCost { Cost = "3;480", Get = "10010046;1" },
            new BuyCellCost { Cost = "3;480", Get = "10000143;5" },

            //仓库3
            new BuyCellCost { Cost = "3;600", Get = "10010083;10" },
            new BuyCellCost { Cost = "3;600", Get = "10000131;10" },
            new BuyCellCost { Cost = "3;600", Get = "10010083;10" },
            new BuyCellCost { Cost = "3;600", Get = "10010046;1" },
            new BuyCellCost { Cost = "3;600", Get = "10000143;5" },
            new BuyCellCost { Cost = "3;600", Get = "10010039;1" },
            new BuyCellCost { Cost = "3;600", Get = "10010088;2" },
            new BuyCellCost { Cost = "3;600", Get = "10010043;5" },
            new BuyCellCost { Cost = "3;600", Get = "10010099;1" },
            new BuyCellCost { Cost = "3;600", Get = "10010026;1" },

            //仓库4
            new BuyCellCost { Cost = "3;720", Get = "10010046;1" },
            new BuyCellCost { Cost = "3;720", Get = "10010083;10" },
            new BuyCellCost { Cost = "3;720", Get = "10010043;5" },
            new BuyCellCost { Cost = "3;720", Get = "10010083;10" },
            new BuyCellCost { Cost = "3;720", Get = "10010093;1" },
            new BuyCellCost { Cost = "3;720", Get = "10000104;1" },
            new BuyCellCost { Cost = "3;720", Get = "10010083;10" },
            new BuyCellCost { Cost = "3;720", Get = "10010039;1" },
            new BuyCellCost { Cost = "3;720", Get = "10000143;2" },
            new BuyCellCost { Cost = "3;720", Get = "10000105;1" },
        };

        /// <summary>
        /// 抽奖奖励，每个区每天随机一个掉落ID
        /// </summary>
        [StaticField]
        public static List<int> ChouKaDropId = new List<int> { 601901001 };

        /// <summary>
        /// 奔跑大赛随机怪
        /// </summary>
        [StaticField]
        public static List<int> RunRaceMonsterList =
                new List<int>()
                {
                    90000021,
                    90000022,
                    90000023,
                    90000024,
                    90000025,
                    90000026,
                    90000027
                };

        ///当饱食度达到一定值时,会为每位贡献者赠送一个礼包哦
        [StaticField]
        public static Dictionary<int, string> Feed1RewardList = new Dictionary<int, string>() { { 10, "10010045;1" }, { 2000, "10010045;1" }, };

        [StaticField]
        public static List<string> NotCombatSkill = new List<string>() { "Act_11", "Act_12", "Act_13" };

        /// <summary>
        /// 洗练次数奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> ItemXiLianNumReward = new Dictionary<int, string>()
        {
            { 30, "1;200000@10000158;1$1;0,0" },
            { 80, "1;300000@10000158;2$1;0,0" },
            { 150, "1;500000@10010053;1@10000151;1$1;0,0" },
            { 300, "1;1000000@10000151;1@11200000;1$1;0,0" },
        };

        /// <summary>
        /// 猎人切换状态CD
        /// </summary>
        [StaticField]
        public static long HunterSwichCD = TimeHelper.Second * 10;

        /// <summary>
        /// 小龟选手 npcconfig
        /// </summary>
        [StaticField]
        public static List<int> TurtleList = new List<int>() { 20099011, 20099012, 20099013 };

        /// <summary>
        /// 击败过的BossId,包含在这个列表的才记录
        /// BossId -> BossId(召唤)
        /// 要新增配置，复制Boss的配置后，将 !!! MonsterType改为1、AI改为2 !!! 、Exp改为0、IfBoss改为0、掉落ID改为0、SelectSize改为1、DropType改为0、、、
        /// 与上面的召唤物配置差不多
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> DefeatedBossIds = new Dictionary<int, int>()
        {
            { 70001004, 90000201 },
            { 70001011, 90000202 },
            { 70001104, 90000203 },
            { 70001206, 90000204 },
            { 70001209, 90000205 },
            { 70002003, 90000206 },
            { 70002007, 90000207 },
            { 70002012, 90000208 },
            { 70003003, 90000209 },
            { 70003006, 90000210 },
            { 70003012, 90000211 },
            { 70003016, 90000212 },
            { 70004003, 90000213 },
            { 70004006, 90000214 },
            { 70004010, 90000215 },
            { 70004013, 90000216 },
            { 70005003, 90000217 },
            { 70005004, 90000218 },
            { 70005012, 90000219 },
            { 70005013, 90000220 },
            { 70006011, 90000221 },
            { 70006012, 90000222 },
            { 70006013, 90000223 }
        };

        /// <summary>
        /// 200内部区 201版号区 202中心区 203机器人
        /// </summary>
        [StaticField]
        public static List<int> InnerZoneList = new List<int>(4) { 200, 201, 202, 203 };

        /// <summary>
        /// 竞技场buff
        /// </summary>
        [StaticField]
        public static List<int> SoloBuffIds = new List<int>() { 99004006 };

        [StaticField]
        public static string ChongJiSkill = "Skill_Other_ChongJi_1";

        [StaticField]
        public static string Skill_Halo_2 = "Skill_Halo_2";

        /// <summary>
        /// 三个对应等级套装属性
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> PetSuitProperty = new Dictionary<int, string>()
        {
            { 5, "205003,0.05;203003,0.2;203103,0.2" },
            { 8, "205003,0.1;203003,0.25;203103,0.25" },
            { 10, "205003,0.15;203003,0.3;203103,0.3" },
        };

        /// <summary>
        /// 宠物守护（0-3）
        /// </summary>
        [StaticField]
        public static List<KeyValuePair> PetShouHuAttri = new List<KeyValuePair>
        {
            new KeyValuePair() { Value = "青龙守护", Value2 = "200101" }, //暴击
            new KeyValuePair() { Value = "白虎守护", Value2 = "200401" }, //抗暴
            new KeyValuePair() { Value = "朱雀守护", Value2 = "200201" }, //命中
            new KeyValuePair() { Value = "玄武守护", Value2 = "200301" }, //闪避
            new KeyValuePair() { Value = "神兽守护", Value2 = "" },
        };

        [StaticField]
        public static string DefaultGem = "0_0_0_0";

        [StaticField]
        public static List<int> GemHoleId = new List<int>()
        {
            0,
            1,
            2,
            3,
            4
        };

        [StaticField]
        public static List<int> GemWeight = new List<int>()
        {
            50,
            25,
            15,
            10,
            0
        };

        [StaticField]
        public static Dictionary<int, int> ItemToUserDataType = new Dictionary<int, int>()
        {
            { 1, UserDataType.Gold },
            { 2, UserDataType.Exp },
            { 3, UserDataType.Diamond },
            { 4, UserDataType.Vitality },
            { 5, UserDataType.PiLao },
            { 6, UserDataType.RongYu },
            { 7, UserDataType.FangRong },
            { 8, UserDataType.MaoXianExp },
            { 9, UserDataType.DungeonTimes },
            { 10, UserDataType.Recharge },
            { 11, UserDataType.HuoYue },
            { 12, UserDataType.Sp },
            { 13, UserDataType.JiaYuanFund },
            { 14, UserDataType.JiaYuanExp },
            { 15, UserDataType.BaoShiDu },
            { 16, UserDataType.UnionContri },
            { 17, UserDataType.UnionExp },
            { 18, UserDataType.JueXingExp },
            { 31, UserDataType.SeasonExp },
            { 32, UserDataType.SeasonCoin },
            { 34, UserDataType.InvestMent },
            { 35, UserDataType.UnionGold },
        };

        [StaticField]
        //以下途径获取的道具为非绑定道具,其他途径为绑定道具
        public static Dictionary<int, string> ItemGetWayNameList = new Dictionary<int, string>
        {
            { ItemGetWay.System, "系统赠与" },
            { ItemGetWay.FubenGetReward, "副本结算奖励" },
            { ItemGetWay.ChouKa, "抽卡" },
            { ItemGetWay.Energy, "正能量" },
            { ItemGetWay.GM, "GM" },
            { ItemGetWay.ItemBox_6, "道具盒子" },
            { ItemGetWay.XiLianLevel, "洗练大师" },
            { ItemGetWay.LingDiReward, "领地" },
            { ItemGetWay.MysteryBuy, "神秘商店" },
            { ItemGetWay.PetFubenReward, "宠物副本奖励" },
            { ItemGetWay.PetHeXinHeCheng, "宠物之核合成" },
            { ItemGetWay.RandomTowerReward, "随机塔奖励" },
            { ItemGetWay.ShoujiReward, "收集奖励" },
            { ItemGetWay.StoreBuy, "商店购买" },
            { ItemGetWay.TaskCountry, "活跃任务" },
            { ItemGetWay.YueKaReward, "月卡奖励" },
            { ItemGetWay.ChengJiuRward, "成就奖励" },
            { ItemGetWay.RankReward, "排行榜奖励" },
            { ItemGetWay.FirstWin, "首胜" },
            { ItemGetWay.PickItem, "拾取" },
            { ItemGetWay.PaiMaiShop, "拍賣商店" },
            { ItemGetWay.PetEggDuiHuan, "宠物蛋兑换" },
            { ItemGetWay.TaskReward, "任务奖励" },
            { ItemGetWay.PetFenjie, "宠物分解" },
            { ItemGetWay.BattleWin, "战场胜利" },
            { ItemGetWay.ReceieMail, "邮件" },
            { ItemGetWay.Melting, "熔炼" },
            { ItemGetWay.TiaoZhan, "挑战之地" },
            { ItemGetWay.SkillMake, "生活制造" },
            { ItemGetWay.HuiShou, "回收系统" },
            { ItemGetWay.XiaJia, "拍卖行下架" },
            { ItemGetWay.DuiHuan, "兑换" },
            { ItemGetWay.HongBao, "红包系统" },
            { ItemGetWay.CostItem, "扣除道具" },
            { ItemGetWay.Share, "分享" },
            { ItemGetWay.PaiMaiBuy, "拍卖购买" },
            { ItemGetWay.XiuLian, "修炼" },
            { ItemGetWay.TreasureMap, "藏宝图获得" },
            { ItemGetWay.Sell, "出售获得" },
            { ItemGetWay.PaiMaiSell, "拍賣出售" },
            { ItemGetWay.BuChang, "补偿" },
            { ItemGetWay.JingLing, "精灵" },
            { ItemGetWay.JiaYuanGather, "家园种植" },
            { ItemGetWay.JiaYuanMale, "JiaYuanMale" },
            { ItemGetWay.JiaYuanSell, "家园出售" },
            { ItemGetWay.JiaYuanCost, "家园资金兑换" },
            { ItemGetWay.Popularize, "推广" },
            { ItemGetWay.Serial, "序列号奖励" },
            { ItemGetWay.JiaYuanCook, "家园厨房" },
            { ItemGetWay.Donation, "捐献" },
            { ItemGetWay.UnionXiuLian, "家族修炼" },
            { ItemGetWay.UnionBoss, "家族BOSS" },
            { ItemGetWay.UnionRace, "家族争霸" },
            { ItemGetWay.Auction, "竞拍" },
            { ItemGetWay.PetChouKa, "宠物抽卡" },
            { ItemGetWay.ItemBox_8, "道具盒子" },
            { ItemGetWay.ItemBox_9, "道具盒子" },
            { ItemGetWay.ItemBox_104, "道具盒子" },
            { ItemGetWay.ItemBox_106, "道具盒子" },
            { ItemGetWay.PetTianTiReward, "宠物天梯" },
            { ItemGetWay.JiaYuanExchange, "家园兑换" },
            { ItemGetWay.GemHuiShou, "宝石回收" },
            { ItemGetWay.ArenaWin, "角斗场胜利" },
            { ItemGetWay.MiJingBoss, "密境BOSS" },
            { ItemGetWay.AuctionJoin, "竞拍保证金" },
            { ItemGetWay.UnionUpLv, "家族升级" },
            { ItemGetWay.GemHeCheng, "宝石合成" },
            { ItemGetWay.SoloReward, "竞技场奖励" },
            { ItemGetWay.Activity_MaoXianJia, "冒险家" },
            { ItemGetWay.Activity_ZhanQu, "战区活动" },
            { ItemGetWay.Recharge, "充值" },
            { ItemGetWay.TowerOfSealCost, "封印之塔消耗钻石" },
            { ItemGetWay.JueXing, "觉醒" },
            { ItemGetWay.Activity_DayTeHui, "每日特惠" },
            { ItemGetWay.UnionMysteryBuy, "家族神秘商店" },
            { ItemGetWay.HappyMove, "喜从天降" },
            { ItemGetWay.Turtle, "小龟大赛" },
            { ItemGetWay.ShowLie, "狩猎" },
            { ItemGetWay.RunRace, "奔跑大赛" },
            { ItemGetWay.Demon, "恶魔活动" },
            { ItemGetWay.PetMine, "宠物矿场" },
            { ItemGetWay.Season, "赛季奖励" },
            { ItemGetWay.Welfare, "福利奖励" },
            { ItemGetWay.LeavlReward, "等级奖励" },
            { ItemGetWay.KillMonsterReward, "击败怪物奖励" },
            { ItemGetWay.StallBuy, "摆摊购买" },
            { ItemGetWay.ActivityChouKa, "抽卡" },
            { ItemGetWay.ActivityConsume, "消耗钻石" },
            { ItemGetWay.ActivityHongBao, "充值红包" },
            { ItemGetWay.PetExplore, "宠物探索" },
            { ItemGetWay.Activity, "活动" },
        };

        // 游戏公告
        [StaticField]
        public static List<WorldSayConfig> WorldSayList = new()
        {
            new WorldSayConfig() { Time = 1230, OpenDay = new List<int> { -1 }, Conent = "巨龙神已经准时出现在宝藏之地,想要挑战我的就带上你们的武器过来挑战我吧!" },
            new WorldSayConfig() { Time = 1930, OpenDay = new List<int> { -1 }, Conent = "一波红包雨已经来临,赶紧来看看自己是否是那个幸运玩家!" },
            new WorldSayConfig() { Time = 1940, OpenDay = new List<int> { -1 }, Conent = "角斗场已经开启,想要参加的勇士要抓紧时间哦!" },
            new WorldSayConfig() { Time = 2000, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "世界领主已经出现在密境中,赶紧过来看看吧!" },
            new WorldSayConfig() { Time = 2015, OpenDay = new List<int> { -1 }, Conent = "拍卖特惠已经开启,有需要的玩家可以购买哦!" },
            new WorldSayConfig() { Time = 2030, OpenDay = new List<int> { -1 }, Conent = "战场活动已经开启,可以通过右上角的战场按钮快速加入哦!" },
            new WorldSayConfig() { Time = 2100, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "一大波宝箱出现在宝藏之地,想要去的玩家赶紧前往哦!" },
            new WorldSayConfig() { Time = 2110, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "一大波宝箱出现在宝藏之地,想要去的玩家赶紧前往哦!" },
            new WorldSayConfig() { Time = 2120, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "一大波宝箱出现在宝藏之地,想要去的玩家赶紧前往哦!" },
            new WorldSayConfig() { Time = 2100, OpenDay = new List<int> { 2, 4, 6 }, Conent = "变身大赛活动即将开启,想要参加的小伙伴记得要准时参加噢,5分钟后开启正式比赛!" },
            //年兽
            new WorldSayConfig() { Time = 2114, OpenDay = new List<int> { -1 }, Conent = "新年活动:新年的年兽-夕还有1分钟即将来到宝藏之地,主城的勇士们,带上你们的装备快去迎接挑战吧！" },
            new WorldSayConfig()
            {
                Time = 2115, OpenDay = new List<int> { -1 }, Conent = "新年的年兽-夕：我已经等了整整一年,弱者不配与我进行战斗,想要挑战我的就带上你们的装备过来吧,我已经到来到宝藏之地的中心！"
            },
            new WorldSayConfig() { Time = 2000, OpenDay = new List<int> { -1 }, Conent = "新年活动:捣乱的年兽出现在宝藏之地,想要去的玩家带上鞭炮赶紧前往哦!" },
            new WorldSayConfig() { Time = 2100, OpenDay = new List<int> { -1 }, Conent = "新年活动:捣乱的年兽出现在宝藏之地,想要去的玩家带上鞭炮赶紧前往哦!" },
            new WorldSayConfig() { Time = 2200, OpenDay = new List<int> { -1 }, Conent = "新年活动:捣乱的年兽出现在宝藏之地,想要去的玩家带上鞭炮赶紧前往哦!" },
            new WorldSayConfig() { Time = 2200, OpenDay = new List<int> { 2, 4, 6 }, Conent = "家族入侵:家族出现了入侵怪兽,想要奖励的小勇士请带上你们的武器速速前往!" },
            new WorldSayConfig() { Time = 2200, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "竞技场活动已经开启,想要证明自己能力的小伙伴记得前往噢!" },
        };

        /// <summary>
        /// 赛季开始时间
        /// </summary>
        [StaticField]
        public static long SeasonOpenTime = 1701360000000;

        //赛季结束时间
        [StaticField]
        public static long SeasonCloseTime = 1711814400000;

        /// <summary>
        /// 赛季BOSS
        /// </summary>
        [StaticField]
        public static int SeasonBossId = 90000051;

        [StaticField]
        public static Dictionary<int, int> MonsterToFuben = new Dictionary<int, int>();

        //成就炼金使用这些药剂增加点数
        [StaticField]
        public static List<int> ChengJiuLianJin =
                new List<int>
                {
                    13001002,
                    13001003,
                    13001004,
                    13001005,
                    13001006,
                    13001101,
                    13001102,
                    13001103,
                    13001104,
                    13001105,
                    13002002,
                    13002003,
                    13002004,
                    13002005,
                    13002006,
                    13002101,
                    13002102,
                    13002103,
                    13002104,
                    13002105,
                    13003003,
                    13003003,
                    13003004,
                    13003005,
                    13003006,
                    13003101,
                    13003102,
                    13003103,
                    13003104,
                    13003105,
                    13004004,
                    13004004,
                    13004004,
                    13004005,
                    13004006,
                    13004101,
                    13004102,
                    13004103,
                    13004104,
                    13004105,
                    13005005,
                    13005005,
                    13005005,
                    13005005,
                    13005006,
                    13005101,
                    13005102,
                    13005103,
                    13005104,
                    13005105,
                    13006002,
                    13009001,
                    13009002
                };

        //生命之盾
        [StaticField]
        public static Dictionary<int, int> ItemAddShieldExp =
                new Dictionary<int, int>()
                {
                    { 10020001, 1 },
                    { 10021001, 1 },
                    { 10021002, 1 },
                    { 10021003, 1 },
                    { 10021004, 1 },
                    { 10021005, 1 },
                    { 10021006, 1 },
                    { 10021007, 1 },
                    { 10021008, 200 },
                    { 10021009, 300 },
                    { 10021010, 1 },
                    { 10022001, 1 },
                    { 10022002, 1 },
                    { 10022003, 1 },
                    { 10022004, 1 },
                    { 10022005, 1 },
                    { 10022006, 1 },
                    { 10022007, 1 },
                    { 10022008, 200 },
                    { 10022009, 300 },
                    { 10022010, 1 },
                    { 10023001, 1 },
                    { 10023002, 1 },
                    { 10023003, 1 },
                    { 10023004, 1 },
                    { 10023005, 1 },
                    { 10023006, 1 },
                    { 10023007, 1 },
                    { 10023008, 200 },
                    { 10023009, 300 },
                    { 10023010, 1 },
                    { 10024001, 1 },
                    { 10024002, 1 },
                    { 10024003, 1 },
                    { 10024004, 1 },
                    { 10024005, 1 },
                    { 10024006, 1 },
                    { 10024007, 1 },
                    { 10024008, 200 },
                    { 10024009, 300 },
                    { 10024010, 1 },
                    { 10025001, 1 },
                    { 10025002, 1 },
                    { 10025003, 1 },
                    { 10025004, 1 },
                    { 10025005, 1 },
                    { 10025006, 1 },
                    { 10025007, 1 },
                    { 10025008, 200 },
                    { 10025009, 300 },
                    { 10025010, 1 },
                    { 10010085, 3 },
                    { 10010083, 10 },
                };

        [StaticField]
        public static List<int> TaskCompleteDirectly = new List<int>()
        {
            31001001,
            31001002,
            31001003,
            31001004,
            31001005,
            31001006,
            31001007,
            31001008
        };

        /// <summary>
        /// 周任务奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> WeekTaskDrop = new()
        {
            { 10, 61500001 } //完成每20环对应奖励
        };

        //1.锻造类型
        //2.裁缝类型
        //3.炼金类型
        //4.宝石类型
        //5.神器类型
        //6.附魔类型
        //8.家园类型
        [StaticField]
        public static Dictionary<int, string> MakeTypeName = new Dictionary<int, string>()
        {
            { 0, "无" }, { 1, "锻造" }, { 2, "裁缝" }, { 3, "炼金" },
        };

        /// <summary>
        /// 家园开启宠物仓库的消耗
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> PetOpenCangKu =
                new Dictionary<int, string>()
                {
                    //第一个格子默认开启
                    { 1, "13;200000" }, //第二个格子
                    { 2, "13;500000" }, //第三个格子
                    { 3, "13;1000000" }, //第四个格子
                    { 4, "13;2000000" }, //第五个格子
                    { 5, "13;4000000" }, //第六个格子
                };

        /// <summary>
        /// 宠物探宝奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> PetExploreReward =
                new Dictionary<int, string>()
                {
                    { 50, "10010086;1$3;100,1000" }, //钻石特殊处理, 也可以定位其他格式
                    { 100, "10010096;1$3;200,1000" }, //钻石特殊处理
                    { 150, "10010094;1$3;300,1500" },
                    { 200, "10010094;1$3;400,2000" },
                    { 300, "10000136;1$3;500,2500" },
                };

        [StaticField]
        public static List<float3> Formation_1 =
                new List<float3>()
                {
                    //前排
                    new float3(22.36f, 0f, -17.13f),
                    new float3(25.63f, 0f, -17.13f),
                    new float3(29.53f, 0f, -17.13f),
                    //中排
                    new float3(22.36f, 0f, -12.95f),
                    new float3(25.63f, 0f, -12.95f),
                    new float3(29.53f, 0f, -12.95f),
                    //后排
                    new float3(22.36f, 0f, -6.79f),
                    new float3(25.63f, 0f, -6.79f),
                    new float3(29.53f, 0f, -6.79f),
                };

        //对方位置
        [StaticField]
        public static List<float3> Formation_2 =
                new List<float3>()
                {
                    //前排
                    new float3(22.36f - 10f, 0f, -17.13f),
                    new float3(25.63f - 10f, 0f, -17.13f),
                    new float3(29.53f - 10f, 0f, -17.13f),
                    //中排 
                    new float3(22.36f - 10f, 0f, -12.95f),
                    new float3(25.63f - 10f, 0f, -12.95f),
                    new float3(29.53f - 10f, 0f, -12.95f),
                    //后排 
                    new float3(22.36f - 10f, 0f, -6.79f),
                    new float3(25.63f - 10f, 0f, -6.79f),
                    new float3(29.53f - 10f, 0f, -6.79f),
                };

        /// <summary>
        /// 每个格子对应的搜索顺序
        /// </summary>
        [StaticField]
        public static List<int>[] PetPositionAttack =
                new List<int>[]
                {
                    new List<int>()
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7,
                        8
                    },
                    new List<int>()
                    {
                        1,
                        0,
                        2,
                        4,
                        3,
                        5,
                        7,
                        6,
                        8
                    },
                    new List<int>()
                    {
                        2,
                        1,
                        0,
                        5,
                        4,
                        3,
                        8,
                        7,
                        6
                    },
                    new List<int>()
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7,
                        8
                    },
                    new List<int>()
                    {
                        1,
                        0,
                        2,
                        4,
                        3,
                        5,
                        7,
                        6,
                        8
                    },
                    new List<int>()
                    {
                        2,
                        1,
                        0,
                        5,
                        4,
                        3,
                        8,
                        7,
                        6
                    },
                    new List<int>()
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7,
                        8
                    },
                    new List<int>()
                    {
                        1,
                        0,
                        2,
                        4,
                        3,
                        5,
                        7,
                        6,
                        8
                    },
                    new List<int>()
                    {
                        2,
                        1,
                        0,
                        5,
                        4,
                        3,
                        8,
                        7,
                        6
                    }
                };

        //摄像机位置
        [StaticField]
        public static float3 FuBenCameraPosition =
                new float3(14, 22f, 0f);

        [StaticField]
        public static float3 FuBenCameraRotation =
                new float3(60f, -90f, 0);

        //拖动位置
        public const float FuBenCameraPositionMin_X = -50f;
        public const float FuBenCameraPositionMax_X = 50f;
        public const float FuBenCameraPositionMin_Z = -50f;
        public const float FuBenCameraPositionMax_Z = 50f;

        /// <summary>
        /// 等级奖励,大于或等于可以领取奖励.  一个道具直接领取，多个道具弹出选择界面
        /// 三个职业 以&切分
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> LeavlRewardItem =
                new Dictionary<int, string>()
                {
                    //14060006
                    { 5, "14060006;1" }, //升级到6级装备
                    { 8, "14100021;1@14100022;1&14100121;1@14100122;1&14100221;1" }, //本职业特色武器
                    { 10, "10031002;1" }, //小松鼠
                    { 12, "10010033;1" }, //金钥匙
                    { 14, "10000106;1" }, //国王的宝石箱子
                    { 16, "10000120;1" }, //国王的装备盒子
                    { 18, "10000122;1" }, //二章装备盒子
                    { 20, "10010092;1" }, //稀少的宠物蛋
                    { 22, "10000156;1" }, //背包扩展袋子
                    { 24, "10000158;1" }, //封印之塔挑战凭证
                    { 26, "10000140;1" }, //忘灵丹
                    { 28, "10010088;5" } //体力补充
                };

        /// <summary>  
        /// 击杀怪物奖励。     NumericType.KillMonsterNumber击杀怪物数量  NumericType.KillMonsterReward击杀怪物领取奖励记录
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> KillMonsterReward =
                new Dictionary<int, string>
                {
                    { 50, "10041101;1" }, //优秀的赤精石
                    { 100, "14070003;1" }, //森之戒指
                    { 200, "10010091;1" }, //幼小的宠物蛋
                    { 300, "10000121;1" }, //一章装备盒子
                    { 500, "14080002;1" }, //精灵守护
                    { 750, "11200001;1" }, //锻造鉴定符
                    { 1000, "10010046;1" }, //领主刷新券

                    //{ 300, "14100021;1@14100022;1&14100121;1@14100122;1&14100221;1" }
                };

        /// <summary>
        /// 宠物核心探宝奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> PetHeXinExploreReward =
                new Dictionary<int, string>()
                {
                    { 50, "10020001;1$1;100,1000" }, //钻石特殊处理, 也可以定位其他格式
                    { 100, "10020001;1$1;200,1000" }, //钻石特殊处理
                    { 150, "10020001;1$1;300,1500" },
                    { 200, "10020001;1$1;400,2000" },
                    { 300, "10020001;1$1;500,2500" },
                };

        /// <summary>
        /// 宠物抽奖掉落展示
        /// </summary>
        [StaticField]
        public static string PetChouKaRewardItemShow =
                "10000136;1@10010078;1@10010079;1@10010093;1@10010086;1@10010096;1@10031015;1@10031016;1@10031017;1@10031014;1@10031013;1@10031012;1@10031011;1@10031010;1@10031009;1@10060105;1@10060205;1@10060305;1@10060405;1@10060505;1@10060605;1@10060705;1";

        /// <summary>
        /// 宠物之核抽奖掉落展示
        /// </summary>
        [StaticField]
        public static string PetHeXinChouKaRewardItemShow = "10060205;1@10060305;1@10060405;1@10060505;1@10060605;1@10060705;1";

        [StaticField]
        public static List<int> BaoShiBuff = new List<int>() { 99001042, 99001031, 99001032, 99001011 };

        [StaticField]
        public static List<int> DonationBuff =
                new List<int>()
                {
                    99003011,
                    99003012,
                    99003013,
                    99003021,
                    99003022,
                    99003023,
                    99003031,
                    99003032,
                    99003033,
                    99003041,
                    99003042,
                    99003043,
                    99003051,
                    99003052,
                    99003053,
                    99003061,
                    99003062,
                    99003063,
                    99003064
                };

        [StaticField]
        public static List<string> RankChengHao =
                new List<string>() { "天下第一勇士", "天下第二勇士", "天下第三勇士" };

        [StaticField]
        public static List<string> OccRankChengHao =
                new List<string>()
                {
                    "全区第一战士",
                    "全区第二战士",
                    "全区第三战士",
                    "全区第一法师",
                    "全区第二法师",
                    "全区第三法师",
                    "全区第一猎人",
                    "全区第二猎人",
                    "全区第三猎人"
                };

        /// <summary>
        /// 职业排行榜第一名buff 
        /// </summary>
        [StaticField]
        public static List<int> CombatRankBuff = new List<int>()
        {
            99007001,
            99007002,
            99007003,
            99007001,
            99007002,
            99007003,
            99007001,
            99007002,
            99007003
        };

        /// <summary>
        /// 第一个权重大优先显示全区称号
        /// </summary>
        [StaticField]
        public static List<int> ChengHaoWeight = new List<int>() { 100, 0 };

        /// <summary>
        /// 家园大师 
        /// </summary>
        [StaticField]
        public static List<KeyValuePair> JiaYuanDaShiPro =
                new List<KeyValuePair>()
                {
                    new KeyValuePair() { KeyId = 1, Value = "美味大师1级", Value2 = "50@100203,1000" },
                    new KeyValuePair() { KeyId = 2, Value = "美味大师2级", Value2 = "100@100203,1500" },
                    new KeyValuePair() { KeyId = 3, Value = "美味大师3级", Value2 = "250@100203,2000" },
                    new KeyValuePair() { KeyId = 4, Value = "美味大师4级", Value2 = "500@100203,2500" },
                    new KeyValuePair() { KeyId = 5, Value = "美味大师5级", Value2 = "1000@100203,3000" },
                    new KeyValuePair() { KeyId = 6, Value = "美味大师6级", Value2 = "2000@100203,4000" },
                };

        /// <summary>
        /// 跑环任务奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> RingTaskDrop = new()
        {
            { 20, 61500001 }, //完成每20环对应奖励
            { 40, 61500001 },
            { 60, 61500001 },
            { 80, 61500001 },
            { 100, 61500011 },
        };

        [StaticField]
        public static List<float3> JiaYuanPetPosition = new List<float3>()
        {
            new float3(13.42f, 0f, -42.45f),
            new float3(12.26f, 0f, -29.74f),
            new float3(-9.1f, 0f, -16.16f),
            new float3(-9.3f, 0f, 19.97f),
            new float3(29.93f, 0f, 12.59f),
            new float3(27.27f, 0f, -27.595f),
        };

        //收购列表
        [StaticField]
        public static List<JiaYuanPurchase> JiaYuanPurchaseList =
                new List<JiaYuanPurchase>
                {
                    new JiaYuanPurchase { ItemID = 10036001, ItemNum = 1, BuyMinZiJin = 1500, BuyMaxZiJin = 3000 }, //炒鸡蛋
                    new JiaYuanPurchase { ItemID = 10036002, ItemNum = 1, BuyMinZiJin = 2646, BuyMaxZiJin = 5292 }, //咸鸭蛋
                    new JiaYuanPurchase { ItemID = 10036003, ItemNum = 1, BuyMinZiJin = 3345, BuyMaxZiJin = 6690 }, //胡萝卜汁
                    new JiaYuanPurchase { ItemID = 10036004, ItemNum = 1, BuyMinZiJin = 3105, BuyMaxZiJin = 6210 }, //腌蛋
                    new JiaYuanPurchase { ItemID = 10036005, ItemNum = 1, BuyMinZiJin = 3912, BuyMaxZiJin = 7824 }, //红萝卜汁
                    new JiaYuanPurchase { ItemID = 10036006, ItemNum = 1, BuyMinZiJin = 3330, BuyMaxZiJin = 6660 }, //鸡汤
                    new JiaYuanPurchase { ItemID = 10036007, ItemNum = 1, BuyMinZiJin = 7452, BuyMaxZiJin = 14904 }, //兔绒披风
                    new JiaYuanPurchase { ItemID = 10036008, ItemNum = 1, BuyMinZiJin = 11448, BuyMaxZiJin = 22896 }, //绒毛面具
                    new JiaYuanPurchase { ItemID = 10036009, ItemNum = 1, BuyMinZiJin = 7299, BuyMaxZiJin = 14598 }, //红薯团
                    new JiaYuanPurchase { ItemID = 10036010, ItemNum = 1, BuyMinZiJin = 7658, BuyMaxZiJin = 15315 }, //鸡蛋汉堡
                    new JiaYuanPurchase { ItemID = 10036011, ItemNum = 1, BuyMinZiJin = 7805, BuyMaxZiJin = 15609 }, //烤肉
                    new JiaYuanPurchase { ItemID = 10036012, ItemNum = 1, BuyMinZiJin = 14396, BuyMaxZiJin = 28791 }, //猪肉串
                    new JiaYuanPurchase { ItemID = 10036013, ItemNum = 1, BuyMinZiJin = 19662, BuyMaxZiJin = 39324 }, //牛皮护腕
                    new JiaYuanPurchase { ItemID = 10036014, ItemNum = 1, BuyMinZiJin = 10236, BuyMaxZiJin = 20472 }, //清蒸土豆
                    new JiaYuanPurchase { ItemID = 10036015, ItemNum = 1, BuyMinZiJin = 12014, BuyMaxZiJin = 24027 }, //水果汁
                    new JiaYuanPurchase { ItemID = 10036016, ItemNum = 1, BuyMinZiJin = 15392, BuyMaxZiJin = 30783 }, //南瓜羹
                    new JiaYuanPurchase { ItemID = 10036017, ItemNum = 1, BuyMinZiJin = 23364, BuyMaxZiJin = 46728 }, //绒毛围裙
                    new JiaYuanPurchase { ItemID = 10036018, ItemNum = 1, BuyMinZiJin = 22941, BuyMaxZiJin = 45882 }, //黄瓜汁
                    new JiaYuanPurchase { ItemID = 10036019, ItemNum = 1, BuyMinZiJin = 24843, BuyMaxZiJin = 49686 }, //牛奶点心
                    new JiaYuanPurchase { ItemID = 10036020, ItemNum = 1, BuyMinZiJin = 19740, BuyMaxZiJin = 39480 }, //西红柿炒蛋
                    new JiaYuanPurchase { ItemID = 10036021, ItemNum = 1, BuyMinZiJin = 22550, BuyMaxZiJin = 45099 }, //美味拼盘
                    new JiaYuanPurchase { ItemID = 10036022, ItemNum = 1, BuyMinZiJin = 38349, BuyMaxZiJin = 76698 }, //美味蛋糕
                    new JiaYuanPurchase { ItemID = 10036023, ItemNum = 1, BuyMinZiJin = 32340, BuyMaxZiJin = 64680 }, //美味奶汁
                    new JiaYuanPurchase { ItemID = 10036024, ItemNum = 1, BuyMinZiJin = 40698, BuyMaxZiJin = 81396 }, //玉米骨汤
                    new JiaYuanPurchase { ItemID = 10036025, ItemNum = 1, BuyMinZiJin = 25772, BuyMaxZiJin = 51543 }, //风味肉汁
                    new JiaYuanPurchase { ItemID = 10036026, ItemNum = 1, BuyMinZiJin = 51462, BuyMaxZiJin = 102924 }, //风味炒饭
                    new JiaYuanPurchase { ItemID = 10036027, ItemNum = 1, BuyMinZiJin = 37527, BuyMaxZiJin = 75054 }, //风味奶酪
                    new JiaYuanPurchase { ItemID = 10036028, ItemNum = 1, BuyMinZiJin = 18240, BuyMaxZiJin = 36480 }, //西红柿组合
                    new JiaYuanPurchase { ItemID = 10036029, ItemNum = 1, BuyMinZiJin = 22995, BuyMaxZiJin = 45990 }, //风味南瓜粥
                    new JiaYuanPurchase { ItemID = 10036030, ItemNum = 1, BuyMinZiJin = 27378, BuyMaxZiJin = 54756 }, //回味汤圆
                    new JiaYuanPurchase { ItemID = 10036031, ItemNum = 1, BuyMinZiJin = 5178, BuyMaxZiJin = 10356 }, //烤鸡肉
                    new JiaYuanPurchase { ItemID = 10036032, ItemNum = 1, BuyMinZiJin = 11882, BuyMaxZiJin = 23763 }, //红烧烤肉
                    new JiaYuanPurchase { ItemID = 10036033, ItemNum = 1, BuyMinZiJin = 31329, BuyMaxZiJin = 62658 }, //加厚皮裙
                    new JiaYuanPurchase { ItemID = 10036034, ItemNum = 1, BuyMinZiJin = 26460, BuyMaxZiJin = 52920 }, //香味奶汁
                    new JiaYuanPurchase { ItemID = 10036035, ItemNum = 1, BuyMinZiJin = 16521, BuyMaxZiJin = 33042 }, //绿色果汁
                };

        //关卡boss显示列表
        [StaticField]
        public static List<int> BossShowTimeList =
                new List<int>
                {
                    70001004,
                    70001011,
                    70001104,
                    70001206,
                    70001209,
                    70002003,
                    70002007,
                    70002012,
                    70003003,
                    70003006,
                    70003012,
                    70003016,
                    70004003,
                    70004006,
                    70004010,
                    70004013,
                    70005003,
                    70005004,
                    70005012,
                    70005013,
                    70006011,
                    70006012
                };

        /// <summary>
        /// 家园随机怪
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> JiaYuanMonster =
                new Dictionary<int, int>()
                {
                    { 83000101, 50 }, //石块  资金
                    { 83000102, 30 }, //树叶  给材料
                    { 83000103, 5 }, //宝箱
                    { 83000104, 15 } //带锁的宝箱
                };

        [StaticField]
        public static float3 PastureInitPos = new float3(-15f, 0f, -20f);

        [StaticField]
        public static string UI_pro_4_2 = "UI_pro_4_2";

        [StaticField]
        public static string UI_pro_3_2 = "UI_pro_3_2";

        [StaticField]
        public static string UI_pro_3_4 = "UI_pro_3_4";

        [StaticField]
        public static List<float3> PlanPositionList = new List<float3>()
        {
            new float3(4f - 0.5f, 0f, -31.24f - 0.5f),
            new float3(4f - 0.5f, 0f, -33.32f - 0.5f),
            new float3(4f - 0.5f, 0f, -35.39f - 0.5f),
            new float3(4f - 0.5f, 0f, -37.58f - 0.5f),
            new float3(1.25f - 0.5f, 0f, -31.24f - 0.5f),
            new float3(1.25f - 0.5f, 0f, -33.32f - 0.5f),
            new float3(1.25f - 0.5f, 0f, -35.39f - 0.5f),
            new float3(1.25f - 0.5f, 0f, -37.58f - 0.5f),
            new float3(-2f, 0f, -31.24f - 0.5f),
            new float3(-2f, 0f, -33.32f - 0.5f),
            new float3(-2f, 0f, -35.39f - 0.5f),
            new float3(-2f, 0f, -37.58f - 0.5f),
            new float3(-4.75f, 0f, -31.24f - 0.5f),
            new float3(-4.75f, 0f, -33.32f - 0.5f),
            new float3(-4.75f, 0f, -35.39f - 0.5f),
            new float3(-4.75f, 0f, -37.58f - 0.5f),
            new float3(-7.5f, 0f, -31.24f - 0.5f),
            new float3(-7.5f, 0f, -33.32f - 0.5f),
            new float3(-7.5f, 0f, -35.39f - 0.5f),
            new float3(-7.5f, 0f, -37.58f - 0.5f),
        };

        [StaticField]
        public static Dictionary<int, string> UnionPosition = new Dictionary<int, string>
        {
            { 0, "族员" }, { 1, "族长" }, { 2, "副族长" }, { 3, "长老" },
        };

        /// <summary>
        /// 0 无日志 1 info  2debug  3 waring 4 error
        /// </summary>
        [StaticField]
        public static int LogLevel = 0;

        [StaticField]
        public static List<string> KillInfoList = new List<string>();

        [StaticField]
        public static string NoticeLastContent = string.Empty;

        [StaticField]
        public static long NoticeLastGetTime = 0;

        [StaticField]
        public static List<string> LoginInfoList = new List<string>();

        [StaticField]
        public static List<string> ZuobiInfoList = new List<string>();

        /// <summary>
        /// 一键出售材料
        /// </summary>
        [StaticField]
        public static List<int> OneSellMaterialList = new()
        {
            10021001,
            10021002,
            10021003,
            10021004,
            10021005,
            10021006,
            10021007,
            10021010,
            10022001,
            10022002,
            10022003,
            10022004,
            10022005,
            10022006,
            10022007,
            10022010,
            10023001,
            10023002,
            10023003,
            10023004,
            10023005,
            10023006,
            10023007,
            10023010,
            10024001,
            10024002,
            10024003,
            10024004,
            10024005,
            10024006,
            10024007,
            10024010,
            10025001,
            10025002,
            10025003,
            10025004,
            10025005,
            10025006,
            10025007,
            10025010
        };

        [StaticField]
        public static List<ServerItem> ServerItems = new List<ServerItem>();
    }
}