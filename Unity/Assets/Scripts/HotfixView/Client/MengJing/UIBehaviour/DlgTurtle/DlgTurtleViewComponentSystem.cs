namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTurtleViewComponent))]
	[FriendOfAttribute(typeof(DlgTurtleViewComponent))]
	public static partial class DlgTurtleViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTurtleViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTurtleViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
