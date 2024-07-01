
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMainViewComponent))]
	public static partial class DlgPetMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
