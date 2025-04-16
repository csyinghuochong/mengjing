namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgStallSellPrice :Entity,IAwake,IUILogic
	{

		public DlgStallSellPriceViewComponent View { get => this.GetComponent<DlgStallSellPriceViewComponent>();} 

		 

	}
}
