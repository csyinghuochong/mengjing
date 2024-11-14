
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetBarViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetBarViewComponent))]
	public static partial class DlgPetBarViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetBarViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetBarViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
