using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RankReward))]
    [FriendOfAttribute(typeof (ES_RankReward))]
    public static partial class ES_RankRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RankReward self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_RankReward self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(1);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        private static void OnRankShowItemsRefresh(this ES_RankReward self, Transform transform, int index)
        {
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[index].BindTrans(transform);
            scrollItemRankRewardItem.OnUpdateUI(self.ShowRankRewardConfigs[index]);
        }
    }
}
