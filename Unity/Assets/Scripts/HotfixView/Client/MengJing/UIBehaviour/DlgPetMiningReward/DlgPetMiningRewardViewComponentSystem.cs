namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetMiningRewardViewComponent))]
	[FriendOfAttribute(typeof(DlgPetMiningRewardViewComponent))]
	public static partial class DlgPetMiningRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetMiningRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetMiningRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
