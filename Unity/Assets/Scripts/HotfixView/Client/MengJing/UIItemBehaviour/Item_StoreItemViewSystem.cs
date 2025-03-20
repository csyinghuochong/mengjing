using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_StoreItem))]
    [EntitySystemOf(typeof (Scroll_Item_StoreItem))]
    public static partial class Scroll_Item_StoreItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_StoreItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_StoreItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnClickBuyButton(this Scroll_Item_StoreItem self)
        {
            await BagClientNetHelper.RquestStoreBuy(self.Root(), self.StoreSellConfig.Id, 1);
        }

        public static void OnUpdateData(this Scroll_Item_StoreItem self, StoreSellConfig storeSellConfig)
        {
            self.StoreSellConfig = storeSellConfig;
            int costType = self.StoreSellConfig.SellType;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(costType);
            self.E_Image_goldImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemNum = storeSellConfig.SellItemNum;
            bagInfo.ItemID = storeSellConfig.SellItemID;
            self.E_Text_valueText.text = storeSellConfig.SellValue.ToString();
            self.ES_CommonItem.UseTextColor = true;
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            if (bagInfo.ItemNum <= 1)
            {
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            }

            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            
            
            string qualityiconStr = FunctionUI.BigItemQualiytoPath(itemConfig.ItemQuality);
            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
            self.E_Image_bg.sprite = sp1;
            
            self.ES_CommonItem.E_ItemQualityImage.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemNameText.GetComponent<Outline>().effectColor = FunctionUI.QualityReturnColor(itemConfig.ItemQuality);

            self.E_ButtonBuyButton.AddListenerAsync(self.OnClickBuyButton);
        }
    }
}