namespace ET.Client
{
	[EntitySystemOf(typeof(DlgItemTipsViewComponent))]
	[FriendOfAttribute(typeof(DlgItemTipsViewComponent))]
	public static partial class DlgItemTipsViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgItemTipsViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgItemTipsViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
