
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetFormationViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetFormationViewComponent))]
	public static partial class DlgPetFormationViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetFormationViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetFormationViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
