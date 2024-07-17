namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamMainViewComponent))]
	[FriendOfAttribute(typeof(DlgTeamMainViewComponent))]
	public static partial class DlgTeamMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
