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

            UICommonHelper.HideChildren(self.EG_RankShowSetRectTransform);
            if (rankRewardConfig.NeedPoint[0] == 1)
            {
                self.E_Rank_1Image.gameObject.SetActive(true);
                self.E_Text_RankText.gameObject.SetActive(false);
            }

            if (rankRewardConfig.NeedPoint[0] == 2)
            {
                self.E_Rank_2Image.gameObject.SetActive(true);
                self.E_Text_RankText.gameObject.SetActive(false);
            }

            if (rankRewardConfig.NeedPoint[0] == 3)
            {
                self.E_Rank_3Image.gameObject.SetActive(true);
                self.E_Text_RankText.gameObject.SetActive(false);
            }
        }
    }
}