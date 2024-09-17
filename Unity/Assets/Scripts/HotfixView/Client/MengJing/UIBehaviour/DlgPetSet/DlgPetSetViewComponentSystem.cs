namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetSetViewComponent))]
	[FriendOfAttribute(typeof(DlgPetSetViewComponent))]
	public static partial class DlgPetSetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetSetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetSetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
