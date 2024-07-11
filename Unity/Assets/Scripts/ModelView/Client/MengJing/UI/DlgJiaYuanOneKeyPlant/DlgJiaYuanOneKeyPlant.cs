namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanOneKeyPlant :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanOneKeyPlantViewComponent View { get => this.GetComponent<DlgJiaYuanOneKeyPlantViewComponent>();} 

		 

	}
}
