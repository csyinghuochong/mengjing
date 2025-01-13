namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDragonDungeonCreate :Entity,IAwake,IUILogic
	{

		public DlgDragonDungeonCreateViewComponent View { get => this.GetComponent<DlgDragonDungeonCreateViewComponent>();} 

		 

	}
}
