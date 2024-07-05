
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JiaYuanMysteryItem_A))]
	public static partial class Scroll_Item_JiaYuanMysteryItem_ASystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JiaYuanMysteryItem_A self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JiaYuanMysteryItem_A self )
		{
			self.DestroyWidget();
		}
	}
}
