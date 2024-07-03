namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTeam :Entity,IAwake,IUILogic
	{

		public DlgTeamViewComponent View { get => this.GetComponent<DlgTeamViewComponent>();} 

		 

	}
}
