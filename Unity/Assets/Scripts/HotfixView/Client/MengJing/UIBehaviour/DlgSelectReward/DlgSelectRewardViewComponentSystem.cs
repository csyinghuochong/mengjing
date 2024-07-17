namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSelectRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgSelectRewardViewComponent))]
	public static partial class DlgSelectRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSelectRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSelectRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
