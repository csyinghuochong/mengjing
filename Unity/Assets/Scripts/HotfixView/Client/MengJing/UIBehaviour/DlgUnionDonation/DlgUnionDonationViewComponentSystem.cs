
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionDonationViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionDonationViewComponent))]
	public static partial class DlgUnionDonationViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionDonationViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionDonationViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
