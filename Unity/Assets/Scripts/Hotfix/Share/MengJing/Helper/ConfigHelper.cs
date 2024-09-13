using System.Collections.Generic;

namespace ET
{

    public static class ConfigHelper
    {

        public static int PetFramgeItemId()
        {
            return 10000152;
        }
        
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
        //    "版本更新内容\r\n1.更新家族系统,可以创建家族邀请其他玩家加入。\r\n2.开启游戏第六章第一个地图,60级可进入。\r\n3.新增宠物守护系统,根据宠物评分可以增加暴击等相关属性。\r\n4.增加家园访问，其他玩家可以互相访问家园。\r\n5.家园小地图显示石块和树叶方便玩家快速查询。\r\n6.赏金任务需要的怪物数量缩减。\r\n7.创建角色增加随机姓名。\r\n8.修复牧师技能不加攻击的问题。\r\n9.增加天气系统。\r\n10.增加野外碰到精灵和宠物的几率。";


      
        //装备传承部位通用
            //技能id，权重概率
        public static List<EquipChuanChengList> EquipChuanChengSkillCom()
        {
                return new List<EquipChuanChengList>()
                    {
                        new EquipChuanChengList() { SkillID = 69041001, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69041002, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69041003, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69041004, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69041005, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69041006, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69041007, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021001, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021002, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021003, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021004, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021005, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021006, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021007, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021008, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021009, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021010, RandPro = 100 },
                    };
        }

        /// <summary>
        /// 宠物守护（0-3）
        /// </summary>
        public static List<KeyValuePair> PetShouHuAttri()
        {
            return new List<KeyValuePair>
            {
                new KeyValuePair(){  Value = "青龙守护", Value2 = "200101" },                      //暴击
                new KeyValuePair(){  Value = "白虎守护", Value2 = "200401" },                      //抗暴
                new KeyValuePair(){  Value = "朱雀守护", Value2 = "200201" },                      //命中
                new KeyValuePair(){  Value = "玄武守护", Value2 = "200301" },                      //闪避
                new KeyValuePair(){  Value = "神兽守护", Value2 = "" },
            };
        }

      
        /// <summary>
        /// KeyId 节假日 Value 周末
        /// </summary>
        public static Dictionary<int, KeyValuePairInt> HolidayList()
        {
            return new Dictionary<int, KeyValuePairInt>()
            {
                { 20230405, new KeyValuePairInt{  KeyId =1, Value = 0  } },
                { 20230408, new KeyValuePairInt{  KeyId =0, Value = 1  } },
            };
        }
        
        //购买背包
        public static List<BuyCellCost> BuyBagCellCosts()
        {
            return new List<BuyCellCost>
            {
                new BuyCellCost{ Cost = "10000156;1",Get = "10010041;5"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10010046;1"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10010093;1"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10000104;1"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10000143;5"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10010088;2"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10000150;1"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10000141;1"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10010086;2"},
                new BuyCellCost{ Cost = "10000156;1",Get = "10010026;1"},

            };
        }

