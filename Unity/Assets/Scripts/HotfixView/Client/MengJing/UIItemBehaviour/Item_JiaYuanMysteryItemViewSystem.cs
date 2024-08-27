using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanMysteryItem))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanMysteryItem))]
    public static partial class Scroll_Item_JiaYuanMysteryItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanMysteryItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanMysteryItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_JiaYuanMysteryItem self)
        {
            int leftSpace = self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag);
            if (leftSpace < 1)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(self.MysteryItemInfo.MysteryId);
            int sellValue = mysteryConfig.SellValue;

            if (mysteryConfig.SellType == 1 && self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold < sellValue)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_GoldNotEnoughError);
                return;
            }

            if (mysteryConfig.SellType == 3 && self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond < sellValue)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                return;
            }

            using (zstring.Block())
            {
                if (!self.Root().GetComponent<BagComponentC>()
                            .CheckNeedItem(zstring.Format("{0};{1}", mysteryConfig.SellType, mysteryConfig.SellValue)))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_HouBiNotEnough);
                    return;
                }
            }

            await JiaYuanNetHelper.JiaYuanMysteryBuyRequest(self.Root(), self.MysteryItemInfo.MysteryId, self.MysteryItemInfo.ProductId);
            self.GetParent<ES_JiaYuanMystery_B>()?.RequestMystery().Coroutine();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanMysteryItem self, MysteryItemInfo mysteryItemInfo)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryItemInfo.MysteryId);
            self.MysteryItemInfo = mysteryItemInfo;
            using (zstring.Block())
            {
                self.E_Text_NumberText.text = zstring.Format("剩余 {0}件", mysteryItemInfo.ItemNumber);
            }

            self.E_Text_valueText.text = mysteryConfig.SellValue.ToString();

            self.ES_CommonItem.UpdateItem(new() { ItemID = self.MysteryItemInfo.ItemID }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(mysteryConfig.SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_goldImage.sprite = sp;
        }
    }
}