namespace ET.Client
{
	[EntitySystemOf(typeof(DlgAuctionRecordViewComponent))]
	[FriendOfAttribute(typeof(DlgAuctionRecordViewComponent))]
	public static partial class DlgAuctionRecordViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgAuctionRecordViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgAuctionRecordViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
