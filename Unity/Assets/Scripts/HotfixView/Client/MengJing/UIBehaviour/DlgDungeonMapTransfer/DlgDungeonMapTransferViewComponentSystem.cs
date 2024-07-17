namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDungeonMapTransferViewComponent))]
	[FriendOfAttribute(typeof(DlgDungeonMapTransferViewComponent))]
	public static partial class DlgDungeonMapTransferViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDungeonMapTransferViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDungeonMapTransferViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
