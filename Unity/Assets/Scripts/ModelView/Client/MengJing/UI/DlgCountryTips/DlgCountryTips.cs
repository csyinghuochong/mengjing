namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCountryTips :Entity,IAwake,IUILogic
	{

		public DlgCountryTipsViewComponent View { get => this.GetComponent<DlgCountryTipsViewComponent>();} 

		 

	}
}
