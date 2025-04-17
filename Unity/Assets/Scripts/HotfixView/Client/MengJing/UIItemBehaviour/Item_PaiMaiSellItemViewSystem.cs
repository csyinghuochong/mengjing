using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PaiMaiSellItem))]
    [EntitySystemOf(typeof(Scroll_Item_PaiMaiSellItem))]
    public static partial class Scroll_Item_PaiMaiSellItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PaiMaiSellItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PaiMaiSellItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this Scroll_Item_PaiMaiSellItem self, long uid)
        {
            self.E_Img_XuanZhongImage.gameObject.SetActive(self.PaiMaiItemInfo.Id == uid);
        }

        public static void OnUpdateUI(this Scroll_Item_PaiMaiSellItem self, PaiMaiItemInfo paiMaiItemInfo)
        {
            self.E_ImageButtonButton.AddListener(self.OnImageButton);
            self.E_Img_XuanZhongImage.gameObject.SetActive(false);

            self.PaiMaiItemInfo = paiMaiItemInfo;

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.FromMessage(paiMaiItemInfo.BagInfo);
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.text = paiMaiItemInfo.BagInfo.ItemNum.ToString();
            self.E_TextPriceText.text = (self.PaiMaiItemInfo.Price * paiMaiItemInfo.BagInfo.ItemNum).ToString();

            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);
            self.E_TextTimeText.text = TimeHelper.ShowTimeDifferenceStr(dateTime, TimeInfo.Instance.ToDateTime(self.PaiMaiItemInfo.SellTime));

            self.E_TextNameText.text = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID).ItemName;

            ItemInfo itemInfo = new ItemInfo();
            itemInfo.FromMessage(self.PaiMaiItemInfo.BagInfo);
            self.ES_CommonItem.Baginfo = itemInfo;
        }

        public static void SetClickHandler(this Scroll_Item_PaiMaiSellItem self, Action<PaiMaiItemInfo> action)
        {
            self.ClickHandler = action;
        }

        public static void OnImageButton(this Scroll_Item_PaiMaiSellItem self)
        {
            self.ClickHandler(self.PaiMaiItemInfo);
        }
    }
}