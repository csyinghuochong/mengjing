using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (DlgCommonReward))]
    public static class DlgCommonRewardSystem
    {
        public static void RegisterUIEvent(this DlgCommonReward self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
        }

        public static void ShowWindow(this DlgCommonReward self, Entity contextData = null)
        {
        }

        public static void OnImageButtonButton(this DlgCommonReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CommonReward);
        }

        public static void OnUpdateUI(this DlgCommonReward self, List<RewardItem> rewardItems)
        {
            self.View.ES_RewardList.Refresh(rewardItems, showName: true);
        }
    }
}
