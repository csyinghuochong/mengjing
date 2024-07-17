namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChouKaWarehouseViewComponent))]
	[FriendOfAttribute(typeof(DlgChouKaWarehouseViewComponent))]
	public static partial class DlgChouKaWarehouseViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChouKaWarehouseViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChouKaWarehouseViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
