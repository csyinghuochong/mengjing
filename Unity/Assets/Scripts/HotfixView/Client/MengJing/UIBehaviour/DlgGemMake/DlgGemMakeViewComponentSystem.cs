namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGemMakeViewComponent))]
	[FriendOfAttribute(typeof(DlgGemMakeViewComponent))]
	public static partial class DlgGemMakeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGemMakeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGemMakeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
