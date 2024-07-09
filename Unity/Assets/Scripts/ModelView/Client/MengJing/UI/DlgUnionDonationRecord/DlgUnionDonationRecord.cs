namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnionDonationRecord :Entity,IAwake,IUILogic
	{

		public DlgUnionDonationRecordViewComponent View { get => this.GetComponent<DlgUnionDonationRecordViewComponent>();} 

		 

	}
}
