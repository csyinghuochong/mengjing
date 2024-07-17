namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRankViewComponent))]
	[FriendOfAttribute(typeof(DlgRankViewComponent))]
	public static partial class DlgRankViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRankViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRankViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
