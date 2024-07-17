namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCountryTipsViewComponent))]
	[FriendOfAttribute(typeof(DlgCountryTipsViewComponent))]
	public static partial class DlgCountryTipsViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCountryTipsViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCountryTipsViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
