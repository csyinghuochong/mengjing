namespace ET.Client
{
	[EntitySystemOf(typeof(DlgNewYearViewComponent))]
	[FriendOfAttribute(typeof(DlgNewYearViewComponent))]
	public static partial class DlgNewYearViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgNewYearViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgNewYearViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
