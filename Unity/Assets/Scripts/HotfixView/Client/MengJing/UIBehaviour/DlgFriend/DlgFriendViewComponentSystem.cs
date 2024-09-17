namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFriendViewComponent))]
	[FriendOfAttribute(typeof(DlgFriendViewComponent))]
	public static partial class DlgFriendViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFriendViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFriendViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
