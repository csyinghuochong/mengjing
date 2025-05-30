﻿namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ZhanQuLevelItem))]
    [EntitySystemOf(typeof(Scroll_Item_ZhanQuLevelItem))]
    public static partial class Scroll_Item_ZhanQuLevelItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ZhanQuLevelItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ZhanQuLevelItem self)
        {
            self.DestroyWidget();
        }

        //Par_1 条件    Par_2 人数    Par_3奖励 
        public static void OnInitUI(this Scroll_Item_ZhanQuLevelItem self, ActivityConfig activityInfo)
        {
            self.E_ButtonReceiveButton.AddListenerAsync(self.OnButtonReceive);
            self.EG_YiLingQuSetRectTransform.gameObject.SetActive(false);

            self.ActivityConfig = activityInfo;
            self.OnUpdateLeftNumber();
            self.ES_RewardList.Refresh(activityInfo.Par_3, 0.8f);
        }

        public static void OnUpdateLeftNumber(this Scroll_Item_ZhanQuLevelItem self)
        {
            ActivityConfig activityInfo = self.ActivityConfig;
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            int receiveNum = 0;
            int leftNumber = 0;
            for (int i = 0; i < activityComponent.ZhanQuReceiveNumbers.Count; i++)
            {
                if (activityComponent.ZhanQuReceiveNumbers[i].ActivityId == activityInfo.Id)
                {
                    receiveNum = activityComponent.ZhanQuReceiveNumbers[i].ReceiveNum;
                }
            }

            leftNumber = int.Parse(activityInfo.Par_2) - receiveNum;

            using (zstring.Block())
            {
                self.E_TextLeftText.text = zstring.Format("{0}/{1}", leftNumber, activityInfo.Par_2);
                self.E_Text_levelText.text = zstring.Format("等级达到{0}级", activityInfo.Par_1);
            }

            self.E_Img_LodingValue.fillAmount = (float)leftNumber / int.Parse(activityInfo.Par_2);  
            self.EG_YiLingQuSetRectTransform.gameObject.SetActive(activityComponent.ZhanQuReceiveIds.Contains(activityInfo.Id) && leftNumber > 0);
            self.E_ButtonReceiveButton.gameObject.SetActive(!activityComponent.ZhanQuReceiveIds.Contains(activityInfo.Id) && leftNumber > 0);
            self.E_TextTip2Text.gameObject.SetActive(leftNumber == 0);
        }

        public static async ETTask OnButtonReceive(this Scroll_Item_ZhanQuLevelItem self)
        {
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv < int.Parse(self.ActivityConfig.Par_1))
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.ZhanQuReceiveIds.Contains(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过该奖励！");
                return;
            }

            await ActivityNetHelper.ZhanQuReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
            self.OnUpdateLeftNumber();
        }
    }
}