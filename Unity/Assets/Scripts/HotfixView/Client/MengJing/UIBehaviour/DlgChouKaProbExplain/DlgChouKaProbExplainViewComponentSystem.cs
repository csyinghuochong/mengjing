namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChouKaProbExplainViewComponent))]
	[FriendOfAttribute(typeof(DlgChouKaProbExplainViewComponent))]
	public static partial class DlgChouKaProbExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChouKaProbExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChouKaProbExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
