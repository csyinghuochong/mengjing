namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamDungeonPrepareViewComponent))]
	[FriendOfAttribute(typeof(DlgTeamDungeonPrepareViewComponent))]
	public static partial class DlgTeamDungeonPrepareViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamDungeonPrepareViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamDungeonPrepareViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
