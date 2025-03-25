
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
			self.E_ButtonBuyButton.AddListener(self.OnButtonBuy().Coroutine);

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
		
		public static async ETTask OnButtonBuy(this Scroll_Item_TaskShopItem self)
		{
			await BagClientNetHelper.RquestStoreBuy(self.Root(), self.StoreSellConfig.Id, 0);
		}
	}
}
