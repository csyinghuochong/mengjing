using System.Collections.Generic;

namespace ET
{
    public static class LongYinHelper
    {
        /// <summary>
        /// 龙印节点在预制体中的编号(如1001)转配置id
        /// </summary>
        public static int GetLongYinId(int occ, int index)
        {
            return occ * 10000 + index;
        }

        /// <summary>
        /// 玩家等级换算出的龙印点总数：1级没有龙印点，之后每升1级增加1点
        /// </summary>
        public static int GetPointMax(int playerLv)
        {
            return playerLv > 1 ? playerLv - 1 : 0;
        }

        /// <summary>
        /// 已消耗的龙印点：龙印等级之和(激活1点，之后每升1级再消耗1点)
        /// </summary>
        public static int GetPointUsed(List<KeyValuePairInt> longYinList)
        {
            int usedPoint = 0;
            for (int i = 0; i < longYinList.Count; i++)
            {
                usedPoint += (int)longYinList[i].Value;
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
    }
}
