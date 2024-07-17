namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSelectServerViewComponent))]
	[FriendOfAttribute(typeof(DlgSelectServerViewComponent))]
	public static partial class DlgSelectServerViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSelectServerViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSelectServerViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
