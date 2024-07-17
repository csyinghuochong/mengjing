namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamDungeonViewComponent))]
	[FriendOfAttribute(typeof(DlgTeamDungeonViewComponent))]
	public static partial class DlgTeamDungeonViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamDungeonViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamDungeonViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
