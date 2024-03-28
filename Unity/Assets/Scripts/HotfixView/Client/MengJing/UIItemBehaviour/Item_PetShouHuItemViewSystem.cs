
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetShouHuItem))]
	public static partial class Scroll_Item_PetShouHuItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetShouHuItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetShouHuItem self )
		{
			self.DestroyWidget();
		}
	}
}
