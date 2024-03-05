namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPopupTip :Entity,IAwake,IUILogic
	{

		public DlgPopupTipViewComponent View { get => this.GetComponent<DlgPopupTipViewComponent>();} 

		 

	}
}
