namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetXiLianLockSkill :Entity,IAwake,IUILogic
	{

		public DlgPetXiLianLockSkillViewComponent View { get => this.GetComponent<DlgPetXiLianLockSkillViewComponent>();} 

		 

	}
}
