
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetSkinIconItem))]
	public static partial class Scroll_Item_PetSkinIconItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetSkinIconItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetSkinIconItem self )
		{
			self.DestroyWidget();
		}
	}
}
