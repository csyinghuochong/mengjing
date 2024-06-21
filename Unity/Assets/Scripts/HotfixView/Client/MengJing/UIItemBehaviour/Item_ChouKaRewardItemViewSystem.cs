using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ChouKaRewardItem))]
    [EntitySystemOf(typeof (Scroll_Item_ChouKaRewardItem))]
    public static partial class Scroll_Item_ChouKaRewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChouKaRewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChouKaRewardItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnBtn_Reward(this Scroll_Item_ChouKaRewardItem self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            bool received = userInfoComponent.UserInfo.ChouKaRewardIds.Contains(self.TakeCardRewardConfig.Id);
            if (received)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ChouKa) < self.TakeCardRewardConfig.RoseLvLimit)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("条件未达到！");
                return;
            }

            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell() < self.TakeCardRewardConfig.RewardItems.Split('@').Length)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("背包空间不足！");
                return;
            }

            await BagClientNetHelper.ChouKaReward(self.Root(), self.TakeCardRewardConfig.Id);

            self.UpdateButton();
        }

        public static void UpdateButton(this Scroll_Item_ChouKaRewardItem self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            bool received = userInfoComponent.UserInfo.ChouKaRewardIds.Contains(self.TakeCardRewardConfig.Id);
            self.E_Btn_RewardButton.gameObject.SetActive(!received);
        }

        public static void OnUpdateUI(this Scroll_Item_ChouKaRewardItem self, TakeCardRewardConfig takeCardRewardConfig)
        {
            self.E_Btn_RewardButton.AddListenerAsync(self.OnBtn_Reward);
            self.TakeCardRewardConfig = takeCardRewardConfig;
            self.ES_RewardList.Refresh(takeCardRewardConfig.RewardItems, 0.8f);

            self.E_TextZuanshiText.text = $"{takeCardRewardConfig.RewardDiamond[0]}-{takeCardRewardConfig.RewardDiamond[1]}";
            self.E_TextNeedTimesText.text = $"抽卡次数达到{takeCardRewardConfig.RoseLvLimit}次";

            self.UpdateButton();
        }
    }
}