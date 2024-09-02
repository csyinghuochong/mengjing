using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_BattleShopItem))]
    [EntitySystemOf(typeof (Scroll_Item_BattleShopItem))]
    public static partial class Scroll_Item_BattleShopItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_BattleShopItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_BattleShopItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickImageBg(this Scroll_Item_BattleShopItem self)
        {
            self.ClickHandle(self.StoreSellConfig.Id);
        }

        public static void SetClickHandler(this Scroll_Item_BattleShopItem self, Action<int> action)
        {
            self.ClickHandle = action;
        }

        public static void SetSelected(this Scroll_Item_BattleShopItem self, int sellId)
        {
            self.E_ImageSelectImage.gameObject.SetActive(self.StoreSellConfig.Id == sellId);
        }

        public static void OnUpdateData(this Scroll_Item_BattleShopItem self, StoreSellConfig storeSellConfig)
        {
            self.E_Image_bgButton.AddListener(self.OnClickImageBg);
            self.E_ImageSelectImage.gameObject.SetActive(false);

            self.StoreSellConfig = storeSellConfig;
            int costType = self.StoreSellConfig.SellType;

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, costType.ToString());
            self.E_Image_goldImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            ItemInfo bagInfo = new();
            bagInfo.ItemNum = storeSellConfig.SellItemNum;
            bagInfo.ItemID = storeSellConfig.SellItemID;
            self.E_Text_valueText.text = storeSellConfig.SellValue.ToString();
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            if (bagInfo.ItemNum <= 1)
            {
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            }
        }
    }
}