namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTeamDungeonCreate :Entity,IAwake,IUILogic
	{

		public DlgTeamDungeonCreateViewComponent View { get => this.GetComponent<DlgTeamDungeonCreateViewComponent>();} 

		 

	}
}
