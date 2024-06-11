using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (Scroll_Item_NewYearCollectionWordItem))]
    [EntitySystemOf(typeof (Scroll_Item_NewYearCollectionWordItem))]
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
            string[] wordItems = activityConfig.Par_2.Split('@');
            var path = ABPathHelper.GetUGUIPath("Item/Item_CommonItem");
            var bundleGameObject = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            for (int i = 0; i < wordItems.Length; i++)
            {
                string[] itemInfo = wordItems[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                GameObject itemObject = UnityEngine.Object.Instantiate(bundleGameObject);
                Scroll_Item_CommonItem uIItemComponent = self.AddChild<Scroll_Item_CommonItem>();
                uIItemComponent.uiTransform = itemObject.transform;
                uIItemComponent.Refresh(new BagInfo() { ItemID = itemId }, ItemOperateEnum.None);
                uIItemComponent.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
                uIItemComponent.ES_CommonItem.E_ItemNameText.gameObject.SetActive(false);
                self.WordItems.Add(uIItemComponent);
                UICommonHelper.SetParent(itemObject, self.EG_WordListRectTransform.gameObject);
            }

            self.ES_RewardList.Refresh(activityConfig.Par_3, getWay: ItemGetWay.ActivityNewYear);
        }

        public static void OnUpdateUI(this Scroll_Item_NewYearCollectionWordItem self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            for (int i = 0; i < self.WordItems.Count; i++)
            {
                bool gray = bagComponent.GetItemNumber(self.WordItems[i].ES_CommonItem.Baginfo.ItemID) <= 0;
                UICommonHelper.SetImageGray(self.Root(), self.WordItems[i].ES_CommonItem.E_ItemIconImage.gameObject, gray);
                UICommonHelper.SetImageGray(self.Root(), self.WordItems[i].ES_CommonItem.E_ItemQualityImage.gameObject, gray);
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
            self.E_LabDuiHuanText.text = GameSettingLanguge.LoadLocalization($"兑换次数:{receiveNumber}/{activityConfig.Par_1}");
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
                FlyTipComponent.Instance.SpawnFlyTipDi("已达到最大领取上限！");
                return;
            }

            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(self.ActivityConfig.Par_2))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("道具不足！");
                return;
            }

            await ActivityNetHelper.ActivityReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
            self.ReceiveHandler();
        }
    }
}