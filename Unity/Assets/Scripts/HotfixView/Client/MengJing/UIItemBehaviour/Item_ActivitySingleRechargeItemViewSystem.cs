namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingleRechargeItem))]
    [EntitySystemOf(typeof(Scroll_Item_ActivitySingleRechargeItem))]
    public static partial class Scroll_Item_ActivitySingleRechargeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivitySingleRechargeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivitySingleRechargeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateData(this Scroll_Item_ActivitySingleRechargeItem self, ActivityConfig activityConfig)
        {
            self.ActivityConfig = activityConfig;
            self.E_ReceiveBtnButton.AddListenerAsync(self.OnReceiveBtn);

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();


            using (zstring.Block())
            {
                self.E_ConsumeNumTextText.text = zstring.Format("单笔充值{0}元", activityConfig.Par_1);
            }

            self.E_ReddotImage.gameObject.SetActive(userInfoComponent.UserInfo.SingleRechargeIds.Contains(activityConfig.Id) &&
                !userInfoComponent.UserInfo.SingleRewardIds.Contains(activityConfig.Id));
            self.E_ReceivedImgImage.gameObject.SetActive(userInfoComponent.UserInfo.SingleRewardIds.Contains(activityConfig.Id));
            self.E_ReceiveBtnButton.gameObject.SetActive(!userInfoComponent.UserInfo.SingleRewardIds.Contains(activityConfig.Id));
            self.ES_RewardList.Refresh(activityConfig.Par_2);
            self.ES_RewardList.ShowUIEffect(41100001);
        }

        public static async ETTask OnReceiveBtn(this Scroll_Item_ActivitySingleRechargeItem self)
        {

            string[] rewarditemlist = self.ActivityConfig.Par_2.Split('@');
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewarditemlist.Length)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (!userInfo.SingleRechargeIds.Contains(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("未达条件");
                return;
            }

            if (userInfo.SingleRewardIds.Contains(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取");
                return;
            }

            M2C_SingleRechargeRewardResponse response = await ActivityNetHelper.SingleRechargeReward(self.Root(), self.ActivityConfig.Id);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            userInfo.SingleRewardIds = response.RewardIds;
            ReddotComponentC redPointComponent = self.Root().GetComponent<ReddotComponentC>();
            redPointComponent.UpdateReddont(ReddotType.SingleRecharge);

            self.E_ReddotImage.gameObject.SetActive(false);
            self.E_ReceiveBtnButton.gameObject.SetActive(false);
            self.E_ReceivedImgImage.gameObject.SetActive(true);
        }
    }
}