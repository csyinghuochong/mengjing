
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetSelectViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetSelectViewComponent))]
	public static partial class DlgPetSelectViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetSelectViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetSelectViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
