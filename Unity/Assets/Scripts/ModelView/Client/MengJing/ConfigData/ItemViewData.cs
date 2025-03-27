using System.Collections.Generic;

namespace ET.Client
{
    public struct NumericAttribute
    {
        public string Name;
        public bool Float;
        public string Icon;
    }

    public static class ItemViewData
    {
        //消耗品
        [StaticField]
        public static Dictionary<int, string> ItemSubType1Name = new()
        {
            { 0, "全部" },
            { 101, "药剂" },
            { 15, "附魔" },
            { 127, "藏宝图" },
        };

        //材料
        [StaticField]
        public static Dictionary<int, string> ItemSubType2Name = new()
        {
            { 0, "全部" },
            { 1, "材料" },
            { 121, "鉴定符" },
            { 122, "宠物技能" },
        };

        //材料
        [StaticField]
        public static Dictionary<int, string> ItemSubType4Name = new()
        {
            { 0, "全部" },
            { 101, "黄色插槽" },
            { 102, "紫色插槽" },
            { 103, "蓝色插槽" },
            { 104, "绿色插槽" },
            { 105, "橙色插槽" },
        };

        [StaticField]
        public static Dictionary<int, List<int>> OccWeaponList = new()
        {
            { 1, new List<int>() { 0, 1, 2 } }, { 2, new List<int>() { 0, 3, 4 } }, { 3, new List<int>() { 0, 1, 5 } }
        };

        //宝石槽位
        [StaticField]
        public static Dictionary<int, string> GemHoleName = new()
        {
            { 101, "黄色插槽" },
            { 102, "紫色插槽" },
            { 103, "蓝色插槽" },
            { 104, "绿色插槽" },
            { 105, "橙色插槽" },
        };
        
        //宝石槽位
        [StaticField]
        public static Dictionary<int, string> GemHoleBack = new()
        {
            { 101, "ItemQuality3_5" },
            { 102, "ItemQuality3_4" },
            { 103, "ItemQuality3_3" },
            { 104, "ItemQuality3_2" },
            { 105, "ItemQuality3_5" },
        };


        //Administrator:
        //当道具类型为1（消耗品）时该字段的意义
        //1 获得金币值
        //2 获得经验值
        //101 触发某个技能ID
        //103 宠物蛋
        //104 随机道具盒子
        //105 宠物洗炼相关道具
        //106 道具盒子,打开获取指定东西
        //当道具类型为3（装备）时该字段的意义
        //1 武器
        //2 衣服
        //3 护符
        //4 戒指
        //5 饰品
        //6 鞋子
        //7 裤子
        //8 腰带
        //9 手镯
        //10 头盔
        //11 项链
        /// <summary>
        /// ItemSubType To Name
        /// </summary>
        [StaticField]
        public static Dictionary<int, string> ItemSubType3Name = new()
        {
            { 0, "全部" },
            { 1, "武器" },
            { 2, "衣服" },
            { 3, "护符" },
            { 4, "戒指" },
            { 5, "饰品" },
            { 6, "鞋子" },
            { 7, "裤子" },
            { 8, "腰带" },
            { 9, "手镯" },
            { 10, "头盔" },
            { 11, "项链" },
            { 1100, "生肖" },
        };

        [StaticField]
        public static Dictionary<int, string> ItemTypeName = new()
        {
            { ItemTypeEnum.Consume, "消耗品" },
            { ItemTypeEnum.Material, "材料" },
            { ItemTypeEnum.Equipment, "装备" },
            { ItemTypeEnum.Gemstone, "宝石" },
            { ItemTypeEnum.PetHeXin, "宠物之核" },
        };

