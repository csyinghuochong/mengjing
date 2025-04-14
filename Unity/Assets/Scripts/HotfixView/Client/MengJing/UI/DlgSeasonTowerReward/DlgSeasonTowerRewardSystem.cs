using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankRewardItem))]
    [FriendOf(typeof (DlgSeasonTowerReward))]
    public static class DlgSeasonTowerRewardSystem
    {
        public static void RegisterUIEvent(this DlgSeasonTowerReward self)
        {
            self.View.E_CloseButtonButton.AddListener(self.OnCloseButtonButton);

            self.View.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankRewardItemsRefresh);
        }

        public static void ShowWindow(this DlgSeasonTowerReward self, Entity contextData = null)
        {
        }

        private static void OnRankRewardItemsRefresh(this DlgSeasonTowerReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_RankRewardItem item in self.ScrollItemRankRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[index].BindTrans(transform);
            scrollItemRankRewardItem.OnUpdateUI(self.ShowRankRewardConfigs[index]);
        }

        public static void OnCloseButtonButton(this DlgSeasonTowerReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonTowerReward);
        }

        public static void OnInitUI(this DlgSeasonTowerReward self, int rankType)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(rankType);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.View.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }
    }
}
