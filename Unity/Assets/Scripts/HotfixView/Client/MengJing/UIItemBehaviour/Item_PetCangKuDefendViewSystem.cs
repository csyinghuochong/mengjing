
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetCangKuDefend))]
	public static partial class Scroll_Item_PetCangKuDefendSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetCangKuDefend self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetCangKuDefend self )
		{
			self.DestroyWidget();
		}
	}
}
