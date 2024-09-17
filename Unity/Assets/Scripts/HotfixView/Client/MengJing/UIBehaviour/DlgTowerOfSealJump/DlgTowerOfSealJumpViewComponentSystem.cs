namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerOfSealJumpViewComponent))]
	[FriendOfAttribute(typeof(DlgTowerOfSealJumpViewComponent))]
	public static partial class DlgTowerOfSealJumpViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerOfSealJumpViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerOfSealJumpViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
