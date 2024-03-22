
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_CommonCostItem))]
	public static partial class Scroll_Item_CommonCostItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_CommonCostItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_CommonCostItem self )
		{
			self.DestroyWidget();
		}
	}
}
