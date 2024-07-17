namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMiningChallengeViewComponent))]
	[FriendOfAttribute(typeof(DlgPetMiningChallengeViewComponent))]
	public static partial class DlgPetMiningChallengeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMiningChallengeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMiningChallengeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
