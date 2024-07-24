namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgOneSellSet :Entity,IAwake,IUILogic
	{

		public DlgOneSellSetViewComponent View { get => this.GetComponent<DlgOneSellSetViewComponent>();} 

		 

	}
}
