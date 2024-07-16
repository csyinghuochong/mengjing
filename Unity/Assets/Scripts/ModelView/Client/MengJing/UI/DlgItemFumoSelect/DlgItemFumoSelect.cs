namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgItemFumoSelect :Entity,IAwake,IUILogic
	{

		public DlgItemFumoSelectViewComponent View { get => this.GetComponent<DlgItemFumoSelectViewComponent>();} 

		 

	}
}
