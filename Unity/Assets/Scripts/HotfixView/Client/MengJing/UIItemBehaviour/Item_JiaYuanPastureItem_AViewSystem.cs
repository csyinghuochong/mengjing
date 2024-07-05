
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JiaYuanPastureItem_A))]
	public static partial class Scroll_Item_JiaYuanPastureItem_ASystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JiaYuanPastureItem_A self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JiaYuanPastureItem_A self )
		{
			self.DestroyWidget();
		}
	}
}
