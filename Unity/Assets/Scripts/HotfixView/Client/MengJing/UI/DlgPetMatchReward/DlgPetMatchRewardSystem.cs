using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankRewardItem))]
    [FriendOf(typeof(DlgPetMatchReward))]
    public static class DlgPetMatchRewardSystem
    {
        public static void RegisterUIEvent(this DlgPetMatchReward self)
        {
            self.View.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);
            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMatchReward); });

            self.OnInitUI();
            self.ShowLastRewardPlayer().Coroutine();
        }

        public static void ShowWindow(this DlgPetMatchReward self, Entity contextData = null)
        {
        }

        private static async ETTask ShowLastRewardPlayer(this DlgPetMatchReward self)
        {
            R2C_RankLastRewardResponse rewardResponse = await PetNetHelper.RequestLastReward(self.Root(), 8);
            if (rewardResponse == null)
            {
                return;
            }

            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[0];
            scrollItemRankRewardItem.ShowLastRewardPlayer(rewardResponse.LastRewardList.FirstOrDefault());
        }

        public static void OnInitUI(this DlgPetMatchReward self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(8);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.View.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        private static void OnRankShowItemsRefresh(this DlgPetMatchReward self, Transform transform, int index)
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