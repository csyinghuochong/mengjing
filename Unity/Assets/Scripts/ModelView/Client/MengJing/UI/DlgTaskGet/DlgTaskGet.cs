namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTaskGet :Entity,IAwake,IUILogic
	{

		public DlgTaskGetViewComponent View { get => this.GetComponent<DlgTaskGetViewComponent>();} 

		 

	}
}
