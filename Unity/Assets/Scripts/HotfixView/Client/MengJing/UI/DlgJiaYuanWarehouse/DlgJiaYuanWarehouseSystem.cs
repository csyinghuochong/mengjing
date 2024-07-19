using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_DlgJiaYuanWarehouseRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanWarehouse>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgJiaYuanWarehouse))]
    public static class DlgJiaYuanWarehouseSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanWarehouse self)
        {
        }

        public static void ShowWindow(this DlgJiaYuanWarehouse self, Entity contextData = null)
        {
            self.LockList.Add(self.View.E_Lock_1Image.gameObject);
            self.LockList.Add(self.View.E_Lock_2Image.gameObject);
            self.LockList.Add(self.View.E_Lock_3Image.gameObject);
            self.LockList.Add(self.View.E_Lock_4Image.gameObject);
            self.NoLockList.Add(self.View.E_NoLock_1Image.gameObject);
            self.NoLockList.Add(self.View.E_NoLock_2Image.gameObject);
            self.NoLockList.Add(self.View.E_NoLock_3Image.gameObject);
            self.NoLockList.Add(self.View.E_NoLock_4Image.gameObject);

            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet, self.CheckPageButton_1);
            self.View.E_ButtonPackButton.AddListener(self.OnBtn_ZhengLi);
            self.View.E_ButtonTakeOutAllButton.AddListenerAsync(self.OnButtonOneKey);
            self.View.E_OneKeyButton.AddListenerAsync(self.OnButtonOneKey);

            self.View.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.View.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

            self.RefreshBagItems();
            self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.UpdateLockList(0);
        }

        private static void OnItemTypeSet(this DlgJiaYuanWarehouse self, int index)
        {
            self.RefreshHouseItems();
            self.UpdateLockList(index);
        }

        private static bool CheckPageButton_1(this DlgJiaYuanWarehouse self, int page)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cangkuNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.JianYuanCangKu);
            if (cangkuNumber <= page)
            {
                string costItems = ET.JiaYuanHelper.GetOpenJiaYuanWarehouse(cangkuNumber);
                PopupTipHelp.OpenPopupTip(self.Root(), "开启仓库", $"是否消耗{CommonViewHelper.GetNeedItemDesc(costItems)}开启一个仓库",
                    () => { self.RequestOpenCangKu().Coroutine(); }, null).Coroutine();
                return false;
            }

            return true;
        }

        private static async ETTask RequestOpenCangKu(this DlgJiaYuanWarehouse self)
        {
            await BagClientNetHelper.RquestOpenCangKu(self.Root());
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cangkuNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.JianYuanCangKu);
            self.UpdateLockList(cangkuNumber - 1);
            self.OnItemTypeSet(cangkuNumber - 1);
        }

        private static void OnBtn_ZhengLi(this DlgJiaYuanWarehouse self)
        {
            int currentHouse = self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanWareHouse1;
            BagClientNetHelper.RequestSortByLoc(self.Root(), (ItemLocType)currentHouse).Coroutine();
        }

        public static async ETTask OnButtonTakeOutAll(this DlgJiaYuanWarehouse self)
        {
            int currentHouse = self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanWareHouse1;
            await BagClientNetHelper.RquestTakeOutAll(self.Root(), currentHouse);
        }

        public static async ETTask OnButtonOneKey(this DlgJiaYuanWarehouse self)
        {
            await JiaYuanNetHelper.JiaYuanStoreRequest(self.Root(),
                self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanWareHouse1);
        }

        public static void OnBuyBagCell(this DlgJiaYuanWarehouse self, string dataparams)
        {
            self.RefreshHouseItems();
            FlyTipComponent.Instance.ShowFlyTip($"获得道具: {CommonViewHelper.GetNeedItemDesc(dataparams)}");
        }

        private static void OnClickImage_Lock(this DlgJiaYuanWarehouse self)
        {
            string costitems = GlobalValueConfigCategory.Instance.Get(83).Value;
            PopupTipHelp.OpenPopupTip(self.Root(), "购买格子",
                $"是否花费{CommonViewHelper.GetNeedItemDesc(costitems)}购买一个背包格子?",
                () => { },
                null).Coroutine();
        }

        public static void Refresh(this DlgJiaYuanWarehouse self)
        {
            self.RefreshHouseItems();
            self.RefreshBagItems();
        }

        private static void RefreshHouseItems(this DlgJiaYuanWarehouse self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowHouseBagInfos.Clear();
            self.ShowHouseBagInfos.AddRange(bagComponentC.GetItemsByLoc((ItemLocType)(self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() +
                (int)ItemLocType.JianYuanWareHouse1)));

            int allNumber =
                    bagComponentC.GetHouseShowCell(self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanWareHouse1);
            self.AddUIScrollItems(ref self.ScrollItemHouseItems, allNumber);
            self.View.E_BagItems1LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void RefreshBagItems(this DlgJiaYuanWarehouse self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagBagInfos.Clear();
            self.ShowBagBagInfos.AddRange(bagComponentC.GetItemsByType((int)ItemLocType.ItemLocBag));
            int allNumber = bagComponentC.GetBagShowCell();

            self.AddUIScrollItems(ref self.ScrollItemBagItems, allNumber);
            self.View.E_BagItems2LoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void OnHouseItemsRefresh(this DlgJiaYuanWarehouse self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);

            if (index < self.ShowHouseBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowHouseBagInfos[index], ItemOperateEnum.Cangku, self.UpdateHouseSelect,
                    self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanWareHouse1);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }
        }

        private static void OnBagItemsRefresh(this DlgJiaYuanWarehouse self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagBagInfos.Count ? self.ShowBagBagInfos[index] : null, ItemOperateEnum.CangkuBag,
                self.UpdateBagSelect, self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanWareHouse1);
        }

        private static void UpdateHouseSelect(this DlgJiaYuanWarehouse self, BagInfo bagInfo)
        {
            if (self.ScrollItemHouseItems != null)
            {
                foreach (var value in self.ScrollItemHouseItems.Values)
                {
                    Scroll_Item_CommonItem scrollItemCommonItem = value;
                    if (scrollItemCommonItem.uiTransform != null)
                    {
                        scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                    }
                }
            }
        }

        private static void UpdateBagSelect(this DlgJiaYuanWarehouse self, BagInfo bagInfo)
        {
            if (self.ScrollItemBagItems != null)
            {
                foreach (var value in self.ScrollItemBagItems.Values)
                {
                    Scroll_Item_CommonItem scrollItemCommonItem = value;
                    if (scrollItemCommonItem.uiTransform != null)
                    {
                        scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                    }
                }
            }
        }

        public static void UpdateLockList(this DlgJiaYuanWarehouse self, int page)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int cangkuNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.JianYuanCangKu);
            for (int i = 0; i < self.LockList.Count; i++)
            {
                self.LockList[i].SetActive(cangkuNumber - 1 < i);
                self.NoLockList[i].SetActive(cangkuNumber - 1 >= i && i != page);
            }
        }
    }
}