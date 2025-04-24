
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetChouKaItem))]
	public static partial class Scroll_Item_PetChouKaItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetChouKaItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetChouKaItem self )
		{
			self.DestroyWidget();
		}
		
		public static void Refresh(this Scroll_Item_PetChouKaItem self, ItemInfo bagInfo)
		{
			self.Baginfo = bagInfo;
			
			ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
			ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
			
			self.E_ItemQualityImage.overrideSprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality)));
			
			self.E_ItemIconImage.overrideSprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
			
			self.E_ItemNumText.text = ItemViewHelp.ReturnNumStr(bagInfo.ItemNum);
			
			self.E_ItemClickButton.AddListener(self.OnClickUIItem);
			
			self.E_ItemNameText.text = itemConfig.ItemName;
		}

		public static void OnClickUIItem(this Scroll_Item_PetChouKaItem self)
		{
			EventSystem.Instance.Publish(self.Root(),
				new ShowItemTips()
				{
					BagInfo = self.Baginfo,
					ItemOperateEnum = ItemOperateEnum.None,
					InputPoint = Input.mousePosition,
					Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
					EquipList = new List<ItemInfo>(),
					CurrentHouse = -1
				});
		}
	}
}
