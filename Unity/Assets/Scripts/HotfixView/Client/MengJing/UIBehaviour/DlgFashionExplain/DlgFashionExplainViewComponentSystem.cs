namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFashionExplainViewComponent))]
	[FriendOfAttribute(typeof(DlgFashionExplainViewComponent))]
	public static partial class DlgFashionExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFashionExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFashionExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
