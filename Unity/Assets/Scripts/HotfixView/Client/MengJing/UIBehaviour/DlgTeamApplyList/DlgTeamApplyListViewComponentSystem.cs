namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamApplyListViewComponent))]
	[FriendOfAttribute(typeof(DlgTeamApplyListViewComponent))]
	public static partial class DlgTeamApplyListViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamApplyListViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamApplyListViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
