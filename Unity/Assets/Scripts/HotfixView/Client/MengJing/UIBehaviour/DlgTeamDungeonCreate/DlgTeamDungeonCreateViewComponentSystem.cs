namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamDungeonCreateViewComponent))]
	[FriendOfAttribute(typeof(DlgTeamDungeonCreateViewComponent))]
	public static partial class DlgTeamDungeonCreateViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamDungeonCreateViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamDungeonCreateViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
