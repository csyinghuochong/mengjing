namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanPastureViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanPastureViewComponent))]
	public static partial class DlgJiaYuanPastureViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanPastureViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanPastureViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
