namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChengJiuViewComponent))]
	[FriendOfAttribute(typeof(DlgChengJiuViewComponent))]
	public static partial class DlgChengJiuViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChengJiuViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChengJiuViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
