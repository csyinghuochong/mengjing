namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerOfSealMainViewComponent))]
	[FriendOfAttribute(typeof(DlgTowerOfSealMainViewComponent))]
	public static partial class DlgTowerOfSealMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerOfSealMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerOfSealMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
