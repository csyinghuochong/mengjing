namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMainViewComponent))]
	[FriendOfAttribute(typeof(DlgMainViewComponent))]
	public static partial class DlgMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
