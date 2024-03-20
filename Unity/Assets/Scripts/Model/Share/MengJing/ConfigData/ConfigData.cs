using System.Collections.Generic;

namespace ET
{
    public static class ConfigData
    {
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
    }
}