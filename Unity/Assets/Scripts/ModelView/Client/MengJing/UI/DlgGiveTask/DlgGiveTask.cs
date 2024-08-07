namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGiveTask :Entity,IAwake,IUILogic
	{

		public DlgGiveTaskViewComponent View { get => this.GetComponent<DlgGiveTaskViewComponent>();} 

		 

	}
}
