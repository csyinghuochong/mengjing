namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGiveTaskViewComponent))]
	[FriendOfAttribute(typeof(DlgGiveTaskViewComponent))]
	public static partial class DlgGiveTaskViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGiveTaskViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGiveTaskViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
