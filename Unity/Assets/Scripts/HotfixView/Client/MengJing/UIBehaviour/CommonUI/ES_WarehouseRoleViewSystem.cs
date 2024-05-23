using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (ES_WarehouseRole))]
    [FriendOfAttribute(typeof (ES_WarehouseRole))]
    public static partial class ES_WarehouseRoleSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WarehouseRole self, Transform transform)
        {
            self.uiTransform = transform;

            self.LockList.Add(self.E_Lock_1Image.gameObject);
            self.LockList.Add(self.E_Lock_2Image.gameObject);
            self.LockList.Add(self.E_Lock_3Image.gameObject);
            self.LockList.Add(self.E_Lock_4Image.gameObject);
            self.NoLockList.Add(self.E_NoLock_1Image.gameObject);
            self.NoLockList.Add(self.E_NoLock_2Image.gameObject);
            self.NoLockList.Add(self.E_NoLock_3Image.gameObject);
            self.NoLockList.Add(self.E_NoLock_4Image.gameObject);

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);

            self.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

            self.RefreshBagItems();
            self.E_1Toggle.IsSelected(true);
        }

        [EntitySystem]
        private static void Destroy(this ES_WarehouseRole self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_WarehouseRole self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_2Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_3Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.E_4Toggle.gameObject, index == 3);

            self.CurrentItemType = index;
            self.RefreshHouseItems();
        }

        public static void Refresh(this ES_WarehouseRole self)
        {
            self.RefreshHouseItems();
            self.RefreshBagItems();
        }

        private static void RefreshHouseItems(this ES_WarehouseRole self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowHouseBagInfos.Clear();
            self.ShowHouseBagInfos.AddRange(bagComponentC.GetItemsByLoc((ItemLocType)(self.CurrentItemType + 5)));

            int allNumber = bagComponentC.GetHouseShowCell(self.CurrentItemType + 5);
            self.AddUIScrollItems(ref self.ScrollItemHouseItems, allNumber);
            self.E_BagItems1LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void RefreshBagItems(this ES_WarehouseRole self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagBagInfos.Clear();
            self.ShowBagBagInfos.AddRange(bagComponentC.GetItemsByType((int)ItemLocType.ItemLocBag));
            int allNumber = bagComponentC.GetBagShowCell();

            self.AddUIScrollItems(ref self.ScrollItemBagItems, allNumber);
            self.E_BagItems2LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void OnHouseItemsRefresh(this ES_WarehouseRole self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);

            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            int openell = bagComponentC.GetHouseTotalCell(self.CurrentItemType + 5);
            int allNumber = bagComponentC.GetHouseShowCell(self.CurrentItemType + 5);

            if (index < self.ShowHouseBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowHouseBagInfos[index], ItemOperateEnum.Cangku, self.UpdateHouseSelect);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }

            if (index < openell)
            {
                scrollItemCommonItem.ES_CommonItem.UpdateUnLock(true);
            }
            else
            {
                int addcell = bagComponentC.WarehouseAddedCell[self.CurrentItemType + 5] + (index - openell);
                BuyCellCost buyCellCost = ConfigData.BuyStoreCellCosts[self.CurrentItemType * 10 + addcell];
                int itemid = int.Parse(buyCellCost.Get.Split(';')[0]);
                int itemnum = int.Parse(buyCellCost.Get.Split(';')[1]);
                scrollItemCommonItem.Refresh(new BagInfo() { ItemID = itemid, ItemNum = itemnum }, ItemOperateEnum.None);
                scrollItemCommonItem.ES_CommonItem.UpdateUnLock(false);
            }
        }

        private static void OnBagItemsRefresh(this ES_WarehouseRole self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count? self.ShowBagBagInfos[index] : null, ItemOperateEnum.CangkuBag,
                self.UpdateBagSelect);
        }

        private static void UpdateHouseSelect(this ES_WarehouseRole self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemHouseItems.Keys.Count - 1; i++)
            {
                if (self.ScrollItemHouseItems[i].uiTransform != null)
                {
                    self.ScrollItemHouseItems[i].UpdateSelectStatus(bagInfo);
                }
            }
        }

        private static void UpdateBagSelect(this ES_WarehouseRole self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemBagItems.Keys.Count - 1; i++)
            {
                if (self.ScrollItemBagItems[i].uiTransform != null)
                {
                    self.ScrollItemBagItems[i].UpdateSelectStatus(bagInfo);
                }
            }
        }
    }
}