namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleZodiacViewComponent))]
	[FriendOfAttribute(typeof(DlgRoleZodiacViewComponent))]
	public static partial class DlgRoleZodiacViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleZodiacViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleZodiacViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
