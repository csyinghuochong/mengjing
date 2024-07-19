using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_WarehouseGem))]
    [FriendOfAttribute(typeof(ES_WarehouseGem))]
    public static partial class ES_WarehouseGemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WarehouseGem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonPackButton.AddListener(self.OnBtn_ZhengLi);
            self.E_ButtonHeChengButton.AddListenerAsync(self.OnButtonHeCheng);

            self.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_WarehouseGem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonHeCheng(this ES_WarehouseGem self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("请至少预留一个格子");
                return;
            }

            int error = await BagClientNetHelper.RquestGemHeCheng(self.Root(), 19);
            if (error == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip(GameSettingLanguge.Instance.LoadLocalization("宝石合成成功！"));
            }
        }

        public static void OnBtn_ZhengLi(this ES_WarehouseGem self)
        {
            BagClientNetHelper.RequestSortByLoc(self.Root(), ItemLocType.GemWareHouse1).Coroutine();
            FlyTipComponent.Instance.ShowFlyTip("宝石仓库已整理完毕");
        }

        public static void Refresh(this ES_WarehouseGem self)
        {
            self.RefreshHouseItems();
            self.RefreshBagItems();
        }

        private static void RefreshHouseItems(this ES_WarehouseGem self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowHouseBagInfos.Clear();
            self.ShowHouseBagInfos.AddRange(bagComponentC.GetItemsByLoc(ItemLocType.GemWareHouse1));

            int hourseNumber = GlobalValueConfigCategory.Instance.GemStoreMaxCapacity;
            self.AddUIScrollItems(ref self.ScrollItemHouseItems, hourseNumber);
            self.E_BagItems1LoopVerticalScrollRect.SetVisible(true, hourseNumber);
        }

        private static void RefreshBagItems(this ES_WarehouseGem self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagBagInfos.Clear();
            List<BagInfo> allItems = bagComponentC.GetItemsByType((int)ItemLocType.ItemLocBag);
            for (int i = 0; i < allItems.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(allItems[i].ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Gemstone)
                {
                    self.ShowBagBagInfos.Add(allItems[i]);
                }
            }

            int allNumber = bagComponentC.GetBagShowCell();

            self.AddUIScrollItems(ref self.ScrollItemBagItems, allNumber);
            self.E_BagItems2LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void OnHouseItemsRefresh(this ES_WarehouseGem self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);

            if (index < self.ShowHouseBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowHouseBagInfos[index], ItemOperateEnum.GemCangku, self.UpdateHouseSelect,
                    (int)ItemLocType.GemWareHouse1);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }
        }

        private static void OnBagItemsRefresh(this ES_WarehouseGem self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count ? self.ShowBagBagInfos[index] : null, ItemOperateEnum.GemBag,
                self.UpdateBagSelect, (int)ItemLocType.GemWareHouse1);
        }

        private static void UpdateHouseSelect(this ES_WarehouseGem self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemHouseItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                }
            }
        }

        private static void UpdateBagSelect(this ES_WarehouseGem self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemBagItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                }
            }
        }
    }
}