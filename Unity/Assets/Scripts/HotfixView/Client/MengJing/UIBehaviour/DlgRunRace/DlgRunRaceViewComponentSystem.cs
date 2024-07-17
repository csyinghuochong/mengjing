namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRunRaceViewComponent))]
	[FriendOfAttribute(typeof(DlgRunRaceViewComponent))]
	public static partial class DlgRunRaceViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRunRaceViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRunRaceViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
