namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRecharge :Entity,IAwake,IUILogic
	{

		public DlgRechargeViewComponent View { get => this.GetComponent<DlgRechargeViewComponent>();} 

		 

	}
}
