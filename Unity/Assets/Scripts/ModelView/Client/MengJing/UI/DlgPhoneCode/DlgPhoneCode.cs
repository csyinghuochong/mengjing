namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPhoneCode :Entity,IAwake,IUILogic
	{

		public DlgPhoneCodeViewComponent View { get => this.GetComponent<DlgPhoneCodeViewComponent>();} 

		 

	}
}
