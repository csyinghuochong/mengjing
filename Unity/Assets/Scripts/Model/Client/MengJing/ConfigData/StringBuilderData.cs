using System.Collections.Generic;
using System.Text;

namespace ET.Client
{
    public static class StringBuilderData
    {
        [StaticField]
        public static string ToonBasic = "Toon/Basic";

        [StaticField]
        public static string Ill_HighLight = "Custom/Ill_HighLight";

        [StaticField]
        public static string SimpleAlpha = "Custom/SimpleAlpha";

        [StaticField]
        public static string Outline = "Custom/Outline";

        [StaticField]
        public static string RoleBoneSet = "RoleBoneSet";

        [StaticField]
        public static string Skill_Halo_2 = "Skill_Halo_2";

        [StaticField]
        public static string Skill_ComTargetMove_RangDamge_2 = "Skill_ComTargetMove_RangDamge_2";

        [StaticField]
        public static string RimLight = "Custom/RimLight";

        [StaticField]
        public static List<string> NoEffectSkills = new List<string>()
        {
            "Skill_ComTargetMove_RangDamge_1",
            "Skill_ComTargetMove_RangDamge_2",
            "Skill_ChainLightning",
            "Skill_ChainLightning_2",
            "Skill_Follow_Damge_1",
            "Skill_Range_Bomb_1",
            "Skill_Boomerang",
        };


        [StaticField]
        public static List<string> AiCheckList = new List<string>() { "AI_XunLuo", "AI_ZhuiJi", "AI_LocalDungeon" };

        [StaticField]
        public static string MainCity = "101";

        [StaticField]
        public static string GuangHuan = "GuangHuan";

        [StaticField]
        public static string UI_pro_4_2 = "UI_pro_4_2";

        [StaticField]
        public static string UI_pro_3_2 = "UI_pro_3_2";

        [StaticField]
        public static string UI_pro_3_4 = "UI_pro_3_4";

        [StaticField]
        public static string 族长 = "族长";

        [StaticField]
        public static string 成员 = "成员";

        [StaticField]
        public static string ai_1 = "AI_XunLuo";

        [StaticField]
        public static string ai_2 = "AI_ZhuiJi";

        [StaticField]
        public static string ai_3 = "AI_LocalDungeon";

        [StaticField]
        public static string 内存占用 = "内存占用:";

        [StaticField]
        public static string UnitFashionPath_1 = "Assets/Bundles/Unit/Parts/1/";

        [StaticField]
        public static string UnitFashionPath_2 = "Assets/Bundles/Unit/Parts/2/";

        [StaticField]
        public static string UnitFashionPath_3 = "Assets/Bundles/Unit/Parts/3/";

        [StaticField]
        public static string UnitFashionPath = "Assets/Bundles/Unit/Parts/Fashion/";

        [StaticField]
        public static string UnitPrefab = ".prefab";

        [StaticField]
        public static string UIBattleFly = "Assets/Bundles/UI/Blood/UIBattleFly.prefab";
        
        [StaticField]
        public static string UIBattleFly1 = "Assets/Bundles/UI/Blood/UIBattleFly1.prefab";

        [StaticField]
        public static string UnitEffectPath = "Assets/Bundles/Effect/";

        [StaticField]
        public static string UIDropUIPath = "Assets/Bundles/UI/Blood/UIDropItem.prefab";

        [StaticField]
        public static string MonsterUnitPath = "Assets/Bundles/Unit/Monster/";

        [StaticField]
        public static StringBuilder stringBuilder = new StringBuilder();
    }
}

