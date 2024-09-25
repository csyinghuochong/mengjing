
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_MainPetFightItem))]
	public static partial class Scroll_Item_MainPetFightItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MainPetFightItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MainPetFightItem self )
		{
			self.DestroyWidget();
		}
	}
}
