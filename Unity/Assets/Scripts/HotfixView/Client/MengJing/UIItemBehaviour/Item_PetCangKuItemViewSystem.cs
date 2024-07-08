
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetCangKuItem))]
	public static partial class Scroll_Item_PetCangKuItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetCangKuItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetCangKuItem self )
		{
			self.DestroyWidget();
		}
	}
}
