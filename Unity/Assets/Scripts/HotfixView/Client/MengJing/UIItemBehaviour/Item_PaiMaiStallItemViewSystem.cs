
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PaiMaiStallItem))]
	public static partial class Scroll_Item_PaiMaiStallItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PaiMaiStallItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PaiMaiStallItem self )
		{
			self.DestroyWidget();
		}
	}
}
