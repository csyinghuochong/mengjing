using System.Collections.Generic;

namespace ET
{
    public static class LongYinHelper
    {
        /// <summary>
        /// 双龙觉醒需要的已完全解锁龙印类型数量
        /// </summary>
        public const int DoubleLongNeedTypeCount = 2;

        /// <summary>
        /// 三龙觉醒需要的已完全解锁龙印类型数量
        /// </summary>
        public const int ThreeLongNeedTypeCount = 3;

        /// <summary>
        /// 五龙觉醒需要的已完全解锁龙印类型数量
        /// </summary>
        public const int FiveLongNeedTypeCount = 5;

        /// <summary>
        /// 龙印节点在预制体中的编号(如1001)转配置id
        /// </summary>
        public static int GetLongYinId(int occ, int index)
        {
            return occ * 10000 + index;
        }

        /// <summary>
        /// 获取龙印等级，未激活返回0
        /// </summary>
        public static int GetLevel(List<KeyValuePairInt> longYinList, int longYinId)
        {
            for (int i = 0; i < longYinList.Count; i++)
            {
                if (longYinList[i].KeyId == longYinId)
                {
                    return (int)longYinList[i].Value;
                }
            }

            return 0;
        }

        /// <summary>
        /// 玩家等级换算出的龙印点总数：1级没有龙印点，之后每升1级增加1点
        /// </summary>
        public static int GetPointMax(int playerLv)
        {
            return playerLv > 1 ? playerLv - 1 : 0;
        }

        /// <summary>
        /// 已消耗的龙印点：龙印等级之和(激活1点，之后每升1级再消耗1点)，觉醒龙印自动解锁不占点数
        /// </summary>
        public static int GetPointUsed(List<KeyValuePairInt> longYinList)
        {
            int usedPoint = 0;
            for (int i = 0; i < longYinList.Count; i++)
            {
                KeyValuePairInt longYin = longYinList[i];
                LongYinConfig longYinConfig = LongYinConfigCategory.Instance.GetOrDefault(longYin.KeyId);
                if (longYinConfig != null && IsAwakenType(longYinConfig.Type))
                {
                    continue;
                }

                usedPoint += (int)longYin.Value;
            }

            return usedPoint;
        }

        /// <summary>
        /// 剩余龙印点，负数说明数据异常，显示时按0处理
        /// </summary>
        public static int GetPointLeft(List<KeyValuePairInt> longYinList, int playerLv)
        {
            return GetPointMax(playerLv) - GetPointUsed(longYinList);
        }

        /// <summary>
        /// 龙印点是否够本次激活/升级
        /// </summary>
        public static bool CheckPointEnough(List<KeyValuePairInt> longYinList, int playerLv)
        {
            return GetPointLeft(longYinList, playerLv) >= 1;
        }

        /// <summary>
        /// 是否为觉醒龙印(双龙/三龙/五龙)，觉醒龙印由其他龙印满级后自动解锁，不能手动激活也不消耗龙印点
        /// </summary>
        public static bool IsAwakenType(LongYinType type)
        {
            return type == LongYinType.DoubleLong || type == LongYinType.ThreeLong || type == LongYinType.FiveLong;
        }

        /// <summary>
        /// 该觉醒龙印需要的已完全解锁龙印类型数量，非觉醒返回0
        /// </summary>
        public static int GetAwakenNeedTypeCount(LongYinType type)
        {
            switch (type)
            {
                case LongYinType.DoubleLong:
                    return DoubleLongNeedTypeCount;
                case LongYinType.ThreeLong:
                    return ThreeLongNeedTypeCount;
                case LongYinType.FiveLong:
                    return FiveLongNeedTypeCount;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取指定职业的觉醒龙印配置(双龙/三龙/五龙)，没有配置返回null
        /// </summary>
        public static LongYinConfig GetAwakenConfig(int occ, LongYinType type)
        {
            if (!IsAwakenType(type))
            {
                return null;
            }

            List<LongYinConfig> configList = LongYinConfigCategory.Instance.DataList;
            for (int i = 0; i < configList.Count; i++)
            {
                LongYinConfig longYinConfig = configList[i];
                if (longYinConfig.Occ != occ || longYinConfig.Type != type)
                {
                    continue;
                }

                return longYinConfig;
            }

            return null;
        }

        /// <summary>
        /// 按已完全解锁的龙印类型数量判断该觉醒是否满足解锁条件
        /// </summary>
        public static bool IsAwakenUnlocked(LongYinType type, int completeTypeCount)
        {
            int needTypeCount = GetAwakenNeedTypeCount(type);
            return needTypeCount > 0 && completeTypeCount >= needTypeCount;
        }

        /// <summary>
        /// 指定类型(LongYinType_1~Type_5)的龙印是否已全部激活且升到满级
        /// </summary>
        public static bool IsTypeComplete(List<KeyValuePairInt> longYinList, int occ, int type)
        {
            bool haveConfig = false;
            List<LongYinConfig> configList = LongYinConfigCategory.Instance.DataList;
            for (int i = 0; i < configList.Count; i++)
            {
                LongYinConfig longYinConfig = configList[i];
                if (longYinConfig.Occ != occ || (int)longYinConfig.Type != type || longYinConfig.Lv <= 0)
                {
                    continue;
                }

                haveConfig = true;
                if (GetLevel(longYinList, longYinConfig.Id) < longYinConfig.Lv)
                {
                    return false;
                }
            }

            //该类型没有任何配置，视为未完全解锁
            return haveConfig;
        }

        /// <summary>
        /// 已完全解锁(全部激活且满级)的龙印类型数量，只统计LongYinType_1~Type_5
        /// </summary>
        public static int GetCompleteTypeCount(List<KeyValuePairInt> longYinList, int occ)
        {
            int completeTypeCount = 0;
            for (int type = (int)LongYinType.Type_1; type <= (int)LongYinType.Type_5; type++)
            {
                if (IsTypeComplete(longYinList, occ, type))
                {
                    completeTypeCount++;
                }
            }

            return completeTypeCount;
        }
    }
}
