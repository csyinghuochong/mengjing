
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMiningChallengeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMiningChallengeViewComponent))]
	public static partial class DlgPetMiningChallengeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMiningChallengeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMiningChallengeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
