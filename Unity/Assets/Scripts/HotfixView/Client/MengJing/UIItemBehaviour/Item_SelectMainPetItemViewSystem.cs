
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SelectMainPetItem))]
	public static partial class Scroll_Item_SelectMainPetItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SelectMainPetItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SelectMainPetItem self )
		{
			self.DestroyWidget();
		}
	}
}
