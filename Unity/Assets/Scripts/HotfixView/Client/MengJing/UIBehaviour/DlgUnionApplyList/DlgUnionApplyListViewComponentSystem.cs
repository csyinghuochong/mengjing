namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionApplyListViewComponent))]
	[FriendOfAttribute(typeof(DlgUnionApplyListViewComponent))]
	public static partial class DlgUnionApplyListViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionApplyListViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionApplyListViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
