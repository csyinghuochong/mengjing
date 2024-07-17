namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanBagViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanBagViewComponent))]
	public static partial class DlgJiaYuanBagViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanBagViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanBagViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
