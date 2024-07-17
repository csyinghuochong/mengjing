namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJingLingGetViewComponent))]
	[FriendOfAttribute(typeof(DlgJingLingGetViewComponent))]
	public static partial class DlgJingLingGetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJingLingGetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJingLingGetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
