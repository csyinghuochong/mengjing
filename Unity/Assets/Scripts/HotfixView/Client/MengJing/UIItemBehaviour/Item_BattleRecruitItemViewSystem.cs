
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_BattleRecruitItem))]
	public static partial class Scroll_Item_BattleRecruitItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_BattleRecruitItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_BattleRecruitItem self )
		{
			self.DestroyWidget();
		}
	}
}
