namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDungeonLevelViewComponent))]
	[FriendOfAttribute(typeof(DlgDungeonLevelViewComponent))]
	public static partial class DlgDungeonLevelViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDungeonLevelViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDungeonLevelViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
