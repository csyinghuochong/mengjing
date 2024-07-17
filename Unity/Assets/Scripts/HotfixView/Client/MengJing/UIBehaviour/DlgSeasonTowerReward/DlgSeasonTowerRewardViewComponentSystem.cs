namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonTowerRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgSeasonTowerRewardViewComponent))]
	public static partial class DlgSeasonTowerRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonTowerRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonTowerRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
