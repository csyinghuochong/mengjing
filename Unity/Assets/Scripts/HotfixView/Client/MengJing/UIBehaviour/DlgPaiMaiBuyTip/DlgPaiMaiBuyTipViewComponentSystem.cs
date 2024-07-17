namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPaiMaiBuyTipViewComponent))]
	[FriendOfAttribute(typeof(DlgPaiMaiBuyTipViewComponent))]
	public static partial class DlgPaiMaiBuyTipViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPaiMaiBuyTipViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPaiMaiBuyTipViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
