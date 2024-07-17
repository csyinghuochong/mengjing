namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMiningFormationViewComponent))]
	[FriendOfAttribute(typeof(DlgPetMiningFormationViewComponent))]
	public static partial class DlgPetMiningFormationViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMiningFormationViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMiningFormationViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
