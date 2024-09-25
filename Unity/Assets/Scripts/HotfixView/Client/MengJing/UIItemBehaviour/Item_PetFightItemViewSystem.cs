
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetFightItem))]
	public static partial class Scroll_Item_PetFightItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetFightItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetFightItem self )
		{
			self.DestroyWidget();
		}
	}
}
