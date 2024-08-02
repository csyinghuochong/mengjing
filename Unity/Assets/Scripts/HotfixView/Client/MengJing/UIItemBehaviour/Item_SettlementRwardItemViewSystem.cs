
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SettlementRwardItem))]
	public static partial class Scroll_Item_SettlementRwardItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SettlementRwardItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SettlementRwardItem self )
		{
			self.DestroyWidget();
		}
	}
}
