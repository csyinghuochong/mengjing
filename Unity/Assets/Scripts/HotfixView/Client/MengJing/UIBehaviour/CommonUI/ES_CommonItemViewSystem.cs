using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [EntitySystemOf(typeof (ES_CommonItem))]
    [FriendOfAttribute(typeof (ES_CommonItem))]
    public static partial class ES_CommonItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CommonItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_CommonItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this ES_CommonItem self, BagInfo bagInfo)
        {
            if (null == bagInfo || null == self.Baginfo)
            {
                return;
            }

            self.E_XuanZhongImage.gameObject.SetActive(self.Baginfo.BagInfoID == bagInfo.BagInfoID);
        }

        public static void BeginDrag(this ES_CommonItem self, PointerEventData pdata)
        {
            self.BeginDragHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void Draging(this ES_CommonItem self, PointerEventData pdata)
        {
            self.DragingHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void EndDrag(this ES_CommonItem self, PointerEventData pdata)
        {
            self.EndDragHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void PointerDown(this ES_CommonItem self, PointerEventData pdata)
        {
            self.PointerDownHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void PointerUp(this ES_CommonItem self, PointerEventData pdata)
        {
            self.PointerUpHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void SetEventTrigger(this ES_CommonItem self, bool value = true)
        {
            self.E_ItemDragEventTrigger.gameObject.SetActive(value);

            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
        }

        public static void SetClickHandler(this ES_CommonItem self, Action<BagInfo> action)
        {
            self.ClickItemHandler = action;
        }

        public static void OnClickUIItem(this ES_CommonItem self)
        {
            if (self.Baginfo == null)
            {
                return;
            }

            if (self.ClickItemHandler != null)
            {
                self.ClickItemHandler(self.Baginfo);
            }

            if (self.ItemOperateEnum != ItemOperateEnum.ItemXiLian && self.ShowTip)
            {
                EventSystem.Instance.Publish(self.Root(),
                    new ShowItemTips()
                    {
                        BagInfo = self.Baginfo,
                        ItemOperateEnum = self.ItemOperateEnum,
                        InputPoint = Input.mousePosition,
                        Occ = self.Root().GetComponent<UserInfoComponentClient>().UserInfo.Occ,
                        EquipList = new List<BagInfo>()
                    });
            }
        }

        public static void HideItemName(this ES_CommonItem self)
        {
            self.E_ItemNameText.gameObject.SetActive(false);
        }

        public static void ShowIcon(this ES_CommonItem self, string itemIcon)
        {
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;
        }

        public static void UpdateUnLock(this ES_CommonItem self, bool actived)
        {
            self.E_LockImage.gameObject.SetActive(!actived);
        }

        public static void UpdateItem(this ES_CommonItem self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
            self.Baginfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.ShowTip = true;

            self.E_ItemDiImage.gameObject.SetActive(false);
            self.E_ItemClickButton.gameObject.SetActive(false);
            self.E_ItemDragButton.gameObject.SetActive(false);
            self.E_ItemQualityImage.gameObject.SetActive(false);
            self.E_ItemIconImage.gameObject.SetActive(false);
            self.E_ItemNumText.gameObject.SetActive(false);
            self.E_ItemNameText.gameObject.SetActive(false);
            self.E_XuanZhongImage.gameObject.SetActive(false);
            self.E_BindingImage.gameObject.SetActive(false);
            self.E_UpTipImage.gameObject.SetActive(false);
            self.E_ProtectImage.gameObject.SetActive(false);
            self.E_LockButton.gameObject.SetActive(false);

            if (bagInfo != null)
            {
                ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

                self.E_ItemQualityImage.gameObject.SetActive(true);
                self.E_ItemQualityImage.overrideSprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(
                    ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality)));

                self.E_ItemIconImage.gameObject.SetActive(true);
                self.E_ItemIconImage.overrideSprite =
                        resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));

                self.E_ItemNumText.gameObject.SetActive(true);
                self.E_ItemNumText.text = bagInfo.ItemNum.ToString();

                self.E_ItemClickButton.gameObject.SetActive(true);
                self.E_ItemClickButton.AddListener(self.OnClickUIItem);

                self.E_BindingImage.gameObject.SetActive(bagInfo.isBinging);
                self.E_ProtectImage.gameObject.SetActive(bagInfo.IsProtect);
            }
            else
            {
                self.E_ItemDiImage.gameObject.SetActive(true);
            }
        }
    }
}