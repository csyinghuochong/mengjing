using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgSeasonTowerReward))]
    public static class DlgSeasonTowerRewardSystem
    {
        public static void RegisterUIEvent(this DlgSeasonTowerReward self)
        {
            self.View.E_CloseButtonButton.AddListener(self.OnCloseButton);

            self.View.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankRewardItemsRefresh);
        }

        public static void ShowWindow(this DlgSeasonTowerReward self, Entity contextData = null)
        {
        }

        private static void OnRankRewardItemsRefresh(this DlgSeasonTowerReward self, Transform transform, int index)
        {
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[index].BindTrans(transform);
            scrollItemRankRewardItem.OnUpdateUI(self.ShowRankRewardConfigs[index]);
        }

        public static void OnCloseButton(this DlgSeasonTowerReward self)
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