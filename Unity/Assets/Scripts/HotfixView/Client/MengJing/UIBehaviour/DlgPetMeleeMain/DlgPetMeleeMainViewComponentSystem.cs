
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMeleeMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMeleeMainViewComponent))]
	public static partial class DlgPetMeleeMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMeleeMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMeleeMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
