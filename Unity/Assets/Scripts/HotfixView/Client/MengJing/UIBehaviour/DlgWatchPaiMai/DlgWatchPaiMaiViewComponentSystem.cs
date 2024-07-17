namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWatchPaiMaiViewComponent))]
	[FriendOfAttribute(typeof(DlgWatchPaiMaiViewComponent))]
	public static partial class DlgWatchPaiMaiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWatchPaiMaiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWatchPaiMaiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
