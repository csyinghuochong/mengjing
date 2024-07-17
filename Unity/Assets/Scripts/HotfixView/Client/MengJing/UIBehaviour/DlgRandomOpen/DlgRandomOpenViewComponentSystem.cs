namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRandomOpenViewComponent))]
	[FriendOfAttribute(typeof(DlgRandomOpenViewComponent))]
	public static partial class DlgRandomOpenViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRandomOpenViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRandomOpenViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
