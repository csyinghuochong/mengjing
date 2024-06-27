namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgZhuaPu :Entity,IAwake,IUILogic
	{

		public DlgZhuaPuViewComponent View { get => this.GetComponent<DlgZhuaPuViewComponent>();} 

		 

	}
}
