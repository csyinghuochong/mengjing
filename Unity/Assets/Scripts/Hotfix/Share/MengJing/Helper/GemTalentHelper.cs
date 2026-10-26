using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 宝石天赋的纯计算逻辑：宝石点数由身上已镶嵌的宝石等级实时换算，不单独存档
    /// </summary>
    public static class GemTalentHelper
    {
        /// <summary>
        /// 单颗宝石提供的宝石点数，等于宝石等级（ItemConfig.UseLv）
        /// </summary>
        public static int GetGemPoint(int gemItemId)
        {
            if (gemItemId <= 0)
            {
                return 0;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.GetOrDefault(gemItemId);
            if (itemConfig == null)
            {
                return 0;
            }

            return itemConfig.UseLv;
        }

        /// <summary>
        /// 总宝石点数：身上装备上已镶嵌的所有宝石等级之和
        /// </summary>
        public static int GetTotalPoint(List<ItemInfo> equipList)
        {
            if (equipList == null)
            {
                return 0;
            }

            int totalPoint = 0;
            for (int i = 0; i < equipList.Count; i++)
            {
                ItemInfo equipInfo = equipList[i];
                if (equipInfo == null || string.IsNullOrEmpty(equipInfo.GemIDNew))
                {
                    continue;
                }

                List<int> gemIds = ItemHelper.GetGemIdList(equipInfo);
                for (int j = 0; j < gemIds.Count; j++)
                {
                    totalPoint += GetGemPoint(gemIds[j]);
                }
            }

            return totalPoint;
        }

        /// <summary>
        /// 已消耗的宝石点数：已激活节点的激活消耗之和
        /// </summary>
        public static int GetUsedPoint(List<int> activeTalentIds)
        {
            if (activeTalentIds == null)
            {
                return 0;
            }

            int usedPoint = 0;
            for (int i = 0; i < activeTalentIds.Count; i++)
            {
                GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(activeTalentIds[i]);
                if (gemTalentConfig == null)
                {
                    continue;
                }

                usedPoint += gemTalentConfig.CostPoint;
            }

            return usedPoint;
        }

        /// <summary>
        /// 可用宝石点数。换装导致总点数下降时可能为负数，负数只表示不能再激活新节点
        /// </summary>
        public static int GetLeftPoint(List<int> activeTalentIds, int totalPoint)
        {
            return totalPoint - GetUsedPoint(activeTalentIds);
        }

        /// <summary>
        /// 区域是否已解锁：累计总点数达到区域要求后自动解锁
        /// </summary>
        public static bool IsAreaUnlocked(int area, int totalPoint)
        {
            GemTalentAreaConfig areaConfig = GemTalentAreaConfigCategory.Instance.GetOrDefault(area);
            if (areaConfig == null)
            {
                return false;
            }

            return totalPoint >= areaConfig.NeedTotalPoint;
        }
    }
}
