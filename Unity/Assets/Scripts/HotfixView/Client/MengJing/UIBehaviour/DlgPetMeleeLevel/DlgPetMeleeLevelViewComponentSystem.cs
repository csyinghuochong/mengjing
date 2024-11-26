
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMeleeLevelViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMeleeLevelViewComponent))]
	public static partial class DlgPetMeleeLevelViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMeleeLevelViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMeleeLevelViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
