using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_BagItemUpdate_DlgJiaYuanBagRefresh: AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanBag>()?.OnUpdateUI();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (DlgJiaYuanBag))]
    public static class DlgJiaYuanBagSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanBag self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);

            self.View.E_Btn_PlanButton.AddListenerAsync(self.OnBtn_PlanButton);
            self.OnUpdateUI();
        }

        public static void ShowWindow(this DlgJiaYuanBag self, Entity contextData = null)
        {
        }

        public static void OnButtonCloseButton(this DlgJiaYuanBag self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanBag);
        }
        
        public static async ETTask OnBtn_PlanButton(this DlgJiaYuanBag self)
        {
            Scene curScene = self.Root().CurrentScene();
            if (self.BagInfo == null)
            {
                return;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.JiaYuan)
            {
                return;
            }

            DlgJiaYuanMain dlgJiaYuanMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();

            Unit unit = JiaYuanHelper.GetUnitByCellIndex(curScene, dlgJiaYuanMain.CellIndex);
            if (unit != null)
            {
                FlyTipComponent.Instance.ShowFlyTip("当前土地有植物！");
                return;
            }

            try
            {
                await JiaYuanNetHelper.JiaYuanPlantRequest(self.Root(), dlgJiaYuanMain.CellIndex, self.BagInfo.ItemID);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return;
            }

            if (self.IsDisposed)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanBag);
        }

        private static void OnBagItemsRefresh(this DlgJiaYuanBag self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            if (index < self.ShowBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.JianYuanBag, self.OnClickHandler);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.Bag);
            }
        }

        public static void OnUpdateUI(this DlgJiaYuanBag self)
        {
            int maxCapacity = GlobalValueConfigCategory.Instance.BagInitCapacity;

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetItemsByType(2);
            self.ShowBagInfos.Clear();

            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType != 2 || itemConfig.ItemSubType != 101)
                {
                    continue;
                }

                self.ShowBagInfos.Add(bagInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count > maxCapacity? self.ShowBagInfos.Count : maxCapacity);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count > maxCapacity? self.ShowBagInfos.Count : maxCapacity);
        }

        public static void OnClickHandler(this DlgJiaYuanBag self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }
        }
    }
}
