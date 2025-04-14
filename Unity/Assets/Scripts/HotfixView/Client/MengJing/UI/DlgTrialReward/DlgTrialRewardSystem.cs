using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankRewardItem))]
    [FriendOf(typeof (DlgTrialReward))]
    public static class DlgTrialRewardSystem
    {
        public static void RegisterUIEvent(this DlgTrialReward self)
        {
            self.View.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);
            self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);
        }

        public static void ShowWindow(this DlgTrialReward self, Entity contextData = null)
        {
        }

        public static void OnCloseButton(this DlgTrialReward self)
        {
            self.ClickOnClose?.Invoke();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TrialReward);
        }

        public static void OnInitUI(this DlgTrialReward self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(6);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.View.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        private static void OnRankShowItemsRefresh(this DlgTrialReward self, Transform transform, int index)
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
    }
}