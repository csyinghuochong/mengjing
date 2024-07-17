namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSoloViewComponent))]
	[FriendOfAttribute(typeof(DlgSoloViewComponent))]
	public static partial class DlgSoloViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSoloViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSoloViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
