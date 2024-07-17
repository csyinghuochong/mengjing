namespace ET.Client
{
	[EntitySystemOf(typeof(DlgActivityViewComponent))]
	[FriendOfAttribute(typeof(DlgActivityViewComponent))]
	public static partial class DlgActivityViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgActivityViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgActivityViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
