namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGivePetViewComponent))]
	[FriendOfAttribute(typeof(DlgGivePetViewComponent))]
	public static partial class DlgGivePetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGivePetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGivePetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
