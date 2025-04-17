namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPaiMaiStall :Entity,IAwake,IUILogic
	{

		public DlgPaiMaiStallViewComponent View { get => this.GetComponent<DlgPaiMaiStallViewComponent>();} 

		 

	}
}
