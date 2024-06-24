namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgLoading :Entity,IAwake,IUILogic
	{

		public DlgLoadingViewComponent View { get => this.GetComponent<DlgLoadingViewComponent>();} 

		 

	}
}
