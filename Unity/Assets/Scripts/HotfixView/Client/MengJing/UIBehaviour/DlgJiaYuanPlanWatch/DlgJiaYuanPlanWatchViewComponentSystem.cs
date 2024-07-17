namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanPlanWatchViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanPlanWatchViewComponent))]
	public static partial class DlgJiaYuanPlanWatchViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanPlanWatchViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanPlanWatchViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
