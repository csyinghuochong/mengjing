namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDungeonMap :Entity,IAwake,IUILogic
	{

		public DlgDungeonMapViewComponent View { get => this.GetComponent<DlgDungeonMapViewComponent>();} 

		 

	}
}
