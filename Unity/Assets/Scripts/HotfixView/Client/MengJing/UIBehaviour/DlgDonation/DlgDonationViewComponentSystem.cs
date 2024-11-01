
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDonationViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDonationViewComponent))]
	public static partial class DlgDonationViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDonationViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDonationViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
