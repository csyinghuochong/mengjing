namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRunRaceMainViewComponent))]
	[FriendOfAttribute(typeof(DlgRunRaceMainViewComponent))]
	public static partial class DlgRunRaceMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRunRaceMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRunRaceMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
