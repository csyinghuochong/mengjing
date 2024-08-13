
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetInfoViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetInfoViewComponent))]
	public static partial class DlgPetInfoViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetInfoViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetInfoViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
