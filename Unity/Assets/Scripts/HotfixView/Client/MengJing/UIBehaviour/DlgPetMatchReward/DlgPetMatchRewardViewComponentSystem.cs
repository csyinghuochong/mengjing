
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMatchRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMatchRewardViewComponent))]
	public static partial class DlgPetMatchRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMatchRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMatchRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
