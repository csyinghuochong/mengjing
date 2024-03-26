
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetViewComponent))]
	public static partial class DlgPetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
