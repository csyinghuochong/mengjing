namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleXiLianViewComponent))]
	[FriendOfAttribute(typeof(DlgRoleXiLianViewComponent))]
	public static partial class DlgRoleXiLianViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleXiLianViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleXiLianViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
