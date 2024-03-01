using System.Collections.Generic;

namespace ET
{
    public static class ConfigData
    {
        
        
        
        [StaticField]
        public static string DefaultGem = "0_0_0_0";
        
        [StaticField]
        public static List<int> GemHoleId = new List<int>() { 0, 1, 2, 3, 4 };
        
        [StaticField]
        public static List<int> GemWeight = new List<int>() { 50, 25, 15, 10, 0 };

        
        [StaticField]
        public static Dictionary<int, int> ItemToUserDataType = new Dictionary<int, int>()
        {
            {  1, UserDataType.Gold },
            {  2, UserDataType.Exp },
            {  3, UserDataType.Diamond },
            {  4, UserDataType.Vitality },
            {  5, UserDataType.PiLao },
            {  6, UserDataType.RongYu },
            { 7,  UserDataType.FangRong},
            { 8,  UserDataType.MaoXianExp},
            { 9,  UserDataType.DungeonTimes},
            { 10, UserDataType.Recharge},
            { 11, UserDataType.HuoYue},
            { 12, UserDataType.Sp},
            { 13, UserDataType.JiaYuanFund},
            { 14, UserDataType.JiaYuanExp},
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

    }
    
}