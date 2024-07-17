namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonLordDetailViewComponent))]
	[FriendOfAttribute(typeof(DlgSeasonLordDetailViewComponent))]
	public static partial class DlgSeasonLordDetailViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonLordDetailViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonLordDetailViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
