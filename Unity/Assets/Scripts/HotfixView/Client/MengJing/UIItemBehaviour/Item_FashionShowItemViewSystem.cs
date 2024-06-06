
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_FashionShowItem))]
	public static partial class Scroll_Item_FashionShowItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_FashionShowItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_FashionShowItem self )
		{
			self.DestroyWidget();
		}
	}
}
