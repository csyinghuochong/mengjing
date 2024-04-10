
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_MakeNeedItem))]
	public static partial class Scroll_Item_MakeNeedItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MakeNeedItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MakeNeedItem self )
		{
			self.DestroyWidget();
		}
	}
}
