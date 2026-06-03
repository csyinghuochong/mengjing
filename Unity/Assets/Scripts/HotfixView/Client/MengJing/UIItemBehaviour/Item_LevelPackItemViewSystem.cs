using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_LevelPackItem))]
    [EntitySystemOf(typeof(Scroll_Item_LevelPackItem))]
    public static partial class Scroll_Item_LevelPackItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_LevelPackItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_LevelPackItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_LevelPackItem self, ActivityConfig activityInfo)
        {
            self.E_ButtonReceiveButton.AddListenerAsync(self.OnButtonReceive);

            self.ActivityConfig = activityInfo;
            self.E_Text_levelText.text = activityInfo.Par_1;
            self.ES_RewardList.Refresh(activityInfo.Par_3, 0.8f);
            self.E_TextPriceText.text = activityInfo.Par_2.Split(';')[1];
            
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            self.EG_YiLingQuSetRectTransform.gameObject.SetActive(activityComponent.ZhanQuReceiveIds.Contains(activityInfo.Id));
            self.E_ButtonReceiveButton.gameObject.SetActive(!activityComponent.ZhanQuReceiveIds.Contains(activityInfo.Id));
        }

        public static async ETTask OnButtonReceive(this Scroll_Item_LevelPackItem self)
        {
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv < int.Parse(self.ActivityConfig.Par_1))
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.ActivityReceiveIds.Contains(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经购买过！");
                return;
            }

            await ActivityNetHelper.ActivityReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
        }
    }
}