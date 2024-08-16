namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgBattleRecruit :Entity,IAwake,IUILogic
	{

		public DlgBattleRecruitViewComponent View { get => this.GetComponent<DlgBattleRecruitViewComponent>();} 

		 

	}
}
