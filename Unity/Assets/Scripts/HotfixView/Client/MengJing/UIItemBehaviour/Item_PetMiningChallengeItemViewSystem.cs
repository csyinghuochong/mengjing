
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetMiningChallengeItem))]
	public static partial class Scroll_Item_PetMiningChallengeItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetMiningChallengeItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetMiningChallengeItem self )
		{
			self.DestroyWidget();
		}
	}
}
