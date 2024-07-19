using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (DlgRechargeReward))]
    public static class DlgRechargeRewardSystem
    {
        public static void RegisterUIEvent(this DlgRechargeReward self)
        {
            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonClose);
            self.View.E_ButtonGoToPayButton.AddListener(self.OnButtonGoToPay);
            self.View.E_ButtonRewardButton.AddListenerAsync(self.OnButtonReward);
        }

        public static void ShowWindow(this DlgRechargeReward self, Entity contextData = null)
        {
            self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        private static void OnItemTypeSet(this DlgRechargeReward self, int index)
        {
            self.CurrentIndex = index;

            self.UpdateUI(index);
        }

        public static void OnButtonClose(this DlgRechargeReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RechargeReward);
        }

        public static async ETTask OnButtonReward(this DlgRechargeReward self)
        {
            int page = self.CurrentIndex;
            int rechargeNumber = page == 0? 50 : 98;

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.RechargeReward.Contains(rechargeNumber))
            {
                FlyTipComponent.Instance.ShowFlyTip("当前奖励已领取");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber) < rechargeNumber)
            {
                FlyTipComponent.Instance.ShowFlyTip($"充值金额不足 {rechargeNumber}元");
                return;
            }

            M2C_RechargeRewardResponse response = await ActivityNetHelper.RechargeReward(self.Root(), rechargeNumber);
            if (response.Error == ErrorCode.ERR_Success)
            {
                userInfoComponent.UserInfo.RechargeReward.Add(rechargeNumber);
            }

            if (self.InstanceId == 0)
            {
                return;
            }

            self.UpdateUI(page);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().CheckRechargeRewardButton();
        }

        public static void OnButtonGoToPay(this DlgRechargeReward self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        public static void UpdateUI(this DlgRechargeReward self, int page)
        {
            int rechargeNumber = page == 0? 50 : 98;
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int rechargeToal = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);

            if (rechargeToal < rechargeNumber)
            {
                self.View.E_ButtonGoToPayButton.gameObject.SetActive(true);
                self.View.E_ButtonRewardButton.gameObject.SetActive(false);
                self.View.E_ImageReceivedImage.gameObject.SetActive(false);
            }
            else
            {
                self.View.E_ButtonGoToPayButton.gameObject.SetActive(false);
                self.View.E_ButtonRewardButton.gameObject.SetActive(!userInfoComponent.UserInfo.RechargeReward.Contains(rechargeNumber));
                self.View.E_ImageReceivedImage.gameObject.SetActive(userInfoComponent.UserInfo.RechargeReward.Contains(rechargeNumber));
            }

            self.View.E_TextTipText.text = $"累冲{rechargeNumber}元， 获得以下奖励";

            string reward = ConfigData.RechargeReward[rechargeNumber];
            List<RewardItem> Recharge = ItemHelper.GetRewardItems(reward);
            self.View.ES_RewardList.Refresh(Recharge);
        }
    }
}