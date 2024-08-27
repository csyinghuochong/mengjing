using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RoleXiLianNumRewardItem))]
    [EntitySystemOf(typeof(Scroll_Item_RoleXiLianNumRewardItem))]
    public static partial class Scroll_Item_RoleXiLianNumRewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RoleXiLianNumRewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RoleXiLianNumRewardItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnBtn_Reward(this Scroll_Item_RoleXiLianNumRewardItem self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            bool received = userInfoComponent.UserInfo.ItemXiLianNumRewardIds.Contains(self.RewardKey);
            if (received)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianNumber) < self.RewardKey)
            {
                FlyTipComponent.Instance.ShowFlyTip("条件未达到！");
                return;
            }

            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) <
                ConfigData.ItemXiLianNumReward[self.RewardKey].Split('@').Length - 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            int error = await BagClientNetHelper.RquestItemXiLianNumReward(self.Root(), self.RewardKey);

            if (error == ErrorCode.ERR_Success)
            {
                userInfoComponent.UserInfo.ItemXiLianNumRewardIds.Add(self.RewardKey);
            }

            self.UpdateButton();
        }

        public static void UpdateButton(this Scroll_Item_RoleXiLianNumRewardItem self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            bool received = userInfoComponent.UserInfo.ItemXiLianNumRewardIds.Contains(self.RewardKey);
            self.E_Btn_RewardButton.gameObject.SetActive(!received);
        }

        public static void OnUpdateUI(this Scroll_Item_RoleXiLianNumRewardItem self, int key)
        {
            self.E_Btn_RewardButton.AddListenerAsync(self.OnBtn_Reward);

            self.RewardKey = key;
            string[] reward = ConfigData.ItemXiLianNumReward[key].Split('$');
            string[] items = reward[0].Split('@');
            List<RewardItem> rewardItems = new List<RewardItem>();
            foreach (string item in items)
            {
                string[] it = item.Split(';');
                rewardItems.Add(new RewardItem() { ItemID = int.Parse(it[0]), ItemNum = int.Parse(it[1]) });
            }

            self.ES_RewardList.Refresh(rewardItems, 0.8f);
            string[] diamond = reward[1].Split(';')[1].Split(',');
            using (zstring.Block())
            {
                self.E_TextZuanshiText.text = zstring.Format("{0}-{1}", diamond[0], diamond[1]);
                self.E_TextNeedTimesText.text = zstring.Format("洗练次数达到{0}次", key);
            }

            self.UpdateButton();
        }
    }
}