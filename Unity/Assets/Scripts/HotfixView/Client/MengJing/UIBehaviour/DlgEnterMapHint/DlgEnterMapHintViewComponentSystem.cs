namespace ET.Client
{
	[EntitySystemOf(typeof(DlgEnterMapHintViewComponent))]
	[FriendOfAttribute(typeof(DlgEnterMapHintViewComponent))]
	public static partial class DlgEnterMapHintViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgEnterMapHintViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgEnterMapHintViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
