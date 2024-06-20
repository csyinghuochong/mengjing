namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCountryHuoDongJieShao :Entity,IAwake,IUILogic
	{

		public DlgCountryHuoDongJieShaoViewComponent View { get => this.GetComponent<DlgCountryHuoDongJieShaoViewComponent>();} 

		 

	}
}
