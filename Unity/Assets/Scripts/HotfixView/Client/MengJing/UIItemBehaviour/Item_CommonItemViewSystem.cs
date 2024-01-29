
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_CommonItem))]
	public static partial class Scroll_Item_CommonItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_CommonItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_CommonItem self )
		{
			self.DestroyWidget();
		}
	}
}
