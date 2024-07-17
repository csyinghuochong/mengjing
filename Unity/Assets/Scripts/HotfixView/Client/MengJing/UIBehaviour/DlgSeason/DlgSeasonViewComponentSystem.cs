namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonViewComponent))]
	[FriendOfAttribute(typeof(DlgSeasonViewComponent))]
	public static partial class DlgSeasonViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
