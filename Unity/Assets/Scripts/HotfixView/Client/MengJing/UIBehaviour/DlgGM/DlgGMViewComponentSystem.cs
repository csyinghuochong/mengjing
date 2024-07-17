namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGMViewComponent))]
	[FriendOfAttribute(typeof(DlgGMViewComponent))]
	public static partial class DlgGMViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGMViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGMViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
