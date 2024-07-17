namespace ET.Client
{
	[EntitySystemOf(typeof(DlgShenQiMakeViewComponent))]
	[FriendOfAttribute(typeof(DlgShenQiMakeViewComponent))]
	public static partial class DlgShenQiMakeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgShenQiMakeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgShenQiMakeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
