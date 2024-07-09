
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_UnionKeJiResearchItem))]
	public static partial class Scroll_Item_UnionKeJiResearchItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_UnionKeJiResearchItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_UnionKeJiResearchItem self )
		{
			self.DestroyWidget();
		}
	}
}
