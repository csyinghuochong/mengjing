using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ActivityTeHuiItem))]
    [EntitySystemOf(typeof (Scroll_Item_ActivityTeHuiItem))]
    public static partial class Scroll_Item_ActivityTeHuiItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivityTeHuiItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivityTeHuiItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_ActivityTeHuiItem self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.ActivityReceiveIds.Contains(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经购买过该礼包！");
                return;
            }


            M2C_ActivityReceiveResponse response =  await ActivityNetHelper.ActivityReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            self.E_ImageReceivedImage.gameObject.SetActive(true);
            self.E_ButtonBuyButton.gameObject.SetActive(false);
        }

        public static void OnUpdateUI(this Scroll_Item_ActivityTeHuiItem self, int activityId, bool received)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);
            self.ActivityConfig = activityConfig;
            self.E_ImageReceivedImage.gameObject.SetActive(received);
            self.E_ButtonBuyButton.gameObject.SetActive(!received);
            self.E_TextPriceText.text = activityConfig.Par_2.Split(';')[1];
            self.E_TextTypeText.text = activityConfig.Par_4;

            self.ES_RewardList.Refresh(activityConfig.Par_3, getWay: ItemGetWay.Activity_DayTeHui);
            self.ES_RewardList.ShowUIEffect(41100001);
            //显示图标
            string ItemIcon = activityConfig.Icon;
            if (!string.IsNullOrEmpty(ItemIcon))
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_ImageBoxImage.sprite = sp;
            }
        }
    }
}