namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDragonDungeon :Entity,IAwake,IUILogic
	{

		public DlgDragonDungeonViewComponent View { get => this.GetComponent<DlgDragonDungeonViewComponent>();} 

		 

	}
}
