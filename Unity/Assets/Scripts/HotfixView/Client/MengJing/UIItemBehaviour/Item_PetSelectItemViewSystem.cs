
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetSelectItem))]
	public static partial class Scroll_Item_PetSelectItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetSelectItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetSelectItem self )
		{
			self.DestroyWidget();
		}
	}
}
