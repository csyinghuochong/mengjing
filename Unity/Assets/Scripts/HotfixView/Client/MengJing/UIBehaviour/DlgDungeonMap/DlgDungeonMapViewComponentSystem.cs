namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDungeonMapViewComponent))]
	[FriendOfAttribute(typeof(DlgDungeonMapViewComponent))]
	public static partial class DlgDungeonMapViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDungeonMapViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDungeonMapViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
