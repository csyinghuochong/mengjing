using System;
using UnityEngine;

namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_TaskRewardItem))]
	[FriendOf(typeof(Scroll_Item_TaskRewardItem))]
	public static partial class Scroll_Item_TaskRewardItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TaskRewardItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TaskRewardItem self )
		{
			self.DestroyWidget();
		}
		
		public static void Refresh(this Scroll_Item_TaskRewardItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum,
		Action<ItemInfo> onClickAction = null, int currentHouse = -1)
		{
			Transform UIParticle = self.uiTransform.Find("UIParticle");
			if (UIParticle != null)
			{
				UIParticle.gameObject.SetActive(false);
			}
			self.ES_CommonItem.UpdateItem(bagInfo, itemOperateEnum);
			self.ES_CommonItem.SetClickHandler(onClickAction);
			self.ES_CommonItem.SetCurrentHouse(currentHouse);
		}
	}
}
