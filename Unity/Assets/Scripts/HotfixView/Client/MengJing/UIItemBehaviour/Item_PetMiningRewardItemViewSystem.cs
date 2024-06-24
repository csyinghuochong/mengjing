
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetMiningRewardItem))]
	public static partial class Scroll_Item_PetMiningRewardItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetMiningRewardItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetMiningRewardItem self )
		{
			self.DestroyWidget();
		}
	}
}
