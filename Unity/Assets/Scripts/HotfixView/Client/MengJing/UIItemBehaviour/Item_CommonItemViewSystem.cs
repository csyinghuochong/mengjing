using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(Scroll_Item_CommonItem))]
    public static partial class Scroll_Item_CommonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CommonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CommonItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CommonItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum,
        Action<ItemInfo> onClickAction = null, int currentHouse = -1)
        {
            Transform UIParticle = self.uiTransform.Find("UIParticle");
            if (UIParticle != null)
            {
                UIParticle.gameObject.SetActive(false);
            }

            self.UpdateItem(bagInfo, itemOperateEnum);
            self.SetClickHandler(onClickAction);
            self.SetCurrentHouse(currentHouse);
        }

        public static void SetSelected(this Scroll_Item_CommonItem self, ItemInfo bagInfo)
        {
            if (null == bagInfo || null == self.Baginfo)
            {
                return;
            }

            self.E_XuanZhongImage.gameObject.SetActive(self.Baginfo.BagInfoID == bagInfo.BagInfoID);
        }

        public static void BeginDrag(this Scroll_Item_CommonItem self, PointerEventData pdata)
        {
            self.BeginDragHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void Draging(this Scroll_Item_CommonItem self, PointerEventData pdata)
        {
            self.DragingHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void EndDrag(this Scroll_Item_CommonItem self, PointerEventData pdata)
        {
            self.EndDragHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void PointerDown(this Scroll_Item_CommonItem self, PointerEventData pdata)
        {
            self.PointerDownHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void PointerUp(this Scroll_Item_CommonItem self, PointerEventData pdata)
        {
            self.PointerUpHandler?.Invoke(self.Baginfo, pdata);
        }

        public static void SetEventTrigger(this Scroll_Item_CommonItem self, bool value = true)
        {
            self.E_ItemDragEventTrigger.gameObject.SetActive(value);

            self.E_ItemDragEventTrigger.triggers.Clear();
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_ItemDragEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
        }

        public static void SetClickHandler(this Scroll_Item_CommonItem self, Action<ItemInfo> action)
        {
            self.ClickItemHandler = action;
        }

        public static void OnClickUIItem(this Scroll_Item_CommonItem self)
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
                        Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                        EquipList = new List<ItemInfo>(),
                        CurrentHouse = self.CurrentHouse
                    });
            }
        }

        public static void HideItemName(this Scroll_Item_CommonItem self)
        {
            self.E_ItemNameText.gameObject.SetActive(false);
        }

        public static void HideItemNumber(this Scroll_Item_CommonItem self)
        {
            self.E_ItemNumText.gameObject.SetActive(false);
        }

        public static void ShowIcon(this Scroll_Item_CommonItem self, string itemIcon)
        {
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;
        }

        public static void UpdateUnLock(this Scroll_Item_CommonItem self, bool actived)
        {
            self.E_LockImage.gameObject.SetActive(!actived);
        }

        public static void SetCurrentHouse(this Scroll_Item_CommonItem self, int currentHouse)
        {
            self.CurrentHouse = currentHouse;
        }

        public static void ShowUIEffect(this Scroll_Item_CommonItem self, int effectid)
        {
            Transform UIParticle = self.uiTransform.Find("UIParticle");
            if (UIParticle == null)
            {
                return;
            }

            float scale = 70;
            string path = string.Empty;

            if (effectid != 41100001)
            {
                EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effectid);
                path = StringBuilderHelper.GetEffectPathByConfig(effectConfig);
                scale = (float)effectConfig.Scale;
            }
            else
            {
                if (self.Baginfo == null)
                {
                    return;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.Baginfo.ItemID);
                if (itemConfig.ItemQuality < 2)
                {
                    return;
                }

                using (zstring.Block())
                {
                    path = zstring.Format("Assets/Bundles/Effect/UIEffect/UIEffect_Quaity_{0}", itemConfig.ItemQuality);
                }
            }

            UIParticle.gameObject.SetActive(true);
            CommonViewHelper.DestoryChild(UIParticle.gameObject);
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, UIParticle, true);
            go.transform.localPosition = Vector3.zero;

            Coffee.UIExtensions.UIParticle uiParticle = UIParticle.GetComponent<Coffee.UIExtensions.UIParticle>();
            if (uiParticle != null)
            {
                //uiParticle.enabled = false;
                //uiParticle.enabled = true;
                uiParticle.particles.Clear();
                uiParticle.RefreshParticles();
                uiParticle.scale = scale;
            }
            //uiParticle = uiParticle.gameObject.AddComponent<Coffee.UIExtensions.UIParticle>();
        }

        public static void UpdateItem(this Scroll_Item_CommonItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
            self.Baginfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.ShowTip = true;
            self.CurrentHouse = -1;

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
            self.E_ImageReceivedImage.gameObject.SetActive(false);

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
                self.E_ItemNumText.text = ItemViewHelp.ReturnNumStr(bagInfo.ItemNum);

                self.E_ItemClickButton.gameObject.SetActive(true);
                self.E_ItemClickButton.AddListener(self.OnClickUIItem);

                //self.E_ItemNameText.gameObject.SetActive(true);
                self.E_ItemNameText.text = itemConfig.ItemName;
                self.ItemID = bagInfo.ItemID;
                if (itemOperateEnum == ItemOperateEnum.ItemXiLian)
                {
                    self.E_ItemDragButton.gameObject.SetActive(true);
                    self.E_ItemDragButton.AddListener(self.OnClickUIItem);
                    self.SetEventTrigger();
                }
                else
                {
                    self.SetEventTrigger(false);
                }

                if (!self.UseTextColor)
                {
                    self.E_ItemNameText.color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);
                }

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