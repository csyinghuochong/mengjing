namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerOfSealViewComponent))]
	[FriendOfAttribute(typeof(DlgTowerOfSealViewComponent))]
	public static partial class DlgTowerOfSealViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerOfSealViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerOfSealViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
