
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_UnionKeJiLearnItem))]
	public static partial class Scroll_Item_UnionKeJiLearnItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_UnionKeJiLearnItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_UnionKeJiLearnItem self )
		{
			self.DestroyWidget();
		}
	}
}
