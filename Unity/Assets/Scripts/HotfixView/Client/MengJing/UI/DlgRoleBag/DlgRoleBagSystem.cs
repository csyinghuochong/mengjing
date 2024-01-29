using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRoleBag))]
    public static class DlgRoleBagSystem
    {
        public static void RegisterUIEvent(this DlgRoleBag self)
        {
            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnLoopItemRefreshHandler);
        }

        public static void ShowWindow(this DlgRoleBag self, Entity contextData = null)
        {
            self.View.E_AllToggle.IsSelected(true);
        }

        private static void OnLoopItemRefreshHandler(this DlgRoleBag self, Transform transform, int index)
        {
            List<BagInfo> allBagInfos = new List<BagInfo>();
            List<BagInfo> bagInfos = new List<BagInfo>();
            foreach (BagInfo bagInfo in allBagInfos)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (self.CurrentItemType == 0 || self.CurrentItemType == itemConfig.ItemType)
                {
                    bagInfos.Add(bagInfo);
                }
            }

            Scroll_Item_BagItem scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);

            scrollItemBagItem.Refresh(index < bagInfos.Count? bagInfos[index].BagInfoID : 0);
        }

        private static void OnItemTypeSet(this DlgRoleBag self, int index)
        {
            Log.Debug($"按下Toggle：{index}");

            self.SetToggleShow(self.View.E_AllToggle.gameObject, index == 0);
            self.SetToggleShow(self.View.E_EquipToggle.gameObject, index == 1);
            self.SetToggleShow(self.View.E_CaiLiaoToggle.gameObject, index == 3);
            self.SetToggleShow(self.View.E_XiaoHaoToggle.gameObject, index == 4);

            self.CurrentItemType = index;
            self.Refresh();
        }

        private static void SetToggleShow(this DlgRoleBag self, GameObject gameObject, bool isShow)
        {
            gameObject.transform.Find("Background/XuanZhong").gameObject.SetActive(isShow);
            gameObject.transform.Find("Background/WeiXuanZhong").gameObject.SetActive(!isShow);
        }

        private static void Refresh(this DlgRoleBag self)
        {
            self.RefreshItems();
        }

        private static void RefreshItems(this DlgRoleBag self)
        {
            self.AddUIScrollItems(ref self.ScrollItemBagItems, 100);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, 100);
        }
    }
}