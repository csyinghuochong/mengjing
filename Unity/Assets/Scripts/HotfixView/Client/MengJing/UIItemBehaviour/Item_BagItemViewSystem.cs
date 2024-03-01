using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_BagItem))]
    [EntitySystemOf(typeof (Scroll_Item_BagItem))]
    public static partial class Scroll_Item_BagItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_BagItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_BagItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_BagItem self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
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
                self.E_ItemClickButton.AddListenerWithParam(self.OnShowItemEntryPopUpHandler, bagInfo);

                self.E_BindingImage.gameObject.SetActive(bagInfo.isBinging);
                self.E_ProtectImage.gameObject.SetActive(bagInfo.IsProtect);
            }
            else
            {
                self.E_ItemDiImage.gameObject.SetActive(true);
            }
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips() { BagInfo = bagInfo, ItemOperateEnum = self.ItemOperateEnum, InputPoint = Input.mousePosition });
            EventSystem.Instance.Publish(self.Root(), new ES_RoleBag_UpdateSelect() { BagInfo = bagInfo });
        }

        public static void UpdateSelectStatus(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            self.E_XuanZhongImage.gameObject.SetActive(self.BagInfo.BagInfoID == bagInfo.BagInfoID);
        }
    }
}