namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRechargeRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgRechargeRewardViewComponent))]
	public static partial class DlgRechargeRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRechargeRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRechargeRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
