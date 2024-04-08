
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_BossRefreshTimeItem))]
	public static partial class Scroll_Item_BossRefreshTimeItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_BossRefreshTimeItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_BossRefreshTimeItem self )
		{
			self.DestroyWidget();
		}
	}
}
