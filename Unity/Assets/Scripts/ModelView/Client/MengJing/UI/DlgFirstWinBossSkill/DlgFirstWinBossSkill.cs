namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgFirstWinBossSkill :Entity,IAwake,IUILogic
	{

		public DlgFirstWinBossSkillViewComponent View { get => this.GetComponent<DlgFirstWinBossSkillViewComponent>();} 

		 

	}
}
