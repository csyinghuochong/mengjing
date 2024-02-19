namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgItemTips :Entity,IAwake,IUILogic
	{

		public DlgItemTipsViewComponent View { get => this.GetComponent<DlgItemTipsViewComponent>();} 

		 

	}
}
