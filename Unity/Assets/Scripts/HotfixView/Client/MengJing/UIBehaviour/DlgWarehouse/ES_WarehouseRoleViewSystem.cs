using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_WarehouseRole))]
    [FriendOfAttribute(typeof(ES_WarehouseRole))]
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

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet, self.CheckPageButton_1);
            self.E_ButtonPackButton.AddListener(self.OnButtonPackButton);
            self.E_ButtonQuickButton.AddListenerAsync(self.OnButtonQuickButton);

            self.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

            self.RefreshBagItems();
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.UpdateLockList(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_WarehouseRole self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_WarehouseRole self, int index)
        {
            self.RefreshHouseItems();
            self.UpdateLockList(index);
        }

        private static bool CheckPageButton_1(this ES_WarehouseRole self, int page)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cangkuNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.CangKuNumber);
            if (cangkuNumber <= page)
            {
                string costItems = GlobalValueConfigCategory.Instance.Get(38).Value;
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "开启仓库", zstring.Format("是否消耗{0}开启一个仓库", CommonViewHelper.GetNeedItemDesc(costItems)),
                        () => { self.RequestOpenCangKu().Coroutine(); }, null).Coroutine();
                }

                return false;
            }

            return true;
        }

        private static async ETTask RequestOpenCangKu(this ES_WarehouseRole self)
        {
            await BagClientNetHelper.RquestOpenCangKu(self.Root());
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cangkuNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.CangKuNumber);
            self.UpdateLockList(cangkuNumber - 1);
            self.OnItemTypeSet(cangkuNumber - 1);
        }

        private static async ETTask OnButtonQuickButton(this ES_WarehouseRole self)
        {
            int currentHouse = self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1;
            await BagClientNetHelper.RquestQuickPut(self.Root(), currentHouse);
        }

        private static void OnButtonPackButton(this ES_WarehouseRole self)
        {
            int currentHouse = self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1;
            BagClientNetHelper.RequestSortByLoc(self.Root(), currentHouse).Coroutine();
        }

        public static void OnBuyBagCell(this ES_WarehouseRole self, string dataparams)
        {
            self.RefreshHouseItems();
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得道具: {0}", CommonViewHelper.GetNeedItemDesc(dataparams)));
            }
        }

        private static void OnClickImage_Lock(this ES_WarehouseRole self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            int addcell = bagComponent.BagBuyCellNumber[self.E_ItemTypeSetToggleGroup.GetCurrentIndex()];
            BuyCellCost buyCellCost = ConfigData.BuyStoreCellCosts[self.E_ItemTypeSetToggleGroup.GetCurrentIndex() * 10 + addcell];
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "购买格子",
                    zstring.Format("是否花费{0}购买一个背包格子?", CommonViewHelper.GetNeedItemDesc(buyCellCost.Cost)),
                    () =>
                    {
                        BagClientNetHelper
                                .RequestBuyBagCell(self.Root(), self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1)
                                .Coroutine();
                    },
                    null).Coroutine();
            }
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
            self.ShowHouseBagInfos.AddRange(
                bagComponentC.GetItemsByLoc(self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1));

            int allNumber = bagComponentC.GetBagShowCell(self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1);
            self.AddUIScrollItems(ref self.ScrollItemHouseItems, allNumber);
            self.E_BagItems1LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void RefreshBagItems(this ES_WarehouseRole self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagBagInfos.Clear();
            self.ShowBagBagInfos.AddRange(bagComponentC.GetItemsByType((int)ItemLocType.ItemLocBag));
            int allNumber = bagComponentC.GetBagShowCell(ItemLocType.ItemLocBag);

            self.AddUIScrollItems(ref self.ScrollItemBagItems, allNumber);
            self.E_BagItems2LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void OnHouseItemsRefresh(this ES_WarehouseRole self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemHouseItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);

            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            int openell = bagComponentC.GetBagShowCell(self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1);
            int allNumber = bagComponentC.GetBagShowCell(self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1);

            if (index < self.ShowHouseBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowHouseBagInfos[index], ItemOperateEnum.Cangku, self.UpdateHouseSelect,
                    self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }

            if (index < openell)
            {
                scrollItemCommonItem.UpdateUnLock(true);
            }
            else
            {
                int addcell = bagComponentC.BagBuyCellNumber[self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1] +
                        (index - openell);
                BuyCellCost buyCellCost = ConfigData.BuyStoreCellCosts[self.E_ItemTypeSetToggleGroup.GetCurrentIndex() * 10 + addcell];
                int itemid = int.Parse(buyCellCost.Get.Split(';')[0]);
                int itemnum = int.Parse(buyCellCost.Get.Split(';')[1]);
                ItemInfo bagInfoNew = new ItemInfo();
                bagInfoNew.ItemID = itemid;
                bagInfoNew.ItemNum = itemnum;
                scrollItemCommonItem.Refresh(bagInfoNew, ItemOperateEnum.None);
                scrollItemCommonItem.UpdateUnLock(false);
                scrollItemCommonItem.E_LockButton.AddListener(self.OnClickImage_Lock);
            }
        }

        private static void OnBagItemsRefresh(this ES_WarehouseRole self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemBagItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count ? self.ShowBagBagInfos[index] : null, ItemOperateEnum.CangkuBag,
                self.UpdateBagSelect, self.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.ItemWareHouse1);
        }

        private static void UpdateHouseSelect(this ES_WarehouseRole self, ItemInfo bagInfo)
        {
            if (self.ScrollItemHouseItems != null)
            {
                foreach (var value in self.ScrollItemHouseItems.Values)
                {
                    Scroll_Item_CommonItem scrollItemCommonItem = value;
                    if (scrollItemCommonItem.uiTransform != null)
                    {
                        scrollItemCommonItem.SetSelected(bagInfo);
                    }
                }
            }
        }

        private static void UpdateBagSelect(this ES_WarehouseRole self, ItemInfo bagInfo)
        {
            if (self.ScrollItemBagItems != null)
            {
                foreach (var value in self.ScrollItemBagItems.Values)
                {
                    Scroll_Item_CommonItem scrollItemCommonItem = value;
                    if (scrollItemCommonItem.uiTransform != null)
                    {
                        scrollItemCommonItem.SetSelected(bagInfo);
                    }
                }
            }
        }

        public static void UpdateLockList(this ES_WarehouseRole self, int page)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cangkuNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.CangKuNumber);
            for (int i = 0; i < self.LockList.Count; i++)
            {
                self.LockList[i].SetActive(cangkuNumber - 1 < i);
                self.NoLockList[i].SetActive(cangkuNumber - 1 >= i && i != page);
            }
        }
    }
}