        [StaticField]
        public static Dictionary<int, NumericAttribute> AttributeToName = new()
        {
            { NumericType.Now_MaxHp, new NumericAttribute() { Name = "生命", Icon = "ProType_2" } },
            { NumericType.Now_MaxAct, new NumericAttribute() { Name = "攻击", Icon = "ProType_1" } },
            { NumericType.Now_Mage, new NumericAttribute() { Name = "魔法", Icon = "ProType_6" } },
            { NumericType.Now_MaxDef, new NumericAttribute() { Name = "物防", Icon = "ProType_4" } },
            { NumericType.Now_MaxAdf, new NumericAttribute() { Name = "魔防", Icon = "ProType_5" } },
            { NumericType.Now_Cri, new NumericAttribute() { Name = "暴击概率", Icon = string.Empty } },
            { NumericType.Now_Res, new NumericAttribute() { Name = "抗暴概率", Icon = string.Empty } },
            { NumericType.Now_Hit, new NumericAttribute() { Name = "命中概率", Icon = string.Empty } },
            { NumericType.Now_Dodge, new NumericAttribute() { Name = "闪避概率", Icon = string.Empty } },
            { NumericType.Base_Luck_Base, new NumericAttribute() { Name = "幸运加成", Icon = string.Empty } },
            { NumericType.Now_MinAct, new NumericAttribute() { Name = "最小攻击", Icon = string.Empty } },
            { NumericType.Now_MinDef, new NumericAttribute() { Name = "最小物防", Icon = string.Empty } },
            { NumericType.Now_MinAdf, new NumericAttribute() { Name = "最小魔防", Icon = string.Empty } },
            { NumericType.Now_Power, new NumericAttribute() { Name = "力量", Icon = "ProType_15" } },
            { NumericType.Now_Agility, new NumericAttribute() { Name = "敏捷", Icon = "ProType_14" } },
            { NumericType.Now_Intellect, new NumericAttribute() { Name = "智力", Icon = "ProType_11" } },
            { NumericType.Now_Stamina, new NumericAttribute() { Name = "耐力", Icon = "ProType_13" } },
            { NumericType.Now_Constitution, new NumericAttribute() { Name = "体质", Icon = "ProType_12" } },
            { NumericType.Now_DamgeAddPro, new NumericAttribute() { Name = "伤害加成", Icon = string.Empty } },
            { NumericType.Now_DamgeSubPro, new NumericAttribute() { Name = "伤害减免", Icon = string.Empty } },
            { NumericType.Now_Luck, new NumericAttribute() { Name = "幸运值", Icon = string.Empty } },
            { NumericType.Now_Speed, new NumericAttribute() { Name = "移动速度", Icon = string.Empty } },
            { NumericType.Now_CriLv, new NumericAttribute() { Name = "暴击等级", Icon = string.Empty } },
            { NumericType.Now_ResLv, new NumericAttribute() { Name = "韧性等级", Icon = string.Empty } },
            { NumericType.Now_HitLv, new NumericAttribute() { Name = "命中等级", Icon = string.Empty } },
            { NumericType.Now_DodgeLv, new NumericAttribute() { Name = "闪避等级", Icon = string.Empty } },
            { NumericType.Now_ActDamgeAddPro, new NumericAttribute() { Name = "物理伤害加成", Icon = string.Empty } },
            { NumericType.Now_MageDamgeAddPro, new NumericAttribute() { Name = "魔法伤害加成", Icon = string.Empty } },
            { NumericType.Now_ActDamgeSubPro, new NumericAttribute() { Name = "物理伤害减免", Icon = string.Empty } },
            { NumericType.Now_MageDamgeSubPro, new NumericAttribute() { Name = "魔法伤害减免", Icon = string.Empty } },
            { NumericType.Now_ZhongJiPro, new NumericAttribute() { Name = "重击概率", Icon = string.Empty } },
            { NumericType.Now_ZhongJi, new NumericAttribute() { Name = "重击附加", Icon = string.Empty } },
            { NumericType.Now_HuShiActPro, new NumericAttribute() { Name = "攻击穿透", Icon = string.Empty } },
            { NumericType.Now_HuShiMagePro, new NumericAttribute() { Name = "魔法穿透", Icon = string.Empty } },
            { NumericType.Now_HuShiDef, new NumericAttribute() { Name = "忽视目标防御", Icon = string.Empty } },
            { NumericType.Now_HuShiAdf, new NumericAttribute() { Name = "忽视目标魔御", Icon = string.Empty } },
            { NumericType.Now_XiXuePro, new NumericAttribute() { Name = "吸血概率", Icon = string.Empty } },
            { NumericType.Now_SkillCDTimeCostPro, new NumericAttribute() { Name = "技能冷却缩减", Icon = string.Empty } },
            { NumericType.Now_GeDang, new NumericAttribute() { Name = "格挡值", Icon = string.Empty } },
            { NumericType.Now_ZhenShi, new NumericAttribute() { Name = "真实伤害", Icon = string.Empty } },
            { NumericType.Now_HuiXue, new NumericAttribute() { Name = "回血值", Icon = string.Empty } },
            { NumericType.Now_ZhongJiLv, new NumericAttribute() { Name = "重击等级", Icon = string.Empty } },
            { NumericType.Now_ExpAdd, new NumericAttribute() { Name = "经验收益", Icon = string.Empty } },
            { NumericType.Now_GoldAdd, new NumericAttribute() { Name = "金币收益", Icon = string.Empty } },
            { NumericType.Now_MonsterDis, new NumericAttribute() { Name = "怪物发现目标距离", Icon = string.Empty } },
            { NumericType.Now_JumpDisAdd, new NumericAttribute() { Name = "冲锋距离加成", Icon = string.Empty } },
            { NumericType.Now_ActQiangDuAdd, new NumericAttribute() { Name = "攻击强度", Icon = string.Empty } },
            { NumericType.Now_MageQiangDuAdd, new NumericAttribute() { Name = "法术强度", Icon = string.Empty } },
            { NumericType.Now_ActBossPro, new NumericAttribute() { Name = "领主攻击加成", Icon = string.Empty } },
            { NumericType.Now_MageBossPro, new NumericAttribute() { Name = "领主技能加成", Icon = string.Empty } },
            { NumericType.Now_ActBossSubPro, new NumericAttribute() { Name = "领主攻击免伤", Icon = string.Empty } },
            { NumericType.Now_MageBossSubPro, new NumericAttribute() { Name = "领主技能免伤", Icon = string.Empty } },
            { NumericType.Now_MiaoSha_Pro, new NumericAttribute() { Name = "致命一击", Icon = string.Empty } },
            { NumericType.Now_FuHuoPro, new NumericAttribute() { Name = "重生几率", Icon = string.Empty } },
            { NumericType.Now_WuShiFangYuPro, new NumericAttribute() { Name = "无视防御", Icon = string.Empty } },
            { NumericType.Now_SkillNoCDPro, new NumericAttribute() { Name = "技能零冷却", Icon = string.Empty } },
            { NumericType.Now_SkillMoreDamgePro, new NumericAttribute() { Name = "技能额外伤害", Icon = string.Empty } },
            { NumericType.Now_SkillDodgePro, new NumericAttribute() { Name = "技能闪避", Icon = string.Empty } },
            { NumericType.Now_ShenNongPro, new NumericAttribute() { Name = "神农", Icon = string.Empty } },
            { NumericType.Now_SecHpAddPro, new NumericAttribute() { Name = "每秒恢复", Icon = string.Empty } },
            { NumericType.Now_DiKangPro, new NumericAttribute() { Name = "抵抗减益状态", Icon = string.Empty } },
            { NumericType.Now_MageDodgePro, new NumericAttribute() { Name = "魔法闪避", Icon = string.Empty } },
            { NumericType.Now_ZhuanZhuPro, new NumericAttribute() { Name = "专注概率", Icon = string.Empty } },
            { NumericType.Now_ActDodgePro, new NumericAttribute() { Name = "物理闪避", Icon = string.Empty } },
            { NumericType.Now_ActSpeedPro, new NumericAttribute() { Name = "攻击速度", Icon = string.Empty } },
            { NumericType.Now_ActBossAddDamge, new NumericAttribute() { Name = "对怪伤害", Icon = string.Empty } },
            { NumericType.Now_PlayerActDamgeSubPro, new NumericAttribute() { Name = "玩家普攻减伤", Icon = string.Empty } },
            { NumericType.Now_PlayerSkillDamgeSubPro, new NumericAttribute() { Name = "玩家技能减伤", Icon = string.Empty } },
            { NumericType.Now_GoldAdd_Pro, new NumericAttribute() { Name = "经验收益", Icon = string.Empty } },
            { NumericType.Now_ExpAdd_Pro, new NumericAttribute() { Name = "金币收益", Icon = string.Empty } },
            { NumericType.Now_DropAdd_Pro, new NumericAttribute() { Name = "游戏爆率", Icon = string.Empty } },
            { NumericType.Now_MonsterActIncreaseDamgeSubPro, new NumericAttribute() { Name = "怪攻增伤", Icon = string.Empty } },
            { NumericType.Now_MonsterMageIncreaseDamgeSubPro, new NumericAttribute() { Name = "怪技增伤", Icon = string.Empty } },
            { NumericType.Now_MonsterActReduceDamgeSubPro, new NumericAttribute() { Name = "怪攻减伤", Icon = string.Empty } },
            { NumericType.Now_MonsterMageReduceDamgeSubPro, new NumericAttribute() { Name = "怪技减伤", Icon = string.Empty } },
            
            { NumericType.Now_PetAllMageAct, new NumericAttribute(){Name = "所有宠物魔法攻击",Icon = string.Empty}},//提升x点
            { NumericType.Now_PetAllAct, new NumericAttribute(){Name = "所有宠物攻击",Icon = string.Empty}},
            { NumericType.Now_PetAllDef, new NumericAttribute(){Name = "所有宠物防御",Icon = string.Empty}},
            { NumericType.Now_PetAllAdf, new NumericAttribute(){Name = "所有宠物魔防",Icon = string.Empty}},
            { NumericType.Now_PetAllHp, new NumericAttribute(){Name = "所有宠物生命",Icon = string.Empty}},
            { NumericType.Now_PetAllMageActPro, new NumericAttribute(){Name = "所有宠物魔法攻击",Icon = string.Empty}}, //提升x%
            { NumericType.Now_PetAllActPro, new NumericAttribute(){Name = "所有宠物攻击",Icon = string.Empty}},
            { NumericType.Now_PetAllDefPro, new NumericAttribute(){Name = "所有宠物防御",Icon = string.Empty}},
            { NumericType.Now_PetAllAdfPro, new NumericAttribute(){Name = "所有宠物魔防",Icon = string.Empty}},
            { NumericType.Now_PetAllHpPro, new NumericAttribute(){Name = "所有宠物生命",Icon = string.Empty}},
        };

