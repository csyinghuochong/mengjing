namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDemonMainViewComponent))]
	[FriendOfAttribute(typeof(DlgDemonMainViewComponent))]
	public static partial class DlgDemonMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDemonMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDemonMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
