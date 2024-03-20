using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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

        public static void Refresh(this ES_CommonItem self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum,
        Action<BagInfo> onClickAction = null)
        {
            self.BagInfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;

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
                self.E_ItemClickButton.AddListener(() =>
                {
                    EventSystem.Instance.Publish(self.Root(),
                        new ShowItemTips()
                        {
                            BagInfo = bagInfo,
                            ItemOperateEnum = self.ItemOperateEnum,
                            InputPoint = Input.mousePosition,
                            EquipList = new List<BagInfo>()
                        });
                    onClickAction?.Invoke(self.BagInfo);
                });

                self.E_BindingImage.gameObject.SetActive(bagInfo.isBinging);
                self.E_ProtectImage.gameObject.SetActive(bagInfo.IsProtect);
            }
            else
            {
                self.E_ItemDiImage.gameObject.SetActive(true);
            }
        }

        public static void UpdateSelectStatus(this ES_CommonItem self, BagInfo bagInfo)
        {
            if (null == bagInfo || null == self.BagInfo)
            {
                return;
            }
            
            self.E_XuanZhongImage.gameObject.SetActive(self.BagInfo.BagInfoID == bagInfo.BagInfoID);
        }
    }
}