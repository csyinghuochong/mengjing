
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SettingTitleItem))]
	public static partial class Scroll_Item_SettingTitleItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SettingTitleItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SettingTitleItem self )
		{
			self.DestroyWidget();
		}
	}
}
