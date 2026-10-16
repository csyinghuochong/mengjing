using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static  class RankHelper
    {

        public static bool HaveReward(int rankType, int day)
        {
            string globalValueConfig = null;
            if (rankType == 1)
            {
                globalValueConfig = GlobalValueConfigCategory.Instance.Value_66;
            }
            if (rankType == 2)
            {
                globalValueConfig = GlobalValueConfigCategory.Instance.Value_67;
            }
            if (day == 0)
            {
                day = 7;
            }
            return globalValueConfig.Contains(day.ToString());
        }

        public static List<RankRewardConfig> GetTypeRankRewards( int rankType)
        {
            List<RankRewardConfig> rankRewardItems =new List<RankRewardConfig>();
            List<RankRewardConfig> rankRewardConfigs = RankRewardConfigCategory.Instance.GetAll().Values.ToList();

            for (int i = 0; i < rankRewardConfigs.Count; i++)
            {
                if (rankRewardConfigs[i].Type != rankType)
                {
                    continue;
                }
                rankRewardItems.Add(rankRewardConfigs[i]);
            }
            return rankRewardItems;
        }

        public static RankRewardConfig GetRankReward(int rank, int rankType)
        {
            RankRewardConfig rankRewardItem = null;
            List<RankRewardConfig> rankRewardConfigs = RankRewardConfigCategory.Instance.GetAll().Values.ToList();

            for (int i = 0; i < rankRewardConfigs.Count; i++)
            {
                if (rankRewardConfigs[i].Type != rankType)
                {
                    continue;
                }
                rankRewardItem = rankRewardConfigs[i];
                int[] randarea = rankRewardItem.NeedPoint;
                if (rankRewardItem.Type == rankType && rank >= randarea[0] && rank <= randarea[1])
                {
                    return rankRewardItem;
                }
            }
            return rankRewardItem;
        }

    }
}
