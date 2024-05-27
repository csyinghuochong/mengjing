
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_ChouKaRewardItem))]
	public static partial class Scroll_Item_ChouKaRewardItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_ChouKaRewardItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_ChouKaRewardItem self )
		{
			self.DestroyWidget();
		}
	}
}
