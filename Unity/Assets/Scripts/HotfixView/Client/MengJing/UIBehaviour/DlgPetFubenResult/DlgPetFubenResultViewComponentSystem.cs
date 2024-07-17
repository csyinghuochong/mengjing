namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetFubenResultViewComponent))]
	[FriendOfAttribute(typeof(DlgPetFubenResultViewComponent))]
	public static partial class DlgPetFubenResultViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetFubenResultViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetFubenResultViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
