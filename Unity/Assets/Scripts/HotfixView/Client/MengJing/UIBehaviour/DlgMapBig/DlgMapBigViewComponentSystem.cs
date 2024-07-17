namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMapBigViewComponent))]
	[FriendOfAttribute(typeof(DlgMapBigViewComponent))]
	public static partial class DlgMapBigViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMapBigViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMapBigViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
