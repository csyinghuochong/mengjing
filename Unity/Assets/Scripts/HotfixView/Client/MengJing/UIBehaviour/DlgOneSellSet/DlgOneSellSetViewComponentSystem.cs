namespace ET.Client
{
	[EntitySystemOf(typeof(DlgOneSellSetViewComponent))]
	[FriendOfAttribute(typeof(DlgOneSellSetViewComponent))]
	public static partial class DlgOneSellSetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgOneSellSetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgOneSellSetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
