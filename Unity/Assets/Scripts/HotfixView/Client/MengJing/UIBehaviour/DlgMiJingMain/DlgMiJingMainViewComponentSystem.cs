namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMiJingMainViewComponent))]
	[FriendOfAttribute(typeof(DlgMiJingMainViewComponent))]
	public static partial class DlgMiJingMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMiJingMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMiJingMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
