namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCellDungeonCell :Entity,IAwake,IUILogic
	{

		public DlgCellDungeonCellViewComponent View { get => this.GetComponent<DlgCellDungeonCellViewComponent>();} 

		 

	}
}
