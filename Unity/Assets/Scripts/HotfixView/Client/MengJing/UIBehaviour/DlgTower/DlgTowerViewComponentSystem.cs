namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerViewComponent))]
	[FriendOfAttribute(typeof(DlgTowerViewComponent))]
	public static partial class DlgTowerViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
