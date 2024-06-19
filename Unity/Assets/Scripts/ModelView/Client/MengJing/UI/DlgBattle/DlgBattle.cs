namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgBattle :Entity,IAwake,IUILogic
	{

		public DlgBattleViewComponent View { get => this.GetComponent<DlgBattleViewComponent>();} 

		 

	}
}
