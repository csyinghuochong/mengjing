using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (DlgShouJiSelect))]
    public static class DlgShouJiSelectSystem
    {
        public static void RegisterUIEvent(this DlgShouJiSelect self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_ButtonTunShiButton.AddListenerAsync(self.OnButtonTunShiButton);
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
        }

        public static void ShowWindow(this DlgShouJiSelect self, Entity contextData = null)
        {
        }

        public static void OnButtonCloseButton(this DlgShouJiSelect self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ShouJiSelect);
        }
        
        private static void OnBagItemsRefresh(this DlgShouJiSelect self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None, self.OnSelectItem);
            scrollItemCommonItem.E_ItemNameText.gameObject.SetActive(true);
        }

        public static void OnInitUI(this DlgShouJiSelect self, int shouiId, Action updateRedDotAction)
        {
            self.UpdateRedDotAction = updateRedDotAction;

            self.ShouJIId = shouiId;
            ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(shouiId);
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> allInfos = bagComponent.GetBagList();
            self.ShowBagInfos.Clear();
            for (int i = 0; i < allInfos.Count; i++)
            {
                if (allInfos[i].ItemID != shouJiItemConfig.ItemID)
                {
                    continue;
                }

                self.ShowBagInfos.Add(allInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static async ETTask OnButtonTunShiButton(this DlgShouJiSelect self)
        {
            KeyValuePairInt keyValuePairInt = self.Root().GetComponent<ShoujiComponentC>().GetTreasureInfo(self.ShouJIId);

            ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(self.ShouJIId);
            long number = keyValuePairInt != null? keyValuePairInt.Value : 0;
            List<long> selects = self.GetSelectItems();

            if (selects.Count == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择道具！");
                return;
            }

            if (number + selects.Count > shouJiItemConfig.AcitveNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("吞噬数量超出！");
                return;
            }

            long instanceId = self.InstanceId;
            M2C_ShouJiTreasureResponse response = await ShoujiNetHelper.ShouJiTreasure(self.Root(), selects, self.ShouJIId);

            if (instanceId != self.InstanceId)
            {
                return;
            }

            DlgShouJi dlgShouJi = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgShouJi>();
            dlgShouJi.OnShouJiTreasure();

            // 更新被选择道具的红点
            self.UpdateRedDotAction.Invoke();

            FlyTipComponent.Instance.ShowFlyTip("吞噬道具完成。");

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ShouJiSelect);
        }

        public static List<long> GetSelectItems(this DlgShouJiSelect self)
        {
            List<long> ids = new List<long>();
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    if (item.E_XuanZhongImage.gameObject.activeSelf)
                    {
                        ids.Add(item.Baginfo.BagInfoID);
                    }
                }
            }

            return ids;
        }

        public static void OnSelectItem(this DlgShouJiSelect self, ItemInfo bagInfo)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    if (item.Baginfo.BagInfoID == bagInfo.BagInfoID)
                    {
                        bool selected = item.E_XuanZhongImage.gameObject.activeSelf;
                        item.E_XuanZhongImage.gameObject.SetActive(!selected);
                    }
                }
            }
        }
    }
}
