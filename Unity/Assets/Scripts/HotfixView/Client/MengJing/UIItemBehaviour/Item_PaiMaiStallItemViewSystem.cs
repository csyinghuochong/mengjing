
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[FriendOf(typeof(Scroll_Item_PaiMaiStallItem))]
	[EntitySystemOf(typeof(Scroll_Item_PaiMaiStallItem))]
	public static partial class Scroll_Item_PaiMaiStallItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PaiMaiStallItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PaiMaiStallItem self )
		{
			self.DestroyWidget();
		}
		
		public static  void OnUpdateUI(this Scroll_Item_PaiMaiStallItem self, PaiMaiItemInfo paiMaiItemInfo)
		{
			self.PaiMaiItemInfo = paiMaiItemInfo;
			self.E_ImageButtonButton.AddListener(() => {  self.ClickHandler?.Invoke(self.PaiMaiItemInfo);  });
			
			ItemInfo ItemInfo = new ItemInfo();
			ItemInfo.FromMessage(paiMaiItemInfo.BagInfo);
			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
			self.E_TextNameText.text = itemConfig.ItemName;
			self.E_TextPriceText.text = paiMaiItemInfo.Price.ToString();
			self.ES_CommonItem.UpdateItem(ItemInfo, ItemOperateEnum.None);
		}
		
		public static void SetSelected(this Scroll_Item_PaiMaiStallItem self, long paimaiId )
		{
			self.E_ImageSelectImage.gameObject.SetActive(paimaiId == self.PaiMaiItemInfo.Id);
		}

		public static void SetClickHandler(this Scroll_Item_PaiMaiStallItem self, Action<PaiMaiItemInfo> action)
		{
			self.ClickHandler = action;
		}
	}
}
