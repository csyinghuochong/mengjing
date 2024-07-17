namespace ET.Client
{
	[EntitySystemOf(typeof(DlgZhanQuViewComponent))]
	[FriendOfAttribute(typeof(DlgZhanQuViewComponent))]
	public static partial class DlgZhanQuViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgZhanQuViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgZhanQuViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
