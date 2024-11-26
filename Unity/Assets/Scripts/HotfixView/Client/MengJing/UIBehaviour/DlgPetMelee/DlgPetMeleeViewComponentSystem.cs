
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMeleeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMeleeViewComponent))]
	public static partial class DlgPetMeleeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMeleeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMeleeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
