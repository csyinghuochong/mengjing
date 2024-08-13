using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RankPetReward))]
    [FriendOfAttribute(typeof (ES_RankPetReward))]
    public static partial class ES_RankPetRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankPetReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RankPetReward self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_RankPetReward self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(2);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        private static void OnRankShowItemsRefresh(this ES_RankPetReward self, Transform transform, int index)
        {
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[index].BindTrans(transform);
            scrollItemRankRewardItem.OnUpdateUI(self.ShowRankRewardConfigs[index]);
        }
    }
}
