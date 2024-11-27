
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_MonsterItem))]
	public static partial class Scroll_Item_MonsterItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MonsterItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MonsterItem self )
		{
			self.DestroyWidget();
		}
	}
}
