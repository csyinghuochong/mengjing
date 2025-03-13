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

        public static void OnUpdateData(this Scroll_Item_ActivitySingleRechargeItem self, int key)
        {
            self.E_ReceiveBtnButton.AddListenerAsync(self.OnReceiveBtn);

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            self.Key = key;
            using (zstring.Block())
            {
                self.E_ConsumeNumTextText.text = zstring.Format("单笔充值{0}元", key);
            }

            self.E_ReddotImage.gameObject.SetActive(userInfoComponent.UserInfo.SingleRechargeIds.Contains(key) &&
                !userInfoComponent.UserInfo.SingleRewardIds.Contains(key));
            self.E_ReceivedImgImage.gameObject.SetActive(userInfoComponent.UserInfo.SingleRewardIds.Contains(key));
            self.E_ReceiveBtnButton.gameObject.SetActive(!userInfoComponent.UserInfo.SingleRewardIds.Contains(key));
            self.ES_RewardList.Refresh(ConfigData.SingleRechargeReward[key]);
            self.ES_RewardList.ShowUIEffect(41100001);
        }

        public static async ETTask OnReceiveBtn(this Scroll_Item_ActivitySingleRechargeItem self)
        {
            if (!ConfigData.SingleRechargeReward.ContainsKey(self.Key))
            {
                return;
            }

            string[] rewarditemlist = ConfigData.SingleRechargeReward[self.Key].Split('@');
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewarditemlist.Length)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足");
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (!userInfo.SingleRechargeIds.Contains(self.Key))
            {
                FlyTipComponent.Instance.ShowFlyTip("未达条件");
                return;
            }

            if (userInfo.SingleRewardIds.Contains(self.Key))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取");
                return;
            }

            M2C_SingleRechargeRewardResponse response = await ActivityNetHelper.SingleRechargeReward(self.Root(), self.Key);

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