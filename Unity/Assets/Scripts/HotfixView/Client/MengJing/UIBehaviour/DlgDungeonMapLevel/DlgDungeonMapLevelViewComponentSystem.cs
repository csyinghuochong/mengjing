namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDungeonMapLevelViewComponent))]
	[FriendOfAttribute(typeof(DlgDungeonMapLevelViewComponent))]
	public static partial class DlgDungeonMapLevelViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDungeonMapLevelViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDungeonMapLevelViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
