using System;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(Scroll_Item_SettlementRwardItem))]
    [EntitySystemOf(typeof(Scroll_Item_SettlementRwardItem))]
    public static partial class Scroll_Item_SettlementRwardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SettlementRwardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SettlementRwardItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_SettlementRwardItem self)
        {
            if (self.RewardItem != null)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = self.RewardItem.ItemID;
                bagInfo.ItemNum = self.RewardItem.ItemNum;
                self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            }
        }

        public static void OnUpdateData(this Scroll_Item_SettlementRwardItem self, RewardItem rewardItem)
        {
            self.E_Image_bgOpenImage.gameObject.SetActive(false);
            self.E_ImageButtonButton.AddListener(self.OnClickItem);
            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
            self.OnInitUI();

            self.RewardItem = rewardItem;
            if (self.ES_CommonItem != null)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = self.RewardItem.ItemID;
                bagInfo.ItemNum = self.RewardItem.ItemNum;
                self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            }
        }

        public static void SetClickHandler(this Scroll_Item_SettlementRwardItem self, Action<int> action, int index)
        {
            self.Index = index;
            self.ClickHandler = action;
        }

        public static void ShowRewardItem(this Scroll_Item_SettlementRwardItem self, string name)
        {
            self.E_TextNameText.text = name;
            if (self.ES_CommonItem.uiTransform.gameObject.activeSelf)
            {
                return;
            }

            self.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            self.E_Image_bgOpenImage.gameObject.SetActive(true);
            self.E_Image_bgImage.gameObject.SetActive(false);
            self.DisableClick();
        }

        public static bool IsCanClicked(this Scroll_Item_SettlementRwardItem self)
        {
            return self.E_ImageButtonButton.gameObject.activeSelf;
        }

        public static void DisableClick(this Scroll_Item_SettlementRwardItem self)
        {
            self.E_ImageButtonButton.gameObject.SetActive(false);
        }

        public static void OnClickItem(this Scroll_Item_SettlementRwardItem self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (self.Index >= 3 && !unit.IsYueKaStates())
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