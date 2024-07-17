namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanUpLvViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanUpLvViewComponent))]
	public static partial class DlgJiaYuanUpLvViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanUpLvViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanUpLvViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