        //游戏公告
        public static List<WorldSayConfig> WorldSayList()
        {
            return new List<WorldSayConfig>
        {
            new WorldSayConfig(){ Time = 1230, OpenDay = new List<int>{ -1},  Conent = "巨龙神已经准时出现在宝藏之地,想要挑战我的就带上你们的武器过来挑战我吧!"  },
            new WorldSayConfig(){ Time = 1930, OpenDay = new List<int>{ -1},  Conent = "一波红包雨已经来临,赶紧来看看自己是否是那个幸运玩家!"  },
            new WorldSayConfig(){ Time = 1940, OpenDay = new List<int>{ -1},  Conent = "角斗场已经开启,想要参加的勇士要抓紧时间哦!"  },
            new WorldSayConfig(){ Time = 2000, OpenDay = new List<int>{1,3,5,0},   Conent = "世界领主已经出现在密境中,赶紧过来看看吧!"  },
            new WorldSayConfig(){ Time = 2015, OpenDay = new List<int>{ -1},  Conent = "拍卖特惠已经开启,有需要的玩家可以购买哦!"  },
            new WorldSayConfig(){ Time = 2030, OpenDay = new List<int>{ -1},  Conent = "战场活动已经开启,可以通过右上角的战场按钮快速加入哦!"  },
            new WorldSayConfig(){ Time = 2100, OpenDay = new List<int>{ 1,3,5,0},  Conent = "一大波宝箱出现在宝藏之地,想要去的玩家赶紧前往哦!"  },
            new WorldSayConfig(){ Time = 2110, OpenDay = new List<int>{ 1,3,5,0},  Conent = "一大波宝箱出现在宝藏之地,想要去的玩家赶紧前往哦!"  },
            new WorldSayConfig(){ Time = 2120, OpenDay = new List<int>{ 1,3,5,0},  Conent = "一大波宝箱出现在宝藏之地,想要去的玩家赶紧前往哦!"  },
            new WorldSayConfig(){ Time = 2100, OpenDay = new List<int>{ 2,4,6},  Conent = "变身大赛活动即将开启,想要参加的小伙伴记得要准时参加噢,5分钟后开启正式比赛!"  },
            //年兽
            new WorldSayConfig(){ Time = 2114, OpenDay = new List<int>{ -1},  Conent = "新年活动:新年的年兽-夕还有1分钟即将来到宝藏之地,主城的勇士们,带上你们的装备快去迎接挑战吧！"  },
            new WorldSayConfig(){ Time = 2115, OpenDay = new List<int>{ -1},  Conent = "新年的年兽-夕：我已经等了整整一年,弱者不配与我进行战斗,想要挑战我的就带上你们的装备过来吧,我已经到来到宝藏之地的中心！" },
            new WorldSayConfig(){ Time = 2000, OpenDay = new List<int>{ -1},  Conent = "新年活动:捣乱的年兽出现在宝藏之地,想要去的玩家带上鞭炮赶紧前往哦!"  },
            new WorldSayConfig(){ Time = 2100, OpenDay = new List<int>{ -1},  Conent = "新年活动:捣乱的年兽出现在宝藏之地,想要去的玩家带上鞭炮赶紧前往哦!"  },
            new WorldSayConfig(){ Time = 2200, OpenDay = new List<int>{ -1},  Conent = "新年活动:捣乱的年兽出现在宝藏之地,想要去的玩家带上鞭炮赶紧前往哦!"  },
            new WorldSayConfig(){ Time = 2200, OpenDay = new List<int>{ 2,4,6},  Conent = "家族入侵:家族出现了入侵怪兽,想要奖励的小勇士请带上你们的武器速速前往!"  },
            new WorldSayConfig(){ Time = 2200, OpenDay = new List<int>{ 1,3,5,0},  Conent = "竞技场活动已经开启,想要证明自己能力的小伙伴记得前往噢!"  },
        };

        }
        
        /// <summary>
        /// 猎人远程技能
        /// </summary>
        public static List<int> HunterFarSkill()
        {
            return new List<int>() { 63200101, 63200102, 63200103, 63200104 };
        }

        /// <summary>
        /// 猎人近战技能
        /// </summary>
        public static List<int> HunterNearSkill()
        {
            return new List<int>() { 63200201, 63200202, 63200203, 63200204 };
        }


