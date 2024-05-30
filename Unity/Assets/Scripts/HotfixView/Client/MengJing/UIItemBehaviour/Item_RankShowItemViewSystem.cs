
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_RankShowItem))]
	public static partial class Scroll_Item_RankShowItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_RankShowItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_RankShowItem self )
		{
			self.DestroyWidget();
		}
	}
}
