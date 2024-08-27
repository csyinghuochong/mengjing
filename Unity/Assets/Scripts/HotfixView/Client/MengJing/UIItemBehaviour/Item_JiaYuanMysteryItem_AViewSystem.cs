using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanMysteryItem_A))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanMysteryItem_A))]
    public static partial class Scroll_Item_JiaYuanMysteryItem_ASystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanMysteryItem_A self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanMysteryItem_A self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_JiaYuanMysteryItem_A self)
        {
            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(self.MysteryItemInfo.MysteryId);

            // 判断家园等级是否足够
            int jiayuanid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanLv;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(jiayuanid);
            if (mysteryConfig.JiaYuanLv > jiayuanCof.Lv)
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("家园{0}级开启", mysteryConfig.JiaYuanLv));
                }

                return;
            }

            int leftSpace = self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag);
            if (leftSpace < 1)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

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

            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem($"{mysteryConfig.SellType};{mysteryConfig.SellValue}"))
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_HouBiNotEnough);
                return;
            }

            if (self.MysteryItemInfo.ItemNumber < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("请等待下次商店刷新");
                return;
            }

            await JiaYuanNetHelper.JiaYuanMysteryBuyRequest(self.Root(), self.MysteryItemInfo.MysteryId, self.MysteryItemInfo.ProductId);
            self.GetParent<ES_JiaYuanMystery_A>()?.RequestMystery();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanMysteryItem_A self, MysteryItemInfo mysteryItemInfo)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);
            self.E_Text_NumberText.gameObject.SetActive(false);
            self.E_Text_TipText.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemIconImage.material = null;

            MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(mysteryItemInfo.MysteryId);
            self.MysteryItemInfo = mysteryItemInfo;

            // 判断家园等级是否足够
            int jiayuanid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanLv;
            JiaYuanConfig jiayuanCof = JiaYuanConfigCategory.Instance.Get(jiayuanid);
            if (mysteryConfig.JiaYuanLv <= jiayuanCof.Lv)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(mysteryConfig.SellType);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_Image_goldImage.sprite = sp;
                self.E_Image_goldImage.gameObject.SetActive(true);
                self.E_Text_valueText.gameObject.SetActive(true);
                self.E_Text_valueText.text = mysteryConfig.SellValue.ToString();
            }
            else
            {
                self.E_Text_TipText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.E_Text_TipText.text = zstring.Format("家园{0}级开启", mysteryConfig.JiaYuanLv);
                }

                Material mat = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Material>(ABPathHelper.GetMaterialPath("UI_Hui"));
                self.ES_CommonItem.E_ItemIconImage.material = mat;
                self.E_Image_goldImage.gameObject.SetActive(false);
                self.E_Text_valueText.gameObject.SetActive(false);
            }

            self.ES_CommonItem.UpdateItem(new() { ItemID = self.MysteryItemInfo.ItemID }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
        }
    }
}