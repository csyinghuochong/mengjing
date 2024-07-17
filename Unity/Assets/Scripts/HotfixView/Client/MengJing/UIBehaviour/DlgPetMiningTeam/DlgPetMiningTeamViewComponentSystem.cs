namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMiningTeamViewComponent))]
	[FriendOfAttribute(typeof(DlgPetMiningTeamViewComponent))]
	public static partial class DlgPetMiningTeamViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMiningTeamViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMiningTeamViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