        /// <summary>
        /// 目标任务 TaskConfig
        /// </summary>
        public static List<List<int>> WelfareTaskList()
        {
            return new List<List<int>>()
            {
                //第一天
                new List<int>{ 71001001,71001002,71001003,71001004,71001005,71001006 },          
                //第二天
                new List<int>{ 71002001,71002002,71002003,71002004,71002005,71002006 },
                //第三天
                new List<int>{ 71003001,71003002,71003003,71003004,71003005 },
                //第四天
                new List<int>{ 71004001,71004002,71004003,71004004,71004005 },
                //第五天
                new List<int>{ 71005001,71005002,71005003,71005004,71005005 },
                //第六天
                new List<int>{ 71006001,71006002,71006003,71006004,71006005 },
                //第七天
                new List<int>{ 71007001,71007002,71007003,71007004,71007005 },
            };

        }

        
        public static List<BossDevelopment> BossDevelopmentList_5()
        {
            return new List<BossDevelopment>()
            {
                new BossDevelopment(){ Name = "初级领主", Level = 1, AttributeAdd = 1f,   ExpAdd = 1f,   ReviveTimeAdd = 1f,     DropAdd = 1f,   KillNumber = 0 },
                new BossDevelopment(){ Name = "次级领主", Level = 2, AttributeAdd = 1.1f, ExpAdd = 1.25f,    ReviveTimeAdd = 1.25f,   DropAdd = 1.15f, KillNumber = 3 },
                new BossDevelopment(){ Name = "中级领主", Level = 3, AttributeAdd = 1.2f, ExpAdd = 1.5f,    ReviveTimeAdd = 1.5f,     DropAdd = 1.3f, KillNumber = 5 },
                new BossDevelopment(){ Name = "高级领主", Level = 4, AttributeAdd = 1.3f, ExpAdd = 1.75f,    ReviveTimeAdd = 1.75f,   DropAdd = 1.4f, KillNumber = 10 },
                new BossDevelopment(){ Name = "终级领主", Level = 5, AttributeAdd = 1.4f, ExpAdd = 2f,    ReviveTimeAdd = 2f,     DropAdd = 1.5f, KillNumber = 20 },
            };
        }

        public static List<BossDevelopment> BossDevelopmentList_6()
        {
            return new List<BossDevelopment>()
            {
                new BossDevelopment(){ Name = "初级领主", Level = 1, AttributeAdd = 1f,    ExpAdd = 1f,   ReviveTimeAdd = 1f,     DropAdd = 1f,   KillNumber = 0 },
                new BossDevelopment(){ Name = "次级领主", Level = 2, AttributeAdd = 1.1f,  ExpAdd = 1.25f,  ReviveTimeAdd = 1.25f,   DropAdd = 1.15f, KillNumber = 3 },
                new BossDevelopment(){ Name = "中级领主", Level = 3, AttributeAdd = 1.2f,  ExpAdd = 1.5f,   ReviveTimeAdd = 1.5f,     DropAdd = 1.3f, KillNumber = 5 },
                new BossDevelopment(){ Name = "高级领主", Level = 4, AttributeAdd = 1.3f,  ExpAdd = 1.75f,   ReviveTimeAdd = 1.75f,   DropAdd = 1.4f, KillNumber = 10 },
                new BossDevelopment(){ Name = "终级领主", Level = 5, AttributeAdd = 1.4f,  ExpAdd = 2f,   ReviveTimeAdd = 2f,     DropAdd = 1.5f, KillNumber = 20 },
            };
        }

        public static List<BossDevelopment> GetBossDevelopmentByChapter(int chapterid)
        {
            if (chapterid == 6)
            {
                return BossDevelopmentList_6();
            }
            else
            {
                return BossDevelopmentList_5();
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

        /// <summary>
        /// 三个对应等级套装属性
        /// </summary>

        public static Dictionary<int, string> PetSuitProperty()
        {
            return new Dictionary<int, string>()
            {
                {  5, "205003,0.05;203003,0.2;203103,0.2" },
                {  8, "205003,0.1;203003,0.25;203103,0.25" },
                {  10, "205003,0.15;203003,0.3;203103,0.3" },
            };
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
                return PetSuitProperty()[10];
            }
            if (lv8number >= 3)
            {
                return PetSuitProperty()[8];
            }
            if (lv5number >= 3)
            {
                return PetSuitProperty()[5];
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


        /// <summary>
        /// 个人副本  gm账号显示副本和新地图,大于等于指定副本id不显示
        /// </summary>
        public static int GMDungeonId()
        {
            return 60003;
        }


        /// <summary>
        /// 组队副本  gm账号显示副本和新地图,大于等于指定副本id不显示
        /// </summary>
        public static int GmTeamdungeonId()
        {
            return 110006;
        }
    }
}
