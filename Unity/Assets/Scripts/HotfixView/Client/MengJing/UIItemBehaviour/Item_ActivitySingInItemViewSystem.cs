using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof(Scroll_Item_ActivitySingInItem))]
    public static partial class Scroll_Item_ActivitySingInItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivitySingInItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivitySingInItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_ActivitySingInItem self, ActivityConfig activityConfig, Action<int> action)
        {
            self.ScrollRect = self.uiTransform.parent.parent;
            
            self.E_ItemButtonEventTrigger.triggers.Clear();
            self.E_ItemButtonEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            self.E_ItemButtonEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.OnBeginDrag(pdata as PointerEventData); });
            self.E_ItemButtonEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.OnDraging(pdata as PointerEventData); });
            self.E_ItemButtonEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.OnEndDrag(pdata as PointerEventData); });
            self.E_ItemButtonEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(pdata as PointerEventData); });
            self.E_XuanZhongImage.gameObject.SetActive(false);

            self.ActivityConfig = activityConfig;
            self.ClickHandler = action;

            using (zstring.Block())
            {
                int index = int.Parse(activityConfig.Par_1);
                self.E_DayText.text = zstring.Format("第{0}天", index);
            }

            string[] itemInfo = activityConfig.Par_2.Split(';');
            int itemId = int.Parse(itemInfo[0]);    
            int itemNum = int.Parse(itemInfo[1]);
            ItemConfig itemConfig= ItemConfigCategory.Instance.Get(itemId);     
            self.E_ItemIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
            self.E_ItemNumText.text = itemInfo[1];
            self.ItemInfo = new ItemInfo() { ItemID = itemId, ItemNum = itemNum };
            
            self.UpdateLingQu();
        }

        private static async ETTask ShowTip(this Scroll_Item_ActivitySingInItem self)
        {
            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Time);
            if (self.IsDisposed || self.InstanceId != instanceId || self.IsDrag || self.IsClick)
            {
                return;
            }
            
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = self.ItemInfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<ItemInfo>(),
                    CurrentHouse = -1
                });

            self.IsClick = true;
        }
        
        private static void OnPointerDown(this Scroll_Item_ActivitySingInItem self, PointerEventData data)
        {
            self.ClickTime = TimeHelper.ServerNow();
            self.IsDrag = false;
            self.IsClick = false;

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (!activityComponent.ActivityReceiveIds.Contains(self.ActivityConfig.Id))
            {
                self.ShowTip().Coroutine();
            }
        }
        
        private static void OnBeginDrag(this Scroll_Item_ActivitySingInItem self, PointerEventData pdata)
        {
            self.ScrollRect.GetComponent<ScrollRect>().OnBeginDrag(pdata);
        }

        private static void OnDraging(this Scroll_Item_ActivitySingInItem self, PointerEventData pdata)
        {
            self.IsDrag = true;

            self.ScrollRect.GetComponent<ScrollRect>().OnDrag(pdata);
        }

        private static void OnEndDrag(this Scroll_Item_ActivitySingInItem self, PointerEventData pdata)
        {
            self.ScrollRect.GetComponent<ScrollRect>().OnEndDrag(pdata);
        }
        
        private static void OnPointerUp(this Scroll_Item_ActivitySingInItem self, PointerEventData data)
        {
            if (self.IsDrag == false && TimeHelper.ServerNow() - self.ClickTime <= self.Time && !self.IsClick)
            {
                self.ClickHandler(self.ActivityConfig.Id);
            }
            self.IsClick = true;
        }

        public static void UpdateLingQu(this Scroll_Item_ActivitySingInItem self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            self.E_LingQuImage.gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(self.ActivityConfig.Id));
        }

        public static void SetSignState(this Scroll_Item_ActivitySingInItem self, int curDay)
        {
            self.E_XuanZhongImage.gameObject.SetActive(int.Parse(self.ActivityConfig.Par_1) == curDay);
        }

        public static void SetSelected(this Scroll_Item_ActivitySingInItem self, int activityId)
        {
            self.E_XuanZhongImage.gameObject.SetActive(self.ActivityConfig.Id == activityId);
        }
    }
}