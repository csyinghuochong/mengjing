
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JiaYuanCookbookItem))]
	public static partial class Scroll_Item_JiaYuanCookbookItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JiaYuanCookbookItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JiaYuanCookbookItem self )
		{
			self.DestroyWidget();
		}
	}
}
