namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgAuctionRecord :Entity,IAwake,IUILogic
	{

		public DlgAuctionRecordViewComponent View { get => this.GetComponent<DlgAuctionRecordViewComponent>();} 

		 

	}
}
