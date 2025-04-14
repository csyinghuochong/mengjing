using System;

namespace ET.Client
{
    [FriendOf(typeof(ES_RewardList))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(Scroll_Item_NewYearCollectionWordItem))]
    [EntitySystemOf(typeof(Scroll_Item_NewYearCollectionWordItem))]
    public static partial class Scroll_Item_NewYearCollectionWordItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_NewYearCollectionWordItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_NewYearCollectionWordItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_NewYearCollectionWordItem self, ActivityConfig activityConfig)
        {
            self.E_ButtonDuiHuanButton.AddListenerAsync(self.OnButtonDuiHuan);

            self.ActivityConfig = activityConfig;

            self.ES_RewardList_Word.Refresh(activityConfig.Par_2, showNumber: false, showName: false);

            self.ES_RewardList.Refresh(activityConfig.Par_3, getWay: ItemGetWay.ActivityNewYear);
        }

        public static void OnUpdateUI(this Scroll_Item_NewYearCollectionWordItem self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            foreach (Scroll_Item_CommonItem item in self.ES_RewardList_Word.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                bool gray = bagComponent.GetItemNumber(item.Baginfo.ItemID) <= 0;
                CommonViewHelper.SetImageGray(self.Root(), item.E_ItemIconImage.gameObject, gray);
                CommonViewHelper.SetImageGray(self.Root(), item.E_ItemQualityImage.gameObject, gray);
            }

            ActivityConfig activityConfig = self.ActivityConfig;
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            int receiveNumber = 0;
            for (int i = 0; i < activityComponent.ActivityReceiveIds.Count; i++)
            {
                if (activityComponent.ActivityReceiveIds[i] == self.ActivityConfig.Id)
                {
                    receiveNumber++;
                }
            }

            //显示兑换次数
            using (zstring.Block())
            {
                self.E_LabDuiHuanText.text = zstring.Format("兑换次数:{0}/{1}", receiveNumber, activityConfig.Par_1);
            }
        }

        public static void SetAction(this Scroll_Item_NewYearCollectionWordItem self, Action action)
        {
            self.ReceiveHandler = action;
        }

        public static async ETTask OnButtonDuiHuan(this Scroll_Item_NewYearCollectionWordItem self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            bool receiveMax = ActivityHelper.HaveReceiveTimes(activityComponent.ActivityReceiveIds, self.ActivityConfig.Id);
            if (!receiveMax)
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到最大领取上限！");
                return;
            }

            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(self.ActivityConfig.Par_2))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            await ActivityNetHelper.ActivityReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
            self.ReceiveHandler();
        }
    }
}