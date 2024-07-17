namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFirstWinRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgFirstWinRewardViewComponent))]
	public static partial class DlgFirstWinRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFirstWinRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFirstWinRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
