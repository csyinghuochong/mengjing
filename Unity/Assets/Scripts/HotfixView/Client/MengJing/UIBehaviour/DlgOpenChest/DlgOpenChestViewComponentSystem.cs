namespace ET.Client
{
	[EntitySystemOf(typeof(DlgOpenChestViewComponent))]
	[FriendOfAttribute(typeof(DlgOpenChestViewComponent))]
	public static partial class DlgOpenChestViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgOpenChestViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgOpenChestViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
