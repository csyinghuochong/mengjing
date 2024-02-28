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
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
        }

        public static void ShowWindow(this DlgRoleBag self, Entity contextData = null)
        {
            self.View.E_AllToggle.IsSelected(true);
        }

        private static void OnBagItemsRefresh(this DlgRoleBag self, Transform transform, int index)
        {
            Scroll_Item_BagItem scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemBagItem.Refresh(self.ShowBagInfos[index]);
        }

        private static void OnItemTypeSet(this DlgRoleBag self, int index)
        {
            Log.Debug($"按下Toggle：{index}");
            self.Root().GetComponent<FlyTipComponent>().SpawnFlyTip($"按下Toggle：{index}");

            self.SetToggleShow(self.View.E_AllToggle.gameObject, index == 0);
            self.SetToggleShow(self.View.E_EquipToggle.gameObject, index == 1);
            self.SetToggleShow(self.View.E_CaiLiaoToggle.gameObject, index == 2);
            self.SetToggleShow(self.View.E_XiaoHaoToggle.gameObject, index == 3);

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
            self.RefreshBagItems();
        }

        private static void RefreshBagItems(this DlgRoleBag self)
        {
            BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();

            self.ShowBagInfos.Clear();
            foreach (BagInfo bagInfo in bagComponentClient.GetItemsByItem((int)ItemLocType.ItemLocBag))
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (self.CurrentItemType == 0 || self.CurrentItemType == itemConfig.ItemType)
                {
                    self.ShowBagInfos.Add(bagInfo);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemBagItems, self.ShowBagInfos.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }
    }
}