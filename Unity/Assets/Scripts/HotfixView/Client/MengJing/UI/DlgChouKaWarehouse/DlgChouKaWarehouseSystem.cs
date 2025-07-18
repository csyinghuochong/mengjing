using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_DlgChouKaWarehouseRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgChouKaWarehouse>()?.Refresh();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgChouKaWarehouse))]
    public static class DlgChouKaWarehouseSystem
    {
        public static void RegisterUIEvent(this DlgChouKaWarehouse self)
        {
            self.View.E_ButtonTakeOutAllButton.AddListenerAsync(self.OnButtonTakeOutAllButton);
            self.View.E_ButtonSellButton.AddListener(self.OnButtonSellButton);
            self.View.E_ButtonZhengLiButton.AddListenerAsync(self.OnButtonZhengLiButton);

            self.View.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.View.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);

            self.Refresh();
        }

        public static void ShowWindow(this DlgChouKaWarehouse self, Entity contextData = null)
        {
        }

        private static void OnHouseItemsRefresh(this DlgChouKaWarehouse self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemHouseItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowHouseBagInfos.Count ? self.ShowHouseBagInfos[index] : null, ItemOperateEnum.Cangku,
                self.UpdateHouseSelect, (int)ItemLocType.ChouKaWarehouse);
        }

        private static void OnBagItemsRefresh(this DlgChouKaWarehouse self, Transform transform, int index)
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
                self.UpdateBagSelect, (int)ItemLocType.ChouKaWarehouse);
        }

        private static void UpdateHouseSelect(this DlgChouKaWarehouse self, ItemInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemHouseItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }

        private static void UpdateBagSelect(this DlgChouKaWarehouse self, ItemInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemBagItems.Keys.Count - 1; i++)
            {
                if (i >=  self.ScrollItemHouseItems.Count)
                {
                    break;
                }

                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }

        public static async ETTask OnButtonTakeOutAllButton(this DlgChouKaWarehouse self)
        {
            await BagClientNetHelper.RquestTakeOutAll(self.Root(), (int)ItemLocType.ChouKaWarehouse);
        }

        public static void OnButtonSellButton(this DlgChouKaWarehouse self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "一键出售", "是否一键出售低品质装备和宝石，出售品质可以在设置中进行选择。",
                () => { BagClientNetHelper.RequestOneSell(self.Root(), ItemLocType.ChouKaWarehouse).Coroutine(); }, null).Coroutine();
        }

        public static async ETTask OnButtonZhengLiButton(this DlgChouKaWarehouse self)
        {
            await BagClientNetHelper.RequestSortByLoc(self.Root(), ItemLocType.ChouKaWarehouse);
            self.RefreshHouse();
        }

        public static void Refresh(this DlgChouKaWarehouse self)
        {
            self.RefreshHouse();
            self.RefreshBag();
        }

        private static void RefreshHouse(this DlgChouKaWarehouse self)
        {
            self.ShowHouseBagInfos.Clear();
            foreach (ItemInfo itemInfo in self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ChouKaWarehouse))
            {
                self.ShowHouseBagInfos.Add(itemInfo);
            }

            // 上限100
            int storageNumber = 100;
            self.AddUIScrollItems(ref self.ScrollItemHouseItems, storageNumber);
            self.View.E_BagItems1LoopVerticalScrollRect.SetVisible(true, storageNumber);
        }

        private static void RefreshBag(this DlgChouKaWarehouse self)
        {
            self.ShowBagBagInfos.Clear();
            foreach (ItemInfo itemInfo in self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemLocBag))
            {
                self.ShowBagBagInfos.Add(itemInfo);
            }

            int bagcellNumber = self.Root().GetComponent<BagComponentC>().GetBagTotalCell(ItemLocType.ItemLocBag);
            self.AddUIScrollItems(ref self.ScrollItemBagItems, bagcellNumber);
            self.View.E_BagItems2LoopVerticalScrollRect.SetVisible(true, bagcellNumber);
        }
    }
}
