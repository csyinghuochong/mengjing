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

        public static void Refresh(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.E_ItemNumText.text = bagInfo.ItemNum.ToString();
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            self.E_ItemIconImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            self.E_ItemQualityImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
            self.E_ItemClickButton.AddListenerWithParam(self.OnShowItemEntryPopUpHandler, bagInfo);
        }

        public static void OnShowItemEntryPopUpHandler(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips() { BagInfo = bagInfo, ItemOperateEnum = ItemOperateEnum.None, InputPoint = Input.mousePosition });
            EventSystem.Instance.Publish(self.Root(), new ES_RoleBag_UpdateSelect() { BagInfo = bagInfo });
        }

        public static void UpdateSelectStatus(this Scroll_Item_BagItem self, BagInfo bagInfo)
        {
            self.E_XuanZhongImage.gameObject.SetActive(self.BagInfo.BagInfoID == bagInfo.BagInfoID);
        }
    }
}