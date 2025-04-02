
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMatchViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetMatchViewComponent))]
	public static partial class DlgPetMatchViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMatchViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMatchViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
