namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgWatch :Entity,IAwake,IUILogic
	{

		public DlgWatchViewComponent View { get => this.GetComponent<DlgWatchViewComponent>();} 

		 

	}
}
