namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFenXiangViewComponent))]
	[FriendOfAttribute(typeof(DlgFenXiangViewComponent))]
	public static partial class DlgFenXiangViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFenXiangViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFenXiangViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
