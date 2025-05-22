
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionDonationRecordViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionDonationRecordViewComponent))]
	public static partial class DlgUnionDonationRecordViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionDonationRecordViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionDonationRecordViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
