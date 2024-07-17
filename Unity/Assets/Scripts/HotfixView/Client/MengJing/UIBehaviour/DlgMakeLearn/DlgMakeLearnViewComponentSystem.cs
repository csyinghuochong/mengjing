namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMakeLearnViewComponent))]
	[FriendOfAttribute(typeof(DlgMakeLearnViewComponent))]
	public static partial class DlgMakeLearnViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMakeLearnViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMakeLearnViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
