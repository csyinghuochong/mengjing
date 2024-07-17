namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanPetFeedViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanPetFeedViewComponent))]
	public static partial class DlgJiaYuanPetFeedViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanPetFeedViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanPetFeedViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
