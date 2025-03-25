
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_TaskShopItem))]
	[FriendOf(typeof(Scroll_Item_BattleShopItem))]
	[EntitySystemOf(typeof(Scroll_Item_TaskShopItem))]
	public static partial class Scroll_Item_TaskShopItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TaskShopItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TaskShopItem self )
		{
			self.DestroyWidget();
		}
		

		public static void OnUpdateData(this Scroll_Item_TaskShopItem self, StoreSellConfig storeSellConfig)
		{
			self.StoreSellConfigId = storeSellConfig.Id;
			self.E_ButtonBuyButton.AddListener(()=>
			{
				BagClientNetHelper.RquestStoreBuy(self.Root(), self.StoreSellConfigId, 1).Coroutine();
			});
			
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
