using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_DlgJiaYuanTreasureMapStorageRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanTreasureMapStorage>()?.OnUpdateUI();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgJiaYuanTreasureMapStorage))]
    public static class DlgJiaYuanTreasureMapStorageSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanTreasureMapStorage self)
        {
            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.View.E_TakeOutAllButton.AddListenerAsync(self.OnTakeOutAllButton);
            self.View.E_OneKeyButton.AddListenerAsync(self.OnOneKeyButton);

            self.View.E_BagItems1LoopVerticalScrollRect.AddItemRefreshListener(self.OnHouseItemsRefresh);
            self.View.E_BagItems2LoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
        }

        public static void ShowWindow(this DlgJiaYuanTreasureMapStorage self, Entity contextData = null)
        {
            self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        private static void OnItemTypeSet(this DlgJiaYuanTreasureMapStorage self, int index)
        {
            self.UpdateStorage();
            self.UpdateBagList();
        }

        public static async ETTask OnTakeOutAllButton(this DlgJiaYuanTreasureMapStorage self)
        {
            await BagClientNetHelper.RquestTakeOutAll(self.Root(),
                self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanTreasureMapStorage1);
        }

        public static async ETTask OnOneKeyButton(this DlgJiaYuanTreasureMapStorage self)
        {
            await JiaYuanNetHelper.JiaYuanStoreRequest(self.Root(),
                self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanTreasureMapStorage1);
        }

        private static void OnHouseItemsRefresh(this DlgJiaYuanTreasureMapStorage self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemHouseItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemHouseItems[index].BindTrans(transform);

            if (index < self.ShowHouseBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowHouseBagInfos[index], ItemOperateEnum.Cangku, null,
                    self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanTreasureMapStorage1);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }
        }

        public static void UpdateStorage(this DlgJiaYuanTreasureMapStorage self)
        {
            int curindex = self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex();

            int storageNumber = GlobalValueConfigCategory.Instance.HourseInitCapacity;
            self.ShowHouseBagInfos = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(curindex + ItemLocType.JianYuanTreasureMapStorage1);

            self.AddUIScrollItems(ref self.ScrollItemHouseItems, storageNumber);
            self.View.E_BagItems1LoopVerticalScrollRect.SetVisible(true, storageNumber);
        }

        private static void OnBagItemsRefresh(this DlgJiaYuanTreasureMapStorage self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemBagItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemBagItems[index].BindTrans(transform);

            if (index < self.ShowBagBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowBagBagInfos[index], ItemOperateEnum.CangkuBag, null,
                    self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() + (int)ItemLocType.JianYuanTreasureMapStorage1);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.None);
            }
        }

        public static void UpdateBagList(this DlgJiaYuanTreasureMapStorage self)
        {
            int bagcellNumber = self.Root().GetComponent<BagComponentC>().GetBagTotalCell(ItemLocType.ItemLocBag);

            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemLocBag);

            if (self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() == 0)
            {
                self.ShowBagBagInfos = ItemHelper.GetTreasureMapList(bagInfos);
            }
            else if (self.View.E_ItemTypeSetToggleGroup.GetCurrentIndex() == 1)
            {
                self.ShowBagBagInfos = ItemHelper.GetTreasureMapList2(bagInfos);
            }

            self.AddUIScrollItems(ref self.ScrollItemBagItems, bagcellNumber);
            self.View.E_BagItems2LoopVerticalScrollRect.SetVisible(true, bagcellNumber);
        }

        public static void OnUpdateUI(this DlgJiaYuanTreasureMapStorage self)
        {
            if (self.ScrollItemHouseItems == null)
            {
                return;
            }

            if (self.ScrollItemHouseItems.Count < GlobalValueConfigCategory.Instance.HourseInitCapacity)
            {
                return;
            }

            self.UpdateStorage();
            self.UpdateBagList();
        }
    }
}
