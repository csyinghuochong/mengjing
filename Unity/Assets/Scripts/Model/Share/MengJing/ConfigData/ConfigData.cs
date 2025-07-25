using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET
{
    public static class ConfigData
    {
        public const float DefaultShiquRange = 6f;

        [StaticField]
        public static long LastRemoveTime = 0;

        [StaticField]
        public static object SyncObject = new object();

        
        // 需要服务器热重载改变的为static,  不需要热重载改变的为const/......
        
        /// <summary>
        /// 变成宠物持续时间，时间结束后变回英雄
        /// </summary>
        public const long PetSwichEndCD = 6;
        
        /// <summary>
        /// 变身宠物切换CD
        /// </summary>
        public const long PetSwichCD1 = 10;

        public const float PetSwichCD2 = 1f / PetSwichCD1;

        public const int PetFramgeItemId = 10000152;

        public const int PetMianShangBuff = 97020003;

        public const int EquipShiPingMax = 4;

        /// <summary>
        /// 深渊道具ID 
        /// </summary>
        public const int ShenYuanCostId = 1000031;
     
        public const int QiangHuaLuckyCostId = 1000037;

        public const int TaskGrowUpInitId = 820000;
        
        /// <summary>
        /// 小飞鞋
        /// </summary>
        public const int FlyToItem = 90000014;
        
        /// <summary>
        /// 个人副本  gm账号显示副本和新地图,大于等于指定副本id不显示
        /// </summary>
        [StaticField]
        public static int GMDungeonId = 60003;

        /// <summary>
        /// 组队副本  gm账号显示副本和新地图,大于等于指定副本id不显示
        /// </summary>
        [StaticField]
        public static int GmTeamdungeonId = 110006;

        [StaticField]
        public static int PlayerHideBuff = 97020004;

        [StaticField]
        public static bool LoadSceneFinished { get; set; }

        //npc对话最大距离
        [StaticField]
        public static float NpcDialogDistance = 5f;

        //随机副本魔能老人兑换消耗
        [StaticField]
        public static string EnergySkillCost = "10010031;5";

        //随机副本魔能老人技能列表
        [StaticField]
        public static List<int> EnergySkills = new List<int>() { 64000001, 64000002, 64000003, 64000004, 64000005, 64000006, 64000007, 64000008 };

        [StaticField]
        public static int MaxPetFightNumber = 3;

        [StaticField]
        public static List<int> NOPassiveSkill = new List<int>() { };

        [StaticField]
        public static Dictionary<int, List<int>> FubenToNpcList = new Dictionary<int, List<int>>() { };

        /// <summary>
        /// 猎人远程技能
        /// </summary>
        [StaticField]
        public static List<int> HunterFarSkill = new List<int>() { 63200101, 63200102, 63200103, 63200104 };

        /// <summary>
        /// 猎人近战技能
        /// </summary>
        [StaticField]
        public static List<int> HunterNearSkill = new List<int>() { 63200201, 63200202, 63200203, 63200204 };

        /// <summary>
        /// 目标任务 TaskConfig
        /// </summary>
        [StaticField]
        public static List<List<int>> WelfareTaskList = new List<List<int>>()
        {
            //第一天
            new List<int> { 71001001, 71001002, 71001003, 71001004, 71001005, 71001006 },
            //第二天
            new List<int> { 71002001, 71002002, 71002003, 71002004, 71002005, 71002006 },
            //第三天
            new List<int> { 71003001, 71003002, 71003003, 71003004, 71003005 },
            //第四天
            new List<int> { 71004001, 71004002, 71004003, 71004004, 71004005 },
            //第五天
            new List<int> { 71005001, 71005002, 71005003, 71005004, 71005005 },
            //第六天
            new List<int> { 71006001, 71006002, 71006003, 71006004, 71006005 },
            //第七天
            new List<int> { 71007001, 71007002, 71007003, 71007004, 71007005 },
        };

        [StaticField]
        public static List<BossDevelopment> BossDevelopmentList_5 = new List<BossDevelopment>()
        {
            new BossDevelopment() { Name = "初级领主", Level = 1, AttributeAdd = 1f, ExpAdd = 1f, ReviveTimeAdd = 1f, DropAdd = 1f, KillNumber = 0 },
            new BossDevelopment()
                    { Name = "次级领主", Level = 2, AttributeAdd = 1.1f, ExpAdd = 1.25f, ReviveTimeAdd = 1.25f, DropAdd = 1.15f, KillNumber = 3 },
            new BossDevelopment()
                    { Name = "中级领主", Level = 3, AttributeAdd = 1.2f, ExpAdd = 1.5f, ReviveTimeAdd = 1.5f, DropAdd = 1.3f, KillNumber = 5 },
            new BossDevelopment()
                    { Name = "高级领主", Level = 4, AttributeAdd = 1.3f, ExpAdd = 1.75f, ReviveTimeAdd = 1.75f, DropAdd = 1.4f, KillNumber = 10 },
            new BossDevelopment() { Name = "终级领主", Level = 5, AttributeAdd = 1.4f, ExpAdd = 2f, ReviveTimeAdd = 2f, DropAdd = 1.5f, KillNumber = 20 },
        };

        [StaticField]
        public static List<BossDevelopment> BossDevelopmentList_6 = new List<BossDevelopment>()
        {
            new BossDevelopment() { Name = "初级领主", Level = 1, AttributeAdd = 1f, ExpAdd = 1f, ReviveTimeAdd = 1f, DropAdd = 1f, KillNumber = 0 },
            new BossDevelopment()
                    { Name = "次级领主", Level = 2, AttributeAdd = 1.1f, ExpAdd = 1.25f, ReviveTimeAdd = 1.25f, DropAdd = 1.15f, KillNumber = 3 },
            new BossDevelopment()
                    { Name = "中级领主", Level = 3, AttributeAdd = 1.2f, ExpAdd = 1.5f, ReviveTimeAdd = 1.5f, DropAdd = 1.3f, KillNumber = 5 },
            new BossDevelopment()
                    { Name = "高级领主", Level = 4, AttributeAdd = 1.3f, ExpAdd = 1.75f, ReviveTimeAdd = 1.75f, DropAdd = 1.4f, KillNumber = 10 },
            new BossDevelopment() { Name = "终级领主", Level = 5, AttributeAdd = 1.4f, ExpAdd = 2f, ReviveTimeAdd = 2f, DropAdd = 1.5f, KillNumber = 20 },
        };

        //装备传承部位通用
        //技能id，权重概率
        [StaticField]
        public static List<EquipChuanChengList> EquipChuanChengSkillCom = new List<EquipChuanChengList>()
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


        //装备传承职业对应激活技能
        [StaticField]
        public static Dictionary<int, List<EquipChuanChengList>> EquipChuanChengSkillOccTwo =
                new Dictionary<int, List<EquipChuanChengList>>()
                {
                    {
                        11, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69011101, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011102, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011103, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011104, RandPro = 100 },
                        }
                    },

                    {
                        12, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69011201, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011202, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011203, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011204, RandPro = 100 },
                        }
                    },

                    {
                        13, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69011301, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011302, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011303, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69011304, RandPro = 100 },
                        }
                    },

                    {
                        21, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69012101, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012102, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012103, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012104, RandPro = 100 },
                        }
                    },

                    {
                        22, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69012201, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012202, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012203, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012204, RandPro = 100 },
                        }
                    },

                    {
                        23, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69012301, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012302, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012303, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69012304, RandPro = 100 },
                        }
                    },
                };

        //装备传承部位对应激活技能
        [StaticField]
        public static Dictionary<int, List<EquipChuanChengList>> EquipChuanChengSkillOcc =
                new Dictionary<int, List<EquipChuanChengList>>()
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

        //类型对应部位
        [StaticField]
        public static Dictionary<int, List<EquipChuanChengList>> EquipChuanChengSkill =
                new Dictionary<int, List<EquipChuanChengList>>()
                {
                    //攻击
                    {
                        1, new List<EquipChuanChengList>()
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
                        }
                    },

                    //防御
                    {
                        2, new List<EquipChuanChengList>()
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
                        }
                    },

                    //技能_战士
                    {
                        11, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69033101, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033102, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033103, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033104, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033105, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033106, RandPro = 100 },
                        }
                    },

                    //技能_法师
                    {
                        12, new List<EquipChuanChengList>()
                        {
                            new EquipChuanChengList() { SkillID = 69033201, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033202, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033203, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033204, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033205, RandPro = 100 },
                            new EquipChuanChengList() { SkillID = 69033206, RandPro = 100 },
                        }
                    },
                };

        //觉醒技能ID
        [StaticField]
        public static List<int> JueXingSkillIDList =
                new List<int>()
                {
                    60031111,
                    60031121,
                    60031131,
                    60031132,
                    60031141,
                    60031151,
                    60031161,
                    60031162,
                };

        /// <summary>
        /// 神兽羁绊属性
        /// </summary>
        [StaticField]
        public static Dictionary<int, List<PropertyValue>> ShenShouJiBan =
                new Dictionary<int, List<PropertyValue>>()
                {
                    { 1, new List<PropertyValue>() { new PropertyValue() { HideID = 201003, HideValue = 1000 } } },
                    {
                        2,
                        new List<PropertyValue>()
                        {
                            new PropertyValue() { HideID = 200903, HideValue = 1000 } /*, new PropertyValue() { HideID = 105201, HideValue = 0 }*/
                        }
                    },
                    { 3, new List<PropertyValue>() { new PropertyValue() { HideID = 200903, HideValue = 1500 } } },
                };

        /// <summary>
        /// 支持批量使用的道具.  目前服务器只支持ItemSubType = 111 的道具批量使用
        /// 支持批量使用的道具客户端点击使用的时候二次弹框，输入使用数量。
        /// self.ZoneScene().GetComponent<BagComponent>().SendUseItem(self.BagInfo, 使用数量).Coroutine();
        /// </summary>
        [StaticField]
        public static List<int> BatchUseItemList = new()
        {
            10010042, 10010043
        };

        public const string RobotPassWord = "et@#robot";

        //客戶端活动提示
        [StaticField]
        public static List<ActivityTipConfig> ActivityShowList = new List<ActivityTipConfig>()
        {
            new ActivityTipConfig() { OpenTime = 1940, OpenDay = new List<int> { -1 }, CloseTime = 1950, Conent = "角斗场", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2000, OpenDay = new List<int> { 1, 3, 5, 0 }, CloseTime = 2025, Conent = "世界领主活动开启", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2000, OpenDay = new List<int> { 2, 4, 6 }, CloseTime = 2025, Conent = "小龟赛跑", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2030, OpenDay = new List<int> { -1 }, CloseTime = 2055, Conent = "战场活动开启", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2100, OpenDay = new List<int> { 1, 3, 5, 0 }, CloseTime = 2115, Conent = "宝藏活动开启", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2100, OpenDay = new List<int> { 2, 4, 6 }, CloseTime = 2105, Conent = "变身大赛活动开启", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2130, OpenDay = new List<int> { 1, 3, 5, 0 }, CloseTime = 2140, Conent = "狩猎活动", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2130, OpenDay = new List<int> { 2, 4, 6 }, CloseTime = 2140, Conent = "喜从天降", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2200, OpenDay = new List<int> { 2, 4, 6 }, CloseTime = 2210, Conent = "公会入侵", UIType = 0 },
            new ActivityTipConfig() { OpenTime = 2200, OpenDay = new List<int> { 1, 3, 5, 0 }, CloseTime = 2200, Conent = "竞技场活动开启", UIType = 0 },
            //new ActivityTipConfig(){ OpenTime = 2130, OpenDay = new List<int>{ -1},CloseTime = 2155, Conent = "竞技场活动开启"  , UIType = string.Empty },
            //示例
            //new ActivityTipConfig(){ OpenTime = 1516, CloseTime = 1517, Conent = "活动333" , UIType = "Main/Chat/UIChat"  },
        };

        [StaticField]
        public static Dictionary<int, ServerInfo> ServerInfoList = new Dictionary<int, ServerInfo>();

        [StaticField]
        public static bool ShowLieOpen = false;

        [StaticField]
        public static string ChangeOccItem = "10000178;1";

        [StaticField]
        public static int BuChangZone = 5;

        [StaticField]
        public static int BuChangEnd = 20221130;

        [StaticField]
        public static bool NetVersion = true;

        //赠送钻石数量
        [StaticField]
        public static Dictionary<int, int> RechargeGive = new(8)
        {
            { 6, 0 },
            { 30, 300 },
            { 50, 600 },
            { 98, 1200 },
            { 198, 2888 },
            { 298, 4888 },
            { 488, 8888 },
            { 648, 12888 },
        };

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
        /// 宠物守护队伍开启等级
        /// </summary>
        [StaticField]
        public static List<int> PetMiningTeamOpenLevel = new List<int>() { 1, 30, 40 };

        /// <summary>
        /// 宠物矿场
        /// </summary>
        [StaticField]
        public static Dictionary<int, List<PetMiningItem>> PetMiningList = new Dictionary<int, List<PetMiningItem>>()
        {
            {
                10001, new List<PetMiningItem>()
                {
                    new PetMiningItem() { X = 266, Y = -118 },
                    new PetMiningItem() { X = 653, Y = 2 },
                    new PetMiningItem { X = 1017, Y = -118 },
                    new PetMiningItem { X = 1672, Y = -38 },
                    new PetMiningItem { X = 2277, Y = -88 },
                }
            },
            {
                10002, new List<PetMiningItem>()
                {
                    new PetMiningItem() { X = 201, Y = -42 },
                    new PetMiningItem() { X = 501, Y = -159 },
                    new PetMiningItem { X = 990, Y = -164 },
                    new PetMiningItem { X = 1260, Y = 106 },
                    new PetMiningItem { X = 751, Y = 53 },
                    new PetMiningItem() { X = 1673, Y = -109 },
                    new PetMiningItem() { X = 2196, Y = -109 },
                    new PetMiningItem { X = 2637, Y = -109 },
                    new PetMiningItem { X = 2466, Y = 24 },
                    new PetMiningItem { X = 1918, Y = 24 },
                }
            },
            {
                10003, new List<PetMiningItem>()
                {
                    new PetMiningItem() { X = 201, Y = 189 },
                    new PetMiningItem() { X = 208, Y = -197 },
                    new PetMiningItem { X = 500, Y = -164 },
                    new PetMiningItem { X = 496, Y = 152 },
                    new PetMiningItem { X = 795, Y = 179 },
                    new PetMiningItem { X = 798, Y = -197 },
                    new PetMiningItem { X = 1082, Y = -176 },
                    new PetMiningItem { X = 1084, Y = 155 },
                    new PetMiningItem { X = 1367, Y = 168 },
                    new PetMiningItem { X = 1359, Y = -174 },
                    new PetMiningItem() { X = 2403, Y = 155 },
                    new PetMiningItem() { X = 1618, Y = -189 },
                    new PetMiningItem { X = 2141, Y = -197 },
                    new PetMiningItem { X = 1625, Y = 160 },
                    new PetMiningItem { X = 1882, Y = -164 },
                    new PetMiningItem { X = 1876, Y = 152 },
                    new PetMiningItem { X = 2138, Y = 179 },
                    new PetMiningItem { X = 2401, Y = -176 },
                    new PetMiningItem { X = 2673, Y = 168 },
                    new PetMiningItem { X = 2671, Y = -174 },
                }
            },
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
        
        //伏击
        public const string Skill_Ambushing = "Skill_Ambushing";
        
        public const string Skill_Halo_2 = "Skill_Halo_2";
        
        public const string Skill_Other_ChongJi_1 = "Skill_Other_ChongJi_1";

        public const string Skill_XuanZhuan_Attack_2 = "Skill_XuanZhuan_Attack_2";

        public const string Skill_ComTargetMove_RangDamge_7 = "Skill_ComTargetMove_RangDamge_7";

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
            { ItemGetWay.UnionXiuLian, "公会修炼" },
            { ItemGetWay.UnionBoss, "公会BOSS" },
            { ItemGetWay.UnionRace, "公会争霸" },
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
            { ItemGetWay.UnionUpLv, "公会升级" },
            { ItemGetWay.GemHeCheng, "宝石合成" },
            { ItemGetWay.SoloReward, "竞技场奖励" },
            { ItemGetWay.Activity_MaoXianJia, "冒险家" },
            { ItemGetWay.Activity_ZhanQu, "战区活动" },
            { ItemGetWay.Recharge, "充值" },
            { ItemGetWay.TowerOfSealCost, "封印之塔消耗钻石" },
            { ItemGetWay.JueXing, "觉醒" },
            { ItemGetWay.Activity_DayTeHui, "每日特惠" },
            { ItemGetWay.UnionMysteryBuy, "公会神秘商店" },
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
            { ItemGetWay.SingleRecharge, "宠物探索" },
            { ItemGetWay.ItemXiLian, "道具洗练" },
            { ItemGetWay.ActivityNewYear, "新年活动" },
            { ItemGetWay.PetMeleeReward, "宠物战斗奖励" },
            { ItemGetWay.UnionWish, "公会许愿" },
            { ItemGetWay.UnionOrder, "公会订单" },
            { ItemGetWay.TakeOutBag, "背包拿出" },

            { ItemGetWay.Activity, "活动" },
        };

        // 游戏公告
        [StaticField]
        public static List<WorldSayConfig> WorldSayList = new()
        {
            new WorldSayConfig() { Time = 1230, OpenDay = new List<int> { -1 }, Conent = "巨龙神已经准时出现在宝藏之地，想要挑战我的就带上你们的武器过来挑战我吧!" },
            new WorldSayConfig() { Time = 1930, OpenDay = new List<int> { -1 }, Conent = "一波红包雨已经来临，赶紧来看看自己是否是那个幸运玩家!" },
            new WorldSayConfig() { Time = 1940, OpenDay = new List<int> { -1 }, Conent = "角斗场已经开启,想要参加的勇士要抓紧时间哦!" },
            new WorldSayConfig() { Time = 2000, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "世界领主已经出现在密境中，赶紧过来看看吧!" },
            new WorldSayConfig() { Time = 2015, OpenDay = new List<int> { -1 }, Conent = "拍卖特惠已经开启，有需要的玩家可以购买哦!" },
            new WorldSayConfig() { Time = 2030, OpenDay = new List<int> { -1 }, Conent = "战场活动已经开启，可以通过右上角的战场按钮快速加入哦!" },
            new WorldSayConfig() { Time = 2100, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "一大波宝箱出现在宝藏之地，想要去的玩家赶紧前往哦!" },
            new WorldSayConfig() { Time = 2110, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "一大波宝箱出现在宝藏之地，想要去的玩家赶紧前往哦!" },
            new WorldSayConfig() { Time = 2120, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "一大波宝箱出现在宝藏之地，想要去的玩家赶紧前往哦!" },
            new WorldSayConfig() { Time = 2100, OpenDay = new List<int> { 2, 4, 6 }, Conent = "变身大赛活动即将开启，想要参加的小伙伴记得要准时参加噢，5分钟后开启正式比赛!" },
            //年兽
            new WorldSayConfig() { Time = 2114, OpenDay = new List<int> { -1 }, Conent = "新年活动:新年的年兽-夕还有1分钟即将来到宝藏之地，主城的勇士们，带上你们的装备快去迎接挑战吧！" },
            new WorldSayConfig()
            {
                Time = 2115, OpenDay = new List<int> { -1 }, Conent = "新年的年兽-夕：我已经等了整整一年，弱者不配与我进行战斗，想要挑战我的就带上你们的装备过来吧，我已经到来到宝藏之地的中心！"
            },
            new WorldSayConfig() { Time = 2000, OpenDay = new List<int> { -1 }, Conent = "新年活动:捣乱的年兽出现在宝藏之地，想要去的玩家带上鞭炮赶紧前往哦!" },
            new WorldSayConfig() { Time = 2100, OpenDay = new List<int> { -1 }, Conent = "新年活动:捣乱的年兽出现在宝藏之地，想要去的玩家带上鞭炮赶紧前往哦!" },
            new WorldSayConfig() { Time = 2200, OpenDay = new List<int> { -1 }, Conent = "新年活动:捣乱的年兽出现在宝藏之地，想要去的玩家带上鞭炮赶紧前往哦!" },
            new WorldSayConfig() { Time = 2200, OpenDay = new List<int> { 2, 4, 6 }, Conent = "公会入侵:公会出现了入侵怪兽，想要奖励的小勇士请带上你们的武器速速前往!" },
            new WorldSayConfig() { Time = 2200, OpenDay = new List<int> { 1, 3, 5, 0 }, Conent = "竞技场活动已经开启，想要证明自己能力的小伙伴记得前往噢!" },
        };

        /// <summary>
        /// 赛季开时间
        /// </summary>
        [StaticField]
        public static List<KeyValuePairLong> SeasonTimeList = new List<KeyValuePairLong>()
        {
            new KeyValuePairLong(){ KeyId = 0, Value = 1701360000000, Value2 = 1713715200000 },
            new KeyValuePairLong(){ KeyId = 1, Value = 1713715200001, Value2 = 1721577600000 },
            new KeyValuePairLong(){ KeyId = 2, Value = 1721577600001, Value2 = 1730390400000 },
            new KeyValuePairLong(){ KeyId = 3, Value = 1730390400001, Value2 = 1738339200000 },
            new KeyValuePairLong(){ KeyId = 4, Value = 1738339200001, Value2 = 1753977600000 },
        };

        public const int SeasonBossId = 820001;

        /// <summary>
        /// 赛季BOSS  bossid->exp  默认O级
        /// </summary>
        [StaticField]
        public static List<KeyValuePairInt> CommonSeasonBossList = new List<KeyValuePairInt>()
        {
            new KeyValuePairInt(){ KeyId = 820001, Value = 10},
            new KeyValuePairInt(){ KeyId = 820001, Value = 20},
            new KeyValuePairInt(){ KeyId = 820001, Value = 30},
            new KeyValuePairInt(){ KeyId = 820001, Value = 40},
            new KeyValuePairInt(){ KeyId = 820001, Value = 50},
            new KeyValuePairInt(){ KeyId = 820001, Value = 60},
            new KeyValuePairInt(){ KeyId = 820001, Value = 70},
            new KeyValuePairInt(){ KeyId = 820001, Value = 80},
            new KeyValuePairInt(){ KeyId = 820001, Value = 90},
            new KeyValuePairInt(){ KeyId = 820001, Value = 100},
        };
        
        /// <summary>
        /// 赛季捐选奖励
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> CommonSeasonDonateReward = new Dictionary<int, string>()
        {
            { 10, "1;100000@1000036;20@1000018;20" },
            { 20, "1;200000@1000036;30@1000018;30@1000020;1" },
            { 30, "1;300000@1000036;50@1000018;50@1000020;1@1010002;1" }
        };

        [StaticField]
        public static Dictionary<int, int> MonsterToFuben = new Dictionary<int, int>();

        //成就炼金使用这些药剂增加点数
        [StaticField]
        public static List<int> ChengJiuLianJin =
                new List<int>
                {
                 1030001,1030002,1030003,1030004,1030005,
                 1030011,1030012,1030013,1030014,1030015,
                };

        //生命之盾
        [StaticField]
        public static Dictionary<int, int> ItemAddShieldExp =
                new Dictionary<int, int>()
                {
                    { 1020001, 1 },
                 { 1021001, 1 },
                 { 1021002, 1 },
                 { 1021003, 1 },
                 { 1021004, 1 },
                 { 1021005, 1 },
                 { 1021006, 1 },
                 { 1021007, 1 },
                 { 1021008, 200 },
                 { 1021009, 300 },
                 { 1021010, 1 },
                 { 1022001, 1 },
                 { 1022002, 1 },
                 { 1022003, 1 },
                 { 1022004, 1 },
                 { 1022005, 1 },
                 { 1022006, 1 },
                 { 1022007, 1 },
                 { 1022008, 200 },
                 { 1022009, 300 },
                 { 1022010, 1 },
                 { 1023001, 1 },
                 { 1023002, 1 },
                 { 1023003, 1 },
                 { 1023004, 1 },
                 { 1023005, 1 },
                 { 1023006, 1 },
                 { 1023007, 1 },
                 { 1023008, 200 },
                 { 1023009, 300 },
                 { 1023010, 1 },
                 { 1024001, 1 },
                 { 1024002, 1 },
                 { 1024003, 1 },
                 { 1024004, 1 },
                 { 1024005, 1 },
                 { 1024006, 1 },
                 { 1024007, 1 },
                 { 1024008, 200 },
                 { 1024009, 300 },
                 { 1024010, 1 },
                 { 1025001, 1 },
                 { 1025002, 1 },
                 { 1025003, 1 },
                 { 1025004, 1 },
                 { 1025005, 1 },
                 { 1025006, 1 },
                 { 1025007, 1 },
                 { 1025008, 200 },
                 { 1025009, 300 },
                 { 1025010, 1 },
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
                    { 50, "1000034;1$3;100,1000" }, //钻石特殊处理, 也可以定位其他格式
                    { 100, "1000020;1$3;200,1000" }, //钻石特殊处理
                    { 150, "1000020;1$3;300,1500" },
                    { 200, "1000035;1$3;400,2000" },
                    { 300, "1000002;1$3;500,2500" },
                };

        [StaticField]
        public static List<float3> Formation_1 =
                new List<float3>()
                {
                    //前排
                    new float3(-20f + 21.16f, 0f, 12f -9.25f),
                    new float3(-20f + 21.16f, 0f, 12f -12.3f),
                    new float3(-20f + 21.16f, 0f, 12f -15.42f),
                    //中排 
                    new float3(-20f + 21.16f + 2f, 0f, 12f-9.25f),
                    new float3(-20f + 21.16f + 2f, 0f, 12f-12.3f),
                    new float3(-20f + 21.16f + 2f, 0f, 12f-15.42f),
                    //后排 
                    new float3(-20f + 21.16f + 4f, 0f, 12f-9.25f),
                    new float3(-20f + 21.16f + 4f, 0f, 12f-12.3f),
                    new float3(-20f + 21.16f + 4f, 0f, 12f-15.42f),
                };

        //对方位置
        [StaticField]
        public static List<float3> Formation_2 =
                new List<float3>()
                {
                    //前排
                    new float3(-20f + 14.89f, 0f, 12f  -9.25f),
                    new float3(-20f + 14.89f, 0f, 12f  -12.3f),
                    new float3(-20f + 14.89f, 0f, 12f  -15.42f),
                    //中排
                    new float3(-20f + 14.89f - 2f, 0f, 12f  -9.25f),
                    new float3(-20f + 14.89f - 2f, 0f, 12f  -12.3f),
                    new float3(-20f + 14.89f - 2f, 0f, 12f  -15.42f),
                    //后排-
                    new float3(-20f + 14.89f - 4f, 0f, 12f  -9.25f),
                    new float3(-20f + 14.89f - 4f, 0f, 12f  -12.3f),
                    new float3(-20f + 14.89f - 4f, 0f, 12f  -15.42f),
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

        //摄像机位置
        [StaticField]
        public static float3 PetMeleeFuBenCameraPosition =
                new float3(0, 12, -11);

        [StaticField]
        public static float3 PetMeleeFuBenCameraRotation =
                new float3(50, 0, 0);

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
        public static float3 PastureInitPos = new float3(11f, 0f, -15f);

        [StaticField]
        public static string UI_pro_4_2 = "UI_pro_4_2";

        [StaticField]
        public static string UI_pro_3_2 = "UI_pro_3_2";

        [StaticField]
        public static List<float3> PlanPositionList = new List<float3>()
        {
            new float3(22.73f, 0.16f, -4.37f),
            new float3(22.73f, 0.16f, -4.37f - 3f),
            new float3(22.73f, 0.16f, -4.37f - 6f),
            new float3(22.73f, 0.16f, -4.37f - 9f),

            new float3(19.78f, 0.16f, -4.37f),
            new float3(19.78f, 0.16f, -4.37f - 3f),
            new float3(19.78f, 0.16f, -4.37f - 6f),
            new float3(19.78f, 0.16f, -4.37f - 9f),

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
        public static readonly object _lockObject = new object();
        [StaticField]
        public static List<ServerItem> ServerItems = new List<ServerItem>()
        {

        };

        /// <summary>
        /// 小龟说话
        /// </summary>
        //1移动 2停止
        [StaticField]
        public static Dictionary<int, List<string>> TurtleSpeakList = new()
        {
            { 1, new List<string>() { "不知道后面是不是有东西追我，我号好害怕，我要赶紧溜。", "加油，我一定是最后获得胜利的那只神龟。", "冲冲冲，我不会让大家失望的!" } }, //开始跑了
            { 2, new List<string>() { "我好累，妈妈说累了就可以歇一歇。", "好饱啊，我要停下来歇一歇。", "唉呀，谁用石头丢了我一下，头好晕哦。" } }
        };

        /// <summary>
        /// 角色属性推荐加点,按比例加点
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> RecommendAddPoint = new Dictionary<int, string>()
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

        /// <summary>
        /// 背包一键出售增幅
        /// </summary>
        [StaticField]
        public static List<List<int>> OneSellList = new List<List<int>>()
        {
            // 基础
            new List<int> { 11300101, 11300102, 11300103, 11300104, 11300105 },
            // 中级
            new List<int> { 11300201, 11300202, 11300203, 11300204, 11300205 },
            // 高级
            new List<int> { 11300301, 11300302, 11300303, 11300304, 11300305 },
            // 特级
            new List<int> { 11300401, 11300402, 11300403, 11300404, 11300405 },
            // 超级 
            new List<int> { 11300501, 11300502, 11300503, 11300504, 11300505 },
            // 终极
            new List<int> { 11300601, 11300602, 11300603, 11300604, 11300605 }
        };

        /// <summary>
        /// 封印塔等级配置, KeyId.ToweConfigid.  value=monsterid
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> SealTowerLevelConfig = new Dictionary<int, int>()
        {
            { 20,   201000 },
            { 30,   202000 },
            { 40,   203000 },
            { 50,   204000 },
            { 60,   205000 },
            { 1000, 206000 }
        };
        
        /// <summary>
        /// 成长任务奖励配置, KeyId.完成数量.  value=skillid  
        /// </summary>
        [StaticField]
        public static Dictionary<int,int> TaskGrowUpRewardConfig = new Dictionary<int, int>()   
        {
            {4,1400011},
            {7,1400012},
            {10,1400013},
            {14,1400021},
            {17,1400022},
            {20,1400023},
            {24,1400031},
            {27,1400032},
            {30,1400033},
            {34,1400041},
            {37,1400042},
            {40,1400043},
            {44,1400051},
            {47,1400052},
            {50,1400053},
        };

        #region 宠物抓捕配置
        [StaticField]
        public static int ZhuaBuQiItemId = 90000016;
        #endregion
        
        #region 公会祝福配置
        /// <summary>
        /// 公会祝福奖励。  1免费祝福 2金币祝福 3钻石祝福
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> UnionWishRewardForType = new Dictionary<int, string>()
        {
            { 1, "35;10000@16;10@1000018;1" },
            { 2, "35;100000@16;30@1000018;5"  },
            { 3, "35;100000@16;50@1000018;10"  },
        };
        /// <summary>
        /// 公会祝福金币消耗
        /// </summary>
        [StaticField]
        public static int UnionWishGetGoldCost = 50000;
        /// <summary>
        /// 公会祝福钻石消耗
        /// </summary>
        [StaticField]
        public static int UnionWishGetDiamondCost = 300;
        
        /// <summary>
        /// 不同的职位对应的奖励礼包    1会长 2副会长 3长老 0其他
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> UnionWishRewardForPosition = new Dictionary<int, string>()
        {
            { 1, "1010053;1" },
            { 2, "1010054;1"  },
            { 3, "1010053;1"  },
            { 0, "1010055;1"  },
        };
        
        /// <summary>
        /// 会长祝福
        /// </summary>
        [StaticField]
        public static int UnionWishSendDiamondCost = 100000;
        #endregion
        
        # region 宠物乱斗配置

        /// <summary>
        /// 宠物乱斗章节关卡
        /// </summary>
        /// <returns></returns>
        [StaticField]
        public static List<List<int>> PetMeleeSectionConfig = new List<List<int>>()
        {
            new List<int>() { 2700101,2700102,2700103,2700104,2700105,2700106,2700107,2700108,2700109,2700110,2700111,2700112,2700113,2700114,2700115,2700116,2700117,2700118,2700119,2700120},
            new List<int>() { 2700201,2700202,2700203,2700204,2700205,2700206,2700207,2700208,2700209,2700210,2700211,2700212,2700213,2700214,2700215,2700216,2700217,2700218,2700219,2700220},
            new List<int>() { 2700301,2700302,2700303,2700304,2700305,2700306,2700307,2700308,2700309,2700310,2700311,2700312,2700313,2700314,2700315,2700316,2700317,2700318,2700319,2700320},
            new List<int>() { 2700401,2700402,2700403,2700404,2700405,2700406,2700407,2700408,2700409,2700410,2700411,2700412,2700413,2700414,2700415,2700416,2700417,2700418,2700419,2700420},
            new List<int>() { 2700501,2700502,2700503,2700504,2700505,2700506,2700507,2700508,2700509,2700510,2700511,2700512,2700513,2700514,2700515,2700516,2700517,2700518,2700519,2700520},
        };
        
        /// <summary>
        /// 初始魔力值
        /// </summary>
        [StaticField]
        public static int PetMeleeMoLiBase = 60;

        /// <summary>
        /// 每秒回复魔力值
        /// </summary>
        [StaticField]
        public static int PetMeleeMoLiRPS = 1;

        /// <summary>
        /// 魔力值上限
        /// </summary>
        [StaticField]
        public static int PetMeleeMoLiMax = 100;

        /// <summary>
        /// 主战宠物卡消耗
        /// </summary>
        [StaticField]
        public static int PetMeleeMainPetCost = 30;

        /// <summary>
        /// 主战宠物卡最多选几个
        /// </summary>
        [StaticField]
        public static int PetMeleeMainPetMaxNum = 6;

        /// <summary>
        /// 辅战宠物卡最多选几个
        /// </summary>
        [StaticField]
        public static int PetMeleeAssistPetMaxNum = 12;

        /// <summary>
        /// 魔法卡最多选几个
        /// </summary>
        [StaticField]
        public static int PetMeleeSkillMaxNum = 6;

        /// <summary>
        /// 测试 魔法卡技能，目前由主角释放，配置技能的释放范围要大些
        /// </summary>
        [StaticField]
        public static List<int> PetMeleeMagicTest = new() { 1001, 1002, 1003, 1004, 1005, 1006, 1007, 1008, 1009, 1010, 1011, 1012, 1013, 1014, 1015, 1016, 1017 };

        /// <summary>
        /// 手持多少张牌
        /// </summary>
        [StaticField]
        public static int PetMeleeCarInHandNum = 5;

        /// <summary>
        /// 首回合主战宠物卡随机多少个
        /// </summary>
        [StaticField]
        public static int PetMeleeFirstMainPetNum = 1;

        /// <summary>
        /// 首回合辅战宠物卡随机多少个
        /// </summary>
        [StaticField]
        public static int PetMeleeFirstAssistPetNum = 3;

        /// <summary>
        /// 首回合魔法卡随机多少个
        /// </summary>
        [StaticField]
        public static int PetMeleeFirstMagicNum = 1;

        /// <summary>
        /// 主战宠物卡出现概率
        /// </summary>
        [StaticField]
        public static float PetMeleeMainPetProb = 0.2f;

        /// <summary>
        /// 辅战宠物卡出现概率
        /// </summary>
        [StaticField]
        public static float PetMeleeAssistPetProb = 0.3f;

        /// <summary>
        /// 魔法卡出现概率
        /// </summary>
        [StaticField]
        public static float PetMeleeSkillProb = 0.5f;

        /// <summary>
        /// 多少秒刷新一张卡牌
        /// </summary>
        [StaticField]
        public static long PetMeleeCardRefreshInterval = 10 * 1000;

        /// <summary>
        /// 召唤兽数量的限制，超过不能再进行召唤
        /// </summary>
        [StaticField]
        public static int PetMeleeMaxPetsInLine = 10;

        /// <summary>
        /// 游戏战斗时间，超过时间判定为输
        /// </summary>
        [StaticField]
        public static long PetMeleeBattleMaxTime = 300 * 1000;

        #endregion

        
        /// <summary>
        /// 宠物共鸣属性配置 key=属性id value=名字 value2=开启条件 等级&道具
        /// </summary>
        [StaticField]
        public static List<KeyValuePair> PetEchoAttri = new List<KeyValuePair>
        {
            new KeyValuePair() { KeyId = 200201, Value = "命中之源", Value2 = "10&1;100000" }, //命中  
            new KeyValuePair() { KeyId = 202201, Value = "攻击之源", Value2 = "20&1;200000@1000027;20" }, //暴击
            new KeyValuePair() { KeyId = 200401, Value = "抗暴之源", Value2 = "30&1;300000@1000027;40" }, //抗暴 
            new KeyValuePair() { KeyId = 202301, Value = "魔法之源", Value2 = "40&1;500000@1000027;60" }, //抗暴
            new KeyValuePair() { KeyId = 200301, Value = "闪避之源", Value2 = "50&1;700000@1000027;80" }, //闪避
            new KeyValuePair() { KeyId = 200101, Value = "暴击之源", Value2 = "60&1;1000000@1000027;100" }, //暴击

        };
        
        /// <summary>
        /// 宠物共鸣技能激活配置 key=总战力 value=技能ID
        /// </summary>
        [StaticField]
        public static List<KeyValuePairInt> PetEchoSkill = new List<KeyValuePairInt>
        {
            new KeyValuePairInt() { KeyId = 3000, Value = 77001801 }, 
            new KeyValuePairInt() { KeyId = 5000, Value = 77001802 }, 
            new KeyValuePairInt() { KeyId = 6000, Value = 77001803 }, 
            new KeyValuePairInt() { KeyId = 8000, Value = 77001804 }, 
            new KeyValuePairInt() { KeyId = 10000, Value = 77001805 },
            new KeyValuePairInt() { KeyId = 12000, Value = 77001806 }, 
            new KeyValuePairInt() { KeyId = 15000, Value = 77001807 }, 
            new KeyValuePairInt() { KeyId = 20000, Value = 77001808 },
        };

        /// <summary>
        /// 
        /// </summary>
        public const int PetDungeonPetLimit = 5;
        
        /// <summary>
        /// 宠物挑战放置宠物数量
        /// </summary>
        public const int PetMatchPetLimit = 6;
        
        /// <summary>
        /// SkillMake假配置
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> SkillMakeConfig = new Dictionary<int, string>()
        {
            { 1, "1140001;1070101;1070102;1070103;1070104;1508003;1510008;1510104" },    //锻造
            { 2, "1511004;1511008;1511012;1080101;1080102;1080103;1080401;1080402" },    //裁缝
            { 3, "1151001;1151002;1151005;1156002;1159001;1159001;1090101;1090102" },    //炼金
            { 6, "1101101;1101102;1101303;1101504;1101402;1101404;1101603;1101501" },    //铭文
        };
    }
}
