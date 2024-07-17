namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetQuickFightViewComponent))]
	[FriendOfAttribute(typeof(DlgPetQuickFightViewComponent))]
	public static partial class DlgPetQuickFightViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetQuickFightViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetQuickFightViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
