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

        //觉醒技能ID
        public static List<int> JueXingSkillIDList()
        {
            return new List<int>() {
                60031111,
                60031121,
                60031131,
                60031132,
                60031141,
                60031151,
                60031161,
                60031162,
            };
        }

        
        //赠送钻石数量
        public static Dictionary<int, int> RechargeGive()
        {
            return new Dictionary<int, int>(8){
                { 6,        0},
                { 30,       300},
                { 50,       600},
                { 98,       1200},
                { 198,      2888},
                { 298,      4888},
                { 488,      8888},
                { 648,      12888},
            };
        }

        public static int GetDiamondNumber(int key)
        {
            if (!RechargeGive().ContainsKey(key))
            {
                return 0;
            }
            int number = RechargeGive()[key];
            return key * 100 + number;
        }


        ///// <summary>
        ///// 对比用
        ///// </summary>
        //public const string NoticeVersion = "1.0.0";        
        ////公告内容
        //public const string NoticeText =
        //    "版本更新内容\r\n1.更新家族系统,可以创建家族邀请其他玩家加入。\r\n2.开启游戏第六章第一个地图,60级可进入。\r\n3.新增宠物守护系统,根据宠物评分可以增加暴击等相关属性。\r\n4.增加家园访问，其他玩家可以互相访问家园。\r\n5.家园小地图显示石块和树叶方便玩家快速查询。\r\n6.赏金任务需要的怪物数量缩减。\r\n7.创建角色增加随机姓名。\r\n8.修复牧师技能不加攻击的问题。\r\n9.增加天气系统。\r\n10.增加野外碰到精灵和宠物的几率。";


        //类型对应部位
        public static Dictionary<int, List<EquipChuanChengList>> EquipChuanChengSkill()
        {
            return new Dictionary<int, List<EquipChuanChengList>>()
            {
                //攻击
                { 1, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69031001, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031002, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031003, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031004, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031005, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031006, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031007, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031008, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031009, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69031010, RandPro = 100 },
                }},

                //防御
                { 2, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69032001, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032002, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032003, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032004, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032005, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032006, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032007, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032008, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032009, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69032010, RandPro = 100 },
                }},

                //技能_战士
                { 11, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69033101, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033102, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033103, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033104, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033105, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033106, RandPro = 100 },
                }},

                //技能_法师
                { 12, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69033201, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033202, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033203, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033204, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033205, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69033206, RandPro = 100 },
                }},
            };
        }
        
        //装备传承职业对应激活技能
        public static Dictionary<int, List<EquipChuanChengList>> EquipChuanChengSkillOccTwo()
        {
            return new Dictionary<int, List<EquipChuanChengList>>()
            {

                { 11, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69011101, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011102, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011103, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011104, RandPro = 100 },
                }},

                { 12, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69011201, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011202, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011203, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011204, RandPro = 100 },
                }},

                { 13, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69011301, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011302, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011303, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69011304, RandPro = 100 },
                }},

                { 21, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69012101, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012102, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012103, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012104, RandPro = 100 },
                }},

                { 22, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69012201, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012202, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012203, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012204, RandPro = 100 },
                }},

                { 23, new List<EquipChuanChengList>()
                {
                     new EquipChuanChengList() { SkillID = 69012301, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012302, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012303, RandPro = 100 },
                     new EquipChuanChengList() { SkillID = 69012304, RandPro = 100 },
                }},

            };
        }
        
        //装备传承部位对应激活技能
        public static Dictionary<int, List<EquipChuanChengList>> EquipChuanChengSkillOcc()
        {
            return new Dictionary<int, List<EquipChuanChengList>>()
            {
                {
                    1, new List<EquipChuanChengList>()
                    {
                        new EquipChuanChengList() { SkillID = 69011001, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69011002, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69011003, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69011004, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69011005, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69011006, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021011, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021012, RandPro = 100 },

                    }
                },
                {
                    2, new List<EquipChuanChengList>()
                    {
                        new EquipChuanChengList() { SkillID = 69012001, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69012002, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69012003, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69012004, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69012005, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69012006, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021013, RandPro = 100 },
                        new EquipChuanChengList() { SkillID = 69021014, RandPro = 100 },
                    }
                },
            };
        }

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
            return new List<ET.WorldSayConfig>
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

        /// <summary>
        /// 角色属性推荐加点,按比例加点
        /// </summary>
        public static Dictionary<int, string> RecommendAddPoint()
        {
            return new Dictionary<int, string>()
            {
                { 1, "3@0@1@1@0" },
                { 2, "0@3@1@1@0" },
                { 3, "2@0@1@1@1" },
                { 101, "0@3@1@1@0" },
                { 102, "0@0@1@1@3" },
                { 103, "3@0@1@1@0" },
                { 201, "0@3@1@1@0" },
                { 202, "0@3@1@1@0" },
                { 203, "0@3@1@1@0" },
                { 301, "2@0@1@1@1" },
                { 302, "2@0@1@1@1" },
                { 303, "2@0@1@1@1" }
            };
        }

        public static Dictionary<int, string> PropertyHint()
        {
            return new Dictionary<int, string>()
        {
            { NumericType.Now_MaxHp, "自身的生命值上限,当生命值为0时便意味着自身的挑战失败" },
            { NumericType.Now_MaxAct, "伤害基础值,对目标造成伤害的主要属性" },
            { NumericType.Now_MaxDef, "物理防御,可以抵扣物理攻击带来的伤害" },
            { NumericType.Now_MaxAdf, "法术防御,可以抵扣魔法攻击带来的伤害" },
            { NumericType.Now_Mage, "会额外提升你所有的技能造成的伤害" },
            { NumericType.Now_Constitution, "提升生命和闪避，伤害减免属性" },
            { NumericType.Now_Power, "提升攻击，物防和物穿攻速属性" },
            { NumericType.Now_Intellect, "提升技能伤害，魔防和魔穿属性" },
            { NumericType.Now_Stamina, "提升双防，抗暴，战斗回血属性" },
            { NumericType.Now_Agility, "提升攻速，攻击，冷却缩减属性" },
            { NumericType.Now_Cri, "本次攻击触发暴击的概率" },
            { NumericType.Now_MageDamgeSubPro, "降低受到魔法类技能的伤害" },
            { NumericType.Now_Res, "抵抗对方暴击的概率和抵抗眩晕等控制类技能" },
            { NumericType.Now_ZhongJiPro, "攻击有概率使目标的防御降低为0,无视对方防御进行攻击" },
            { NumericType.Now_Hit, "命中敌人的附加概率，和闪避概率进行抵消" },
            { NumericType.Now_ZhongJi, "触发重击后额外附加的伤害值" },
            { NumericType.Now_Dodge, "受到敌人攻击闪避本次攻击的概率，可闪避普攻和技能" },
            { NumericType.Now_HuShiActPro, "攻击中降低敌人物理防御值百分比" },
            { NumericType.Now_HuShiMagePro, "攻击中降低敌人魔法防御值百分比" },
            { NumericType.Now_DamgeSubPro, "受到敌人攻击的伤害后，降低本次受到的伤害" },
            { NumericType.Now_HuShiDef, "攻击中降低敌人物理防御值固定值" },
            { NumericType.Now_Speed, "自身在地图中移动的速度" },
            { NumericType.Now_SkillCDTimeCostPro, "降低释放技能的冷却时间" },
            { NumericType.Now_CriLv, "根据当前的暴击等级换算成暴击概率附加到自身属性" },
            { NumericType.Now_MageDodgePro, "受到魔法技能伤害时,可以躲避本次魔法伤害的概率" },
            { NumericType.Now_ResLv, "根据当前的韧性等级换算成韧性概率附加到自身属性" },
            { NumericType.Now_ActDodgePro, "受到物理技能伤害时,可以躲避本次魔法伤害的概率" },
            { NumericType.Now_HitLv, "根据当前的命中等级换算成命中概率附加到自身属性" },
            { NumericType.Now_GeDang, "受到伤害可以减免对应的伤害值" },
            { NumericType.Now_DodgeLv, "根据当前的闪避等级换算成闪避概率附加到自身属性" },
            { NumericType.Now_ZhenShi, "每次攻击额外增加的固定伤害" },
            { NumericType.Now_ActDamgeAddPro, "使用物理攻击目标时额外造成的伤害" },
            { NumericType.Now_ActSpeedPro, "可以加快自身普通攻击的攻击频率" },
            { NumericType.Now_MageDamgeAddPro, "使用魔法攻击目标时额外造成的伤害" },
            { NumericType.Now_ShenNongPro, "使用药剂和技能为自身恢复生命值时,可以获得额外恢复的能力" },
            { NumericType.Now_ActDamgeSubPro, "受到物理伤害可以降低自身受到的伤害值" },
            { NumericType.Now_HuiXue, "战斗中提升额外的生命恢复" },
            { NumericType.Now_HuShiAdf, "攻击中降低敌人魔法防御值固定值" },
            { NumericType.Now_Luck, "当幸运达到10点时,你将刀刀发挥最高攻击!" }
        };
        
        }

        /// <summary>
        /// 背包一键出售增幅
        /// </summary>
        public static List<List<int>> OneSellList()
        {
            return  new List<List<int>>()
            {
                // 基础
                new List<int> { 11300101,11300102,11300103,11300104,11300105 },
                // 中级
                new List<int> { 11300201,11300202,11300203,11300204,11300205 },
                // 高级
                new List<int> { 11300301,11300302,11300303,11300304,11300305 },
                // 特级
                new List<int> { 11300401,11300402,11300403,11300404,11300405 },
                // 超级 
                new List<int> { 11300501,11300502,11300503,11300504,11300505 },
                // 终极
                new List<int> { 11300601,11300602,11300603,11300604,11300605 }
            };
        }
        


        /// <summary>
        /// 神兽羁绊属性
        /// </summary>
        public static Dictionary<int, List<PropertyValue>> ShenShouJiBan()
        {
            return new Dictionary<int, List<PropertyValue>>()
            {
                { 1, new List<PropertyValue>(){ new PropertyValue() { HideID = 201003,  HideValue = 1000 } } },
                { 2, new List<PropertyValue>(){ new PropertyValue() { HideID = 200903, HideValue = 1000 }/*, new PropertyValue() { HideID = 105201, HideValue = 0 }*/ } },
                { 3, new List<PropertyValue>(){ new PropertyValue() { HideID = 200903, HideValue = 1500 } } },
            };
        }


        /// <summary>
        /// 支持批量使用的道具.  目前服务器只支持ItemSubType = 111 的道具批量使用
        /// 支持批量使用的道具客户端点击使用的时候二次弹框，输入使用数量。
        /// self.ZoneScene().GetComponent<BagComponent>().SendUseItem(self.BagInfo, 使用数量).Coroutine();
        /// </summary>
        public static List<int> BatchUseItemList()
        {
            return new List<int>() { 10010042, 10010043 };
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
