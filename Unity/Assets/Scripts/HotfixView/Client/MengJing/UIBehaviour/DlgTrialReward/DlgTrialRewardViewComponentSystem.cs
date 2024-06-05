
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTrialRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTrialRewardViewComponent))]
	public static partial class DlgTrialRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTrialRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTrialRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
