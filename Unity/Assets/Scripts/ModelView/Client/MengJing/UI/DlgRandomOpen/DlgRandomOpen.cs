namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRandomOpen :Entity,IAwake,IUILogic
	{

		public DlgRandomOpenViewComponent View { get => this.GetComponent<DlgRandomOpenViewComponent>();} 

		 

	}
}
