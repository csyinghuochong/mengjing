using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [EntitySystemOf(typeof(ES_SettlementReward))]
    [FriendOfAttribute(typeof(ES_SettlementReward))]
    public static partial class ES_SettlementRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SettlementReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageButtonButton.AddListener(self.OnClickItem);
            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_SettlementReward self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_SettlementReward self)
        {
            if (self.RewardItem != null)
            {
                ItemInfo itemInfo = new();
                itemInfo.ItemID = self.RewardItem.ItemID;
                itemInfo.ItemNum = self.RewardItem.ItemNum;
                self.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
            }
        }

        public static void OnUpdateData(this ES_SettlementReward self, RewardItem rewardItem)
        {
            self.RewardItem = rewardItem;
            ItemInfo itemInfo = new();
            itemInfo.ItemID = self.RewardItem.ItemID;
            itemInfo.ItemNum = self.RewardItem.ItemNum;
            self.ES_CommonItem.UpdateItem(itemInfo, ItemOperateEnum.None);
        }

        public static void SetClickHandler(this ES_SettlementReward self, Action<int> action, int index)
        {
            self.Index = index;
            self.ClickHandler = action;
        }

        public static bool IsCanClicked(this ES_SettlementReward self)
        {
            return self.E_ImageButtonButton.gameObject.activeSelf;
        }

        public static void DisableClick(this ES_SettlementReward self)
        {
            self.E_ImageButtonButton.gameObject.SetActive(false);
        }

        public static void OnClickItem(this ES_SettlementReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (self.Index >= 3 && !unit.IsYueKaEndStates())
            {
                FlyTipComponent.Instance.ShowFlyTip("周卡用户才能开启！");
                return;
            }

            if (self.ES_CommonItem.uiTransform.gameObject.activeSelf)
            {
                return;
            }

            self.ClickHandler(self.Index);
        }
    }
}