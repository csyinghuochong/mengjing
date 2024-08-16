namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetXiLianLockSkillViewComponent))]
	[FriendOfAttribute(typeof(DlgPetXiLianLockSkillViewComponent))]
	public static partial class DlgPetXiLianLockSkillViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetXiLianLockSkillViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetXiLianLockSkillViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
