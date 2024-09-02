using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_WeiJingShopItem))]
    [EntitySystemOf(typeof(Scroll_Item_WeiJingShopItem))]
    public static partial class Scroll_Item_WeiJingShopItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_WeiJingShopItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_WeiJingShopItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickImageBg(this Scroll_Item_WeiJingShopItem self)
        {
            self.ClickHandle(self.StoreSellConfig.Id);
        }

        public static void SetClickHandler(this Scroll_Item_WeiJingShopItem self, Action<int> action)
        {
            self.ClickHandle = action;
        }

        public static void SetSelected(this Scroll_Item_WeiJingShopItem self, int sellId)
        {
            self.E_ImageSelectImage.gameObject.SetActive(self.StoreSellConfig.Id == sellId);
        }

        public static void UpdateLeftNumber(this Scroll_Item_WeiJingShopItem self)
        {
            StoreSellConfig storeSellConfig = self.StoreSellConfig;
            if (self.E_Text_leftText.gameObject != null)
            {
                // if (storeSellConfig.LimitNumber <= 0)
                // {
                //     self.Text_left.text = "";
                // }
                // else
                // {
                //     UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
                //     int left = storeSellConfig.LimitNumber - userInfoComponent.GetStoreBuy(storeSellConfig.Id);
                //     self.Text_left.text = $"限购:{left}";
                // }

                self.E_Text_leftText.text = "限购:...";
            }
        }

        public static void OnUpdateData(this Scroll_Item_WeiJingShopItem self, StoreSellConfig storeSellConfig)
        {
            self.E_Image_bgButton.AddListener(self.OnClickImageBg);
            self.E_ImageSelectImage.gameObject.SetActive(false);

            self.StoreSellConfig = storeSellConfig;
            int costType = self.StoreSellConfig.SellType;
            ItemInfo bagInfoNew = new ItemInfo();
            bagInfoNew.ItemID = costType;
            self.ES_CommonItem_Gold.UpdateItem(bagInfoNew, ItemOperateEnum.None);
            self.ES_CommonItem_Gold.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem_Gold.E_ItemQualityImage.gameObject.SetActive(false);

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemNum = storeSellConfig.SellItemNum;
            bagInfo.ItemID = storeSellConfig.SellItemID;
            self.E_Text_valueText.text = storeSellConfig.SellValue.ToString();
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            if (bagInfo.ItemNum <= 1)
            {
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            }

            self.UpdateLeftNumber();
        }
    }
}