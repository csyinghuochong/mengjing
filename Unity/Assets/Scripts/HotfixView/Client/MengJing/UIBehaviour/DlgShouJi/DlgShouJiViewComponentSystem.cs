namespace ET.Client
{
	[EntitySystemOf(typeof(DlgShouJiViewComponent))]
	[FriendOfAttribute(typeof(DlgShouJiViewComponent))]
	public static partial class DlgShouJiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgShouJiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgShouJiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
