namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTrialRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgTrialRewardViewComponent))]
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
