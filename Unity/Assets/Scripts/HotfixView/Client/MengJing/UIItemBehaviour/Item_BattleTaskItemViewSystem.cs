
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_BattleTaskItem))]
	public static partial class Scroll_Item_BattleTaskItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_BattleTaskItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_BattleTaskItem self )
		{
			self.DestroyWidget();
		}
	}
}
