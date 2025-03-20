
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_UnionOrderItem))]
	public static partial class Scroll_Item_UnionOrderItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_UnionOrderItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_UnionOrderItem self )
		{
			self.DestroyWidget();
		}
	}
}
