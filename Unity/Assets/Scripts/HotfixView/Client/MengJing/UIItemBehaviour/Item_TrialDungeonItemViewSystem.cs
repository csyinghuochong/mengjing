
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_TrialDungeonItem))]
	public static partial class Scroll_Item_TrialDungeonItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TrialDungeonItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TrialDungeonItem self )
		{
			self.DestroyWidget();
		}
	}
}
