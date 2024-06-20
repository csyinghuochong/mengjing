namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDonation :Entity,IAwake,IUILogic
	{

		public DlgDonationViewComponent View { get => this.GetComponent<DlgDonationViewComponent>();} 

		 

	}
}
