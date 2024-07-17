namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWatchMenuViewComponent))]
	[FriendOfAttribute(typeof(DlgWatchMenuViewComponent))]
	public static partial class DlgWatchMenuViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWatchMenuViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWatchMenuViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
