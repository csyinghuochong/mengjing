
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PaiMaiBuyItem))]
	public static partial class Scroll_Item_PaiMaiBuyItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PaiMaiBuyItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PaiMaiBuyItem self )
		{
			self.DestroyWidget();
		}
	}
}
