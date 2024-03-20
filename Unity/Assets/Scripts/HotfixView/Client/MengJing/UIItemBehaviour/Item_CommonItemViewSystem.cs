
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EntitySystemOf(typeof (Scroll_Item_CommonItem))]
	public static partial class Scroll_Item_CommonItemSystem
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_CommonItem self)
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_CommonItem self)
		{
			self.DestroyWidget();
		}

		public static void Refresh(this Scroll_Item_CommonItem self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum,
		Action<BagInfo> onClickAction = null)
		{
			self.ES_CommonItem.Refresh(bagInfo, itemOperateEnum, onClickAction);
		}

		public static void UpdateSelectStatus(this Scroll_Item_CommonItem self, BagInfo bagInfo)
		{
			self.ES_CommonItem.UpdateSelectStatus(bagInfo);
		}
	}
}
