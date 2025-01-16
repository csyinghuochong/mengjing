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
        public static string MainCity = "101";
        
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
        public static string UnitEffectPath = "Assets/Bundles/Effect/";

        [StaticField]
        public static string UIDropUIPath = "Assets/Bundles/UI/Blood/UIDropItem.prefab";

        [StaticField]
        public static string MonsterUnitPath = "Assets/Bundles/Unit/Monster/";

        [StaticField]
        public static StringBuilder stringBuilder = new StringBuilder();
    }
}

