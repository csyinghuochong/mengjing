namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDragonDungeonPrepare :Entity,IAwake,IUILogic
	{

		public DlgDragonDungeonPrepareViewComponent View { get => this.GetComponent<DlgDragonDungeonPrepareViewComponent>();} 

		 

	}
}
