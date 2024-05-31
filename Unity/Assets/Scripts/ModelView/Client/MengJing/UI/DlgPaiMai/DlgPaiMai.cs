namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPaiMai :Entity,IAwake,IUILogic
	{

		public DlgPaiMaiViewComponent View { get => this.GetComponent<DlgPaiMaiViewComponent>();} 

		 

	}
}
