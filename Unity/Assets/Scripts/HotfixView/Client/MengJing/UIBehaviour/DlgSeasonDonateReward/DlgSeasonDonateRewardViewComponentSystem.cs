
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonDonateRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSeasonDonateRewardViewComponent))]
	public static partial class DlgSeasonDonateRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonDonateRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonDonateRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
