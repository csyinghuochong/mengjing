namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCountry :Entity,IAwake,IUILogic
	{

		public DlgCountryViewComponent View { get => this.GetComponent<DlgCountryViewComponent>();} 

		 

	}
}
