namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleXiLianExplainViewComponent))]
	[FriendOfAttribute(typeof(DlgRoleXiLianExplainViewComponent))]
	public static partial class DlgRoleXiLianExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleXiLianExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleXiLianExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
