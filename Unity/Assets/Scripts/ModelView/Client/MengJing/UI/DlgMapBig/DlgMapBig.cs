namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMapBig :Entity,IAwake,IUILogic
	{

		public DlgMapBigViewComponent View { get => this.GetComponent<DlgMapBigViewComponent>();} 

		 

	}
}
