namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanTreasureMapStorage :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanTreasureMapStorageViewComponent View { get => this.GetComponent<DlgJiaYuanTreasureMapStorageViewComponent>();} 

		 

	}
}
