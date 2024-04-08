
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_DungeonItem))]
	public static partial class Scroll_Item_DungeonItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_DungeonItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_DungeonItem self )
		{
			self.DestroyWidget();
		}
	}
}
