namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanMysteryViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanMysteryViewComponent))]
	public static partial class DlgJiaYuanMysteryViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanMysteryViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanMysteryViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
