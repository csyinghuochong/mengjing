
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JiaYuanDaShiProItem))]
	public static partial class Scroll_Item_JiaYuanDaShiProItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JiaYuanDaShiProItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JiaYuanDaShiProItem self )
		{
			self.DestroyWidget();
		}
	}
}
