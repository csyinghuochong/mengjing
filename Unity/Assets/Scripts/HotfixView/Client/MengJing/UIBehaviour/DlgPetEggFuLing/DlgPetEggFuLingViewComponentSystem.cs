
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEggFuLingViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetEggFuLingViewComponent))]
	public static partial class DlgPetEggFuLingViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEggFuLingViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEggFuLingViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
