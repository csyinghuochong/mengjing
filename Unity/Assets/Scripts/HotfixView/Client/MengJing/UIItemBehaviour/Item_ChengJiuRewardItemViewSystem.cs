
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_ChengJiuRewardItem))]
	public static partial class Scroll_Item_ChengJiuRewardItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_ChengJiuRewardItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_ChengJiuRewardItem self )
		{
			self.DestroyWidget();
		}
	}
}
