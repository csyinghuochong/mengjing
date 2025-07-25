using System.Collections.Generic;

namespace ET
{

    public static class ConfigHelper
    {
        
        /// <summary>
        /// 开服天数金币限制
        /// </summary>
        /// <param name="openDay"></param>
        /// <returns></returns>
        public static long GetPaiMaiTodayGold(int openDay)
        {
            //新区1天 1000万 2天2000万…… 5天5000万
            if (openDay <= 1)
            {
                return 10000000;
            }
            if (openDay <= 2)
            {
                return 15000000;
            }
            if (openDay <= 3)
            {
                return 20000000;
            }
            if (openDay <= 4)
            {
                return 25000000;
            }
            return 30000000;
        }
        
        public static List<RewardItem> GetHeQuReward(int lv)
        {
            List<RewardItem> rewards = new List<RewardItem>();
            if (lv < 50)
            {
                return rewards;
            }
            else
            {
                rewards.Add(new RewardItem() {  ItemID = 10000143, ItemNum = 30 });
                rewards.Add(new RewardItem() {  ItemID = 10010093, ItemNum = 1 });
                rewards.Add(new RewardItem() {  ItemID = 10010041, ItemNum = 50 });
                rewards.Add(new RewardItem() {  ItemID = 10010046, ItemNum = 1 });
                return rewards;
            }
        }

       
        public static int GetDiamondNumber(int key)
        {
            if (!ConfigData.RechargeGive.ContainsKey(key))
            {
                return 0;
            }
            int number = ConfigData.RechargeGive[key];
            return key * 100 + number;
        }


        ///// <summary>
        ///// 对比用
        ///// </summary>
        //public const string NoticeVersion = "1.0.0";        
        ////公告内容
        //public const string NoticeText =
        //    "版本更新内容\r\n1.更新公会系统，可以创建公会邀请其他玩家加入。\r\n2.开启游戏第六章第一个地图，60级可进入。\r\n3.新增宠物守护系统，根据宠物评分可以增加暴击等相关属性。\r\n4.增加家园访问，其他玩家可以互相访问家园。\r\n5.家园小地图显示石块和树叶方便玩家快速查询。\r\n6.赏金任务需要的怪物数量缩减。\r\n7.创建角色增加随机姓名。\r\n8.修复牧师技能不加攻击的问题。\r\n9.增加天气系统。\r\n10.增加野外碰到精灵和宠物的几率。";
        
     
        public static List<BossDevelopment> GetBossDevelopmentByChapter(int chapterid)
        {
            if (chapterid == 6)
            {
                return ConfigData.BossDevelopmentList_6;
            }
            else
            {
                return ConfigData.BossDevelopmentList_5;
            }
        }

        public static BossDevelopment GetBossDevelopmentByKill(int chapterid, int killNumber)
        {
            List<BossDevelopment> BossDevelopmentList = GetBossDevelopmentByChapter(chapterid);

            for (int i = BossDevelopmentList.Count - 1; i >=0; i--)
            {
                if (killNumber >= BossDevelopmentList[i].KillNumber)
                { 
                    return BossDevelopmentList[i];  
                }
            }
            return BossDevelopmentList[0];
        }

        public static BossDevelopment GetBossDevelopmentById(int chapterid, int level)
        {
            List<BossDevelopment> BossDevelopmentList = GetBossDevelopmentByChapter(chapterid);

            for (int i = BossDevelopmentList.Count - 1; i >= 0; i--)
            {
                if (level == BossDevelopmentList[i].Level)
                {
                    return BossDevelopmentList[i];
                }
            }
            return null;
        }

     
        public static string GetPetSuitProperty(List<int> pethexinLv)
        {
            int lv5number = 0;
            int lv8number = 0;
            int lv10number = 0;
            for (int i = 0; i < pethexinLv.Count; i++)
            {
                if (pethexinLv[i] >= 5)
                {
                    lv5number++;
                }
                if (pethexinLv[i] >= 8)
                {
                    lv8number++;
                }
                if (pethexinLv[i] >= 10)
                {
                    lv10number++;
                }
            }

            if (lv10number >= 3)
            {
                return ConfigData.PetSuitProperty[10];
            }
            if (lv8number >= 3)
            {
                return ConfigData.PetSuitProperty[8];
            }
            if (lv5number >= 3)
            {
                return ConfigData.PetSuitProperty[5];
            }
            return null;
        }

        public static int GetRankBuff(int rankId, int occRankId, int occ)
        {
            if (occRankId >= 1 && occRankId <= 3)
            {
                return ConfigData.CombatRankBuff[(occ - 1) * 3 + occRankId - 1];
            }
            return 0;
        }

        public static string GetRankChengHao(int rankId, int occRankId, int occ)
        {
            //int weight_0 = ChengHaoWeight[0];
            //int weight_1 = ChengHaoWeight[1];
            //if (weight_0 >= weight_1 &&  rankId >= 1 && rankId <= 3)
            //{
            //    return RankChengHao[rankId - 1];
            //}
            //if (weight_0 < weight_1 && occRankId == 1)
            //{
            //    return OccRankChengHao[occ - 1];
            //}
            //if (rankId >= 1 && rankId <= 3)
            //{
            //    return RankChengHao[rankId - 1];
            //}
            if ( occRankId >= 1 && occRankId <= 3)
            {
                return ConfigData.OccRankChengHao[ (occ - 1) * 3 + occRankId - 1 ];
            }
            return string.Empty;
        }

    }
}
