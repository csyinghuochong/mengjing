
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PaiMaiSellItem))]
	public static partial class Scroll_Item_PaiMaiSellItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PaiMaiSellItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PaiMaiSellItem self )
		{
			self.DestroyWidget();
		}
	}
}
