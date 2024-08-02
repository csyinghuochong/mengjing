
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_TeamDungeonSettlementPlayer))]
	public static partial class Scroll_Item_TeamDungeonSettlementPlayerSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TeamDungeonSettlementPlayer self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TeamDungeonSettlementPlayer self )
		{
			self.DestroyWidget();
		}
	}
}
