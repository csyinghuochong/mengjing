using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(Scroll_Item_PaiMaiShopItem))]
    [EntitySystemOf(typeof(Scroll_Item_PaiMaiShopItem))]
    public static partial class Scroll_Item_PaiMaiShopItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PaiMaiShopItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PaiMaiShopItem self)
        {
            self.DestroyWidget();
        }

        public static void ImageButton(this Scroll_Item_PaiMaiShopItem self)
        {
            self.ClickHandler(self.PaiMaiId);
        }

        public static void OnClickPaiMaiItem(this Scroll_Item_PaiMaiShopItem self, long paimaiId)
        {
            self.ClickHandler(self.PaiMaiId);
        }

        public static void SetClickHandler(this Scroll_Item_PaiMaiShopItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void SetSelected(this Scroll_Item_PaiMaiShopItem self, int paimaiId)
        {
            self.E_ImageSelectImage.gameObject.SetActive(self.PaiMaiId == paimaiId);
        }

        public static void OnUpdateData(this Scroll_Item_PaiMaiShopItem self, int paimaiId, PaiMaiShopItemInfo shopItemInfo)
        {
            self.E_ImageButtonButton.AddListener(self.ImageButton);

            self.PaiMaiId = paimaiId;
            self.PaiMaiShopItemInfo = shopItemInfo;
            self.ES_CommonItem.uiTransform.localScale = Vector3.one * 0.9f;
            self.ES_CommonItem.ClickItemHandler = (baginfo) => { self.OnClickPaiMaiItem(baginfo.BagInfoID); };

            PaiMaiSellConfig paiMaiSellConfig = PaiMaiSellConfigCategory.Instance.Get(paimaiId);

            ItemInfo bagInfoNew = new ItemInfo();
            bagInfoNew.BagInfoID = paimaiId;
            bagInfoNew.ItemID = paiMaiSellConfig.ItemID;
            self.ES_CommonItem.UpdateItem(bagInfoNew, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemQualityImage.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);

            self.E_Lab_PriceText.text = shopItemInfo.Price.ToString();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiSellConfig.ItemID);
            string qualityiconStr = FunctionUI.BigItemQualiytoPath(itemConfig.ItemQuality);
            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            self.E_Quality_Image.sprite =   self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
            
            string des = "";
            using (zstring.Block())
            {
                if (shopItemInfo.PricePro < 1f)
                {
                    des = zstring.Format("价格下降{0}%", (1 - shopItemInfo.PricePro).ToString("0.0"));
                    self.E_Lab_TipsText.color = new Color(80f / 255f, 110f / 255f, 30f / 255f);
                }

                if (Mathf.Approximately(shopItemInfo.PricePro, 1f))
                {
                    des = "近期价格稳定";
                    self.E_Lab_TipsText.color = new Color(100f / 255f, 100f / 255f, 100f / 255f);
                }

                if (shopItemInfo.PricePro > 1f)
                {
                    des = zstring.Format("价格上涨{0}%", ((shopItemInfo.PricePro - 1) * 100).ToString("0.00"));
                    self.E_Lab_TipsText.color = new Color(137f / 255f, 89f / 255f, 51f / 255f);
                }

                self.E_Lab_TipsText.text = LanguageComponent.Instance.LoadLocalization(des);
            }
        }
    }
}