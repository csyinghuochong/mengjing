namespace ET.Client
{
	[EntitySystemOf(typeof(DlgEquipDuiBiTipsViewComponent))]
	[FriendOfAttribute(typeof(DlgEquipDuiBiTipsViewComponent))]
	public static partial class DlgEquipDuiBiTipsViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgEquipDuiBiTipsViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgEquipDuiBiTipsViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
