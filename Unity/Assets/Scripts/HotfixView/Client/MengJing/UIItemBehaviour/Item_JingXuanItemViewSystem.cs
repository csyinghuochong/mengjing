
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JingXuanItem))]
	public static partial class Scroll_Item_JingXuanItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JingXuanItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JingXuanItem self )
		{
			self.DestroyWidget();
		}
	}
}
