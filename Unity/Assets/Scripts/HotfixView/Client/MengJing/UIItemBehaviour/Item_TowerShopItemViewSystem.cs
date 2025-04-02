
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_TowerShopItem))]
	[EntitySystemOf(typeof(Scroll_Item_TowerShopItem))]
	public static partial class Scroll_Item_TowerShopItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TowerShopItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TowerShopItem self )
		{
			self.DestroyWidget();
		}
		
		public static async ETTask OnBuyBtn(this Scroll_Item_TowerShopItem self)
        {
            long glod = self.Root().GetComponent<BagComponentC>()
                    .GetItemNumber(StoreSellConfigCategory.Instance.Get(self.StoreSellConfigId).SellType);
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(self.StoreSellConfigId);

            if (glod < storeSellConfig.SellValue)
            {
                FlyTipComponent.Instance.ShowFlyTip("货币不足！");
                return;
            }

            await BagClientNetHelper.RquestStoreBuy(self.Root(), self.StoreSellConfigId, 1);

            self.GetParent<ES_TowerShop>().UpdateInfo();
        }

        public static void OnUpdateUI(this Scroll_Item_TowerShopItem self, int id)
        {
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(id);
            self.StoreSellConfigId = storeSellConfig.Id;
            self.E_ButtonBuyButton.AddListener(() => { self.OnBuyBtn().Coroutine(); });

            self.E_Text_valueText.text = storeSellConfig.SellValue.ToString();

            self.ES_CommonItem.UseTextColor = true;
            self.ES_CommonItem.UpdateItem(new() { ItemID = storeSellConfig.SellItemID }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemQualityImage.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            self.ES_CommonItem.E_ItemNameText.GetComponent<Outline>().effectColor = FunctionUI.QualityReturnColor(ItemConfigCategory.Instance.Get(storeSellConfig.SellItemID).ItemQuality);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(storeSellConfig.SellType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_goldImage.sprite = sp;
        }
	}
}
