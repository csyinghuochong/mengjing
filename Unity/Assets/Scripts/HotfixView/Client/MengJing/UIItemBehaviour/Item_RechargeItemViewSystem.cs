
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_RechargeItem))]
	public static partial class Scroll_Item_RechargeItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_RechargeItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_RechargeItem self )
		{
			self.DestroyWidget();
		}
	}
}
