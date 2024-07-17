namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSettingFrameViewComponent))]
	[FriendOfAttribute(typeof(DlgSettingFrameViewComponent))]
	public static partial class DlgSettingFrameViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSettingFrameViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSettingFrameViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
