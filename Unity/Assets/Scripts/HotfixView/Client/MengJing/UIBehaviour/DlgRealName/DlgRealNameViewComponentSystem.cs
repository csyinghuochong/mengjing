namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRealNameViewComponent))]
	[FriendOfAttribute(typeof(DlgRealNameViewComponent))]
	public static partial class DlgRealNameViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRealNameViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRealNameViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
