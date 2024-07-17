namespace ET.Client
{
	[EntitySystemOf(typeof(DlgStoreViewComponent))]
	[FriendOfAttribute(typeof(DlgStoreViewComponent))]
	public static partial class DlgStoreViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgStoreViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgStoreViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
