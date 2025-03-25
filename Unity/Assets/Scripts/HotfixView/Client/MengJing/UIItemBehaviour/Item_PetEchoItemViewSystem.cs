
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetEchoItem))]
	public static partial class Scroll_Item_PetEchoItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetEchoItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetEchoItem self )
		{
			self.DestroyWidget();
		}
	}
}