        public struct EquipWeiZhiInfo
        {
            public string Name;
            public string Icon;
        }

        /// <summary>
        /// 装备位置配置
        /// </summary>
        [StaticField]
        public static Dictionary<int, EquipWeiZhiInfo> EquipWeiZhiToName = new Dictionary<int, EquipWeiZhiInfo>()
        {
            { 1, new EquipWeiZhiInfo() { Icon = "Img_24", Name = "武器" } },
            { 2, new EquipWeiZhiInfo() { Icon = "Img_28", Name = "衣服" } },
            { 3, new EquipWeiZhiInfo() { Icon = "Img_29", Name = "护符" } },
            { 4, new EquipWeiZhiInfo() { Icon = "Img_19", Name = "戒指" } },
            { 5, new EquipWeiZhiInfo() { Icon = "Img_21", Name = "饰品" } },
            { 6, new EquipWeiZhiInfo() { Icon = "Img_26", Name = "鞋子" } },
            { 7, new EquipWeiZhiInfo() { Icon = "Img_20", Name = "裤子" } },
            { 8, new EquipWeiZhiInfo() { Icon = "Img_27", Name = "腰带" } },
            { 9, new EquipWeiZhiInfo() { Icon = "Img_22", Name = "手镯" } },
            { 10, new EquipWeiZhiInfo() { Icon = "Img_23", Name = "头盔" } },
            { 11, new EquipWeiZhiInfo() { Icon = "Img_25", Name = "项链" } },
        };
    }
}