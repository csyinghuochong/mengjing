
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_TeamDungeonItem))]
	public static partial class Scroll_Item_TeamDungeonItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TeamDungeonItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TeamDungeonItem self )
		{
			self.DestroyWidget();
		}
	}
}
