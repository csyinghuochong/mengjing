
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetMeleeLevelItem))]
	public static partial class Scroll_Item_PetMeleeLevelItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetMeleeLevelItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetMeleeLevelItem self )
		{
			self.DestroyWidget();
		}
	}
}
