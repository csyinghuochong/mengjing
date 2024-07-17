namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetHeChengPreviewViewComponent))]
	[FriendOfAttribute(typeof(DlgPetHeChengPreviewViewComponent))]
	public static partial class DlgPetHeChengPreviewViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetHeChengPreviewViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetHeChengPreviewViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
