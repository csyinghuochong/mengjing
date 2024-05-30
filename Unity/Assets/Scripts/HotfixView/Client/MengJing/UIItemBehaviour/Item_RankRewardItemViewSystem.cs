using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_RankRewardItem))]
    public static partial class Scroll_Item_RankRewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RankRewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RankRewardItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_RankRewardItem self, RankRewardConfig rankRewardConfig)
        {
            self.E_Text_RankText.text = $"{rankRewardConfig.NeedPoint[0]}-{rankRewardConfig.NeedPoint[1]}名";
            self.ES_RewardList.Refresh(rankRewardConfig.RewardItems, 0.9f);

            UICommonHelper.HideChildren();
            if (rankRewardConfig.NeedPoint[0] == 1)
            {
                self.Rank_1.SetActive(true);
                self.Text_Rank.SetActive(false);
            }

            if (rankRewardConfig.NeedPoint[0] == 2)
            {
                self.Rank_2.SetActive(true);
                self.Text_Rank.SetActive(false);
            }

            if (rankRewardConfig.NeedPoint[0] == 3)
            {
                self.Rank_3.SetActive(true);
                self.Text_Rank.SetActive(false);
            }
        }
    }
}