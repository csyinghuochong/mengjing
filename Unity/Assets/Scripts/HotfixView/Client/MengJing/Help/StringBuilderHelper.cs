using System.Collections.Generic;

namespace ET.Client
{
    public static class StringBuilderHelper
    {
        public static string GetFps()
        {
            return string.Empty;
        }

        public static string GetEffectPathByConfig(EffectConfig effectConfig)
        {
            string effectFileName = "";
            switch (effectConfig.EffectType)
            {
                //技能特效
                case 1:
                    effectFileName = "SkillEffect/";
                    break;
                //受击特效
                case 2:
                    effectFileName = "SkillHitEffect/";
                    break;
                //场景特效
                case 3:
                    effectFileName = "ScenceEffect/";
                    break;
                 case 4:
                    effectFileName = "UIEffect/";
                    break;
            }

            string effectNamePath = effectFileName + effectConfig.EffectName;
            return GetEffetPath(effectNamePath);
        }

        public static string GetMonsterUnitPath(int modelID)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append(StringBuilderData.MonsterUnitPath);
            StringBuilderData.stringBuilder.Append(modelID);
            StringBuilderData.stringBuilder.Append(StringBuilderData.UnitPrefab);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetPing(long ping)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append("延迟: ");
            StringBuilderData.stringBuilder.Append(ping);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetMessageCnt(long cnt)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append("数量: ");
            StringBuilderData.stringBuilder.Append(cnt);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetExpTip(long exp)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append("获得");
            StringBuilderData.stringBuilder.Append(exp);
            StringBuilderData.stringBuilder.Append("经验");
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetFashionDefault(int occ, string asset)
        {
            string stringpath = StringBuilderData.UnitFashionPath_1;
            if (occ == 2)
            {
                stringpath = StringBuilderData.UnitFashionPath_2;
            }
            else if (occ == 3)
            {
                stringpath = StringBuilderData.UnitFashionPath_3;
            }

            StringBuilderData.stringBuilder.Clear();

            StringBuilderData.stringBuilder.Append(stringpath);
            StringBuilderData.stringBuilder.Append(asset);
            StringBuilderData.stringBuilder.Append(StringBuilderData.UnitPrefab);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetChatText(string playerName, string showValue)
        {
            StringBuilderData.stringBuilder.Clear();

            StringBuilderData.stringBuilder.Append(playerName);
            StringBuilderData.stringBuilder.Append(":");
            StringBuilderData.stringBuilder.Append(showValue);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetFashionPath(string asset)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append(StringBuilderData.UnitFashionPath);
            StringBuilderData.stringBuilder.Append(asset);
            StringBuilderData.stringBuilder.Append(StringBuilderData.UnitPrefab);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetEffetPath(string asset)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append(StringBuilderData.UnitEffectPath);
            StringBuilderData.stringBuilder.Append(asset);
            StringBuilderData.stringBuilder.Append(StringBuilderData.UnitPrefab);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetFallText(string addStr, long targetValue)
        {
            StringBuilderData.stringBuilder.Clear();
            StringBuilderData.stringBuilder.Append(addStr);
            StringBuilderData.stringBuilder.Append(targetValue);
            return StringBuilderData.stringBuilder.ToString();
        }

        public static string GetGemHole(List<int> gemholeid)
        {
            StringBuilderData.stringBuilder.Clear();
            for (int i = 0; i < gemholeid.Count; i++)
            {
                StringBuilderData.stringBuilder.Append(gemholeid[i]);
                if (i < gemholeid.Count - 1)
                {
                    StringBuilderData.stringBuilder.Append('_');
                }
            }

            return StringBuilderData.stringBuilder.ToString();
        }
    }
}

