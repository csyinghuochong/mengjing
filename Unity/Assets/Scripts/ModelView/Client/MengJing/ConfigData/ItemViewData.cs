using System.Collections.Generic;


namespace ET.Client
{
    
    public struct NumericAttribute
    {
        public string Name;
        public bool Float;
        public string Icon;
    }

    
    public static  class ItemViewData
    {
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
            { NumericType.Now_MaxHp, new NumericAttribute() { Name = "生命", Icon = "PetPro_1" } },
            { NumericType.Now_MaxAct, new NumericAttribute() { Name = "攻击", Icon = "PetPro_2" } },
            { NumericType.Now_Mage, new NumericAttribute() { Name = "魔法", Icon = "PetPro_3" } },
            { NumericType.Now_MaxDef, new NumericAttribute() { Name = "物防", Icon = "PetPro_4" } },
            { NumericType.Now_MaxAdf, new NumericAttribute() { Name = "魔防", Icon = "PetPro_5" } },
            { NumericType.Now_Cri, new NumericAttribute() { Name = "暴击概率", Icon = string.Empty } },
            { NumericType.Now_Res, new NumericAttribute() { Name = "抗暴概率", Icon = string.Empty } },
            { NumericType.Now_Hit, new NumericAttribute() { Name = "命中概率", Icon = string.Empty } },
            { NumericType.Now_Dodge, new NumericAttribute() { Name = "闪避概率", Icon = string.Empty } },
            { NumericType.Base_Luck_Base, new NumericAttribute() { Name = "幸运加成", Icon = string.Empty } },
            { NumericType.Now_MinAct, new NumericAttribute() { Name = "最小攻击", Icon = string.Empty } },
            { NumericType.Now_MinDef, new NumericAttribute() { Name = "最小物防", Icon = string.Empty } },
            { NumericType.Now_MinAdf, new NumericAttribute() { Name = "最小魔防", Icon = string.Empty } },
            { NumericType.Now_Power, new NumericAttribute() { Name = "力量", Icon = string.Empty } },
            { NumericType.Now_Agility, new NumericAttribute() { Name = "敏捷", Icon = string.Empty } },
            { NumericType.Now_Intellect, new NumericAttribute() { Name = "智力", Icon = string.Empty } },
            { NumericType.Now_Stamina, new NumericAttribute() { Name = "耐力", Icon = string.Empty } },
            { NumericType.Now_Constitution, new NumericAttribute() { Name = "体质", Icon = string.Empty } },
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
            { NumericType.Now_PetAllMageAct, new NumericAttribute() { Name = "宠物全体魔法攻击", Icon = string.Empty } },
            { NumericType.Now_PetAllAct, new NumericAttribute() { Name = "宠物全体攻击", Icon = string.Empty } },
            { NumericType.Now_PetAllDef, new NumericAttribute() { Name = "宠物全体防御", Icon = string.Empty } },
            { NumericType.Now_PetAllAdf, new NumericAttribute() { Name = "宠物全体魔防", Icon = string.Empty } },
            { NumericType.Now_PetAllHp, new NumericAttribute() { Name = "宠物全体血量", Icon = string.Empty } },
        };

    }
    
}

