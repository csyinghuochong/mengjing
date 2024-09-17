namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSoloRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgSoloRewardViewComponent))]
	public static partial class DlgSoloRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSoloRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSoloRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
