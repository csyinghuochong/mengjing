namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTrialMainViewComponent))]
	[FriendOfAttribute(typeof(DlgTrialMainViewComponent))]
	public static partial class DlgTrialMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTrialMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTrialMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
