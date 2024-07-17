namespace ET.Client
{
	[EntitySystemOf(typeof(DlgHappyMainViewComponent))]
	[FriendOfAttribute(typeof(DlgHappyMainViewComponent))]
	public static partial class DlgHappyMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgHappyMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgHappyMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
