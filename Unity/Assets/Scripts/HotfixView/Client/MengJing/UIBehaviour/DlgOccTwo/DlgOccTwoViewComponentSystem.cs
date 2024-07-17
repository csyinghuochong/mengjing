namespace ET.Client
{
	[EntitySystemOf(typeof(DlgOccTwoViewComponent))]
	[FriendOfAttribute(typeof(DlgOccTwoViewComponent))]
	public static partial class DlgOccTwoViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgOccTwoViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgOccTwoViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
