
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEggChouKaRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetEggChouKaRewardViewComponent))]
	public static partial class DlgPetEggChouKaRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEggChouKaRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEggChouKaRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
