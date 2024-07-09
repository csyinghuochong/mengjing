namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnionDonation :Entity,IAwake,IUILogic
	{

		public DlgUnionDonationViewComponent View { get => this.GetComponent<DlgUnionDonationViewComponent>();} 

		 

	}
}
