namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanRecordViewComponent))]
	[FriendOfAttribute(typeof(DlgJiaYuanRecordViewComponent))]
	public static partial class DlgJiaYuanRecordViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanRecordViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanRecordViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
