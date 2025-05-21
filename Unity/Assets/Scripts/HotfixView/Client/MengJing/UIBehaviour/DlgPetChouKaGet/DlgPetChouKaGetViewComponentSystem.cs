
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetChouKaGetViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetChouKaGetViewComponent))]
	public static partial class DlgPetChouKaGetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetChouKaGetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetChouKaGetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
