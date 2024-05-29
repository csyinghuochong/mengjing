
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEggViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetEggViewComponent))]
	public static partial class DlgPetEggViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEggViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEggViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
