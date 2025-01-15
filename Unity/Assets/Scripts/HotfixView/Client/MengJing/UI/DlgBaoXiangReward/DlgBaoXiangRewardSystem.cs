using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgBaoXiangReward))]
    public static class DlgBaoXiangRewardSystem
    {
        public static void RegisterUIEvent(this DlgBaoXiangReward self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
        }

        public static void ShowWindow(this DlgBaoXiangReward self, Entity contextData = null)
        {
        }

        public static void OnImageButtonButton(this DlgBaoXiangReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_BaoXiangReward);
        }

        public static void OnUpdateUI(this DlgBaoXiangReward self, List<RewardItem> rewardItems)
        {
            self.View.ES_RewardList.Refresh(rewardItems, showName: true);
        }

        public static void OnUpdateUI(this DlgBaoXiangReward self, string rewardItems)
        {
            self.View.ES_RewardList.Refresh(rewardItems, showName: true);
        }
    }
}