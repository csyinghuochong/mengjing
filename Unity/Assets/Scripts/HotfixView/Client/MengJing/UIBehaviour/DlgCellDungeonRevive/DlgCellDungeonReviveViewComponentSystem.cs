namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellDungeonReviveViewComponent))]
	[FriendOfAttribute(typeof(DlgCellDungeonReviveViewComponent))]
	public static partial class DlgCellDungeonReviveViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellDungeonReviveViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellDungeonReviveViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
