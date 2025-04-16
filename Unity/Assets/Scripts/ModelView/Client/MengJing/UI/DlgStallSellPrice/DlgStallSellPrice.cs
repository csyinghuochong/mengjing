namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgStallSellPrice :Entity,IAwake,IUILogic
	{

		public DlgStallSellPriceViewComponent View { get => this.GetComponent<DlgStallSellPriceViewComponent>();} 
		
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		
		public int oldPrice;
		public int nowPrice;
		public int priceProNum;
		public int SellNum;
		public bool IsHoldDown;
	}
}
