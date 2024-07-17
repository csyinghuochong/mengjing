namespace ET.Client
{
	[EntitySystemOf(typeof(DlgBattleViewComponent))]
	[FriendOfAttribute(typeof(DlgBattleViewComponent))]
	public static partial class DlgBattleViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgBattleViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgBattleViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
