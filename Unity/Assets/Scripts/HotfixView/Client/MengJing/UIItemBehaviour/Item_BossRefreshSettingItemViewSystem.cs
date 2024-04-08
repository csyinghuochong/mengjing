
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_BossRefreshSettingItem))]
	public static partial class Scroll_Item_BossRefreshSettingItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_BossRefreshSettingItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_BossRefreshSettingItem self )
		{
			self.DestroyWidget();
		}
	}
}
