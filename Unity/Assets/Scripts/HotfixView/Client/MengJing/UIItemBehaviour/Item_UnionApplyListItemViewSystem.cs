
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_UnionApplyListItem))]
	public static partial class Scroll_Item_UnionApplyListItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_UnionApplyListItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_UnionApplyListItem self )
		{
			self.DestroyWidget();
		}
	}
}
