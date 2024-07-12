using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_ButtonPackButton.AddListener(self.OnBtn_ZhengLi);
            self.E_ButtonQuickButton.AddListenerAsync(self.OnButtonQuick);

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
            if (!self.CheckPageButton_1(index))
            {
                return;
            }

            self.CurrentItemType = index;
            self.Root().GetComponent<BagComponentC>().CurrentHouse = self.CurrentItemType + (int)ItemLocType.ItemWareHouse1;
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
                PopupTipHelp.OpenPopupTip(self.Root(), "开启仓库", $"是否消耗{CommonViewHelper.GetNeedItemDesc(costItems)}开启一个仓库",
                    () => { self.RequestOpenCangKu().Coroutine(); }, null).Coroutine();
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

        private static async ETTask OnButtonQuick(this ES_WarehouseRole self)
        {
            int currentHouse = self.CurrentItemType + (int)ItemLocType.ItemWareHouse1;
            await BagClientNetHelper.RquestQuickPut(self.Root(), currentHouse);
        }

        private static void OnBtn_ZhengLi(this ES_WarehouseRole self)
        {
            int currentHouse = self.CurrentItemType + (int)ItemLocType.ItemWareHouse1;
            BagClientNetHelper.RequestSortByLoc(self.Root(), (ItemLocType)currentHouse).Coroutine();
        }

        public static void OnBuyBagCell(this ES_WarehouseRole self, string dataparams)
        {
            self.RefreshHouseItems();
            FlyTipComponent.Instance.ShowFlyTipDi($"获得道具: {CommonViewHelper.GetNeedItemDesc(dataparams)}");
        }

        private static void OnClickImage_Lock(this ES_WarehouseRole self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            int addcell = bagComponent.WarehouseAddedCell[self.CurrentItemType];
            BuyCellCost buyCellCost = ConfigData.BuyStoreCellCosts[self.CurrentItemType * 10 + addcell];
            PopupTipHelp.OpenPopupTip(self.Root(), "购买格子",
                $"是否花费{CommonViewHelper.GetNeedItemDesc(buyCellCost.Cost)}购买一个背包格子?",
                () => { BagClientNetHelper.RequestBuyBagCell(self.Root(), self.CurrentItemType + (int)ItemLocType.ItemWareHouse1).Coroutine(); },
                null).Coroutine();
        }

        public static void Refresh(this ES_WarehouseRole self)
        {
            self.Root().GetComponent<BagComponentC>().CurrentHouse = self.CurrentItemType + (int)ItemLocType.ItemWareHouse1;
            self.RefreshHouseItems();
            self.RefreshBagItems();
        }

        private static void RefreshHouseItems(this ES_WarehouseRole self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowHouseBagInfos.Clear();
            self.ShowHouseBagInfos.AddRange(bagComponentC.GetItemsByLoc((ItemLocType)(self.CurrentItemType + (int)ItemLocType.ItemWareHouse1)));

            int allNumber = bagComponentC.GetHouseShowCell(self.CurrentItemType + (int)ItemLocType.ItemWareHouse1);
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
            int openell = bagComponentC.GetHouseTotalCell(self.CurrentItemType + (int)ItemLocType.ItemWareHouse1);
            int allNumber = bagComponentC.GetHouseShowCell(self.CurrentItemType + (int)ItemLocType.ItemWareHouse1);

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
                int addcell = bagComponentC.WarehouseAddedCell[self.CurrentItemType + (int)ItemLocType.ItemWareHouse1] + (index - openell);
                BuyCellCost buyCellCost = ConfigData.BuyStoreCellCosts[self.CurrentItemType * 10 + addcell];
                int itemid = int.Parse(buyCellCost.Get.Split(';')[0]);
                int itemnum = int.Parse(buyCellCost.Get.Split(';')[1]);
                BagInfo bagInfoNew = BagInfo.Create();
                bagInfoNew.ItemID = itemid;
                bagInfoNew.ItemNum = itemnum;
                scrollItemCommonItem.Refresh(bagInfoNew, ItemOperateEnum.None);
                scrollItemCommonItem.ES_CommonItem.UpdateUnLock(false);
                scrollItemCommonItem.ES_CommonItem.E_LockButton.AddListener(self.OnClickImage_Lock);
            }
        }

        private static void OnBagItemsRefresh(this ES_WarehouseRole self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count ? self.ShowBagBagInfos[index] : null, ItemOperateEnum.CangkuBag,
                self.UpdateBagSelect);
        }

        private static void UpdateHouseSelect(this ES_WarehouseRole self, BagInfo bagInfo)
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

        private static void UpdateBagSelect(this ES_WarehouseRole self, BagInfo bagInfo)
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