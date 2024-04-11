
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_UnionListItem))]
	public static partial class Scroll_Item_UnionListItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_UnionListItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_UnionListItem self )
		{
			self.DestroyWidget();
		}
	}
}
