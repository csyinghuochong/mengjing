namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRelinkViewComponent))]
	[FriendOfAttribute(typeof(DlgRelinkViewComponent))]
	public static partial class DlgRelinkViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRelinkViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRelinkViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
