namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgHunt :Entity,IAwake,IUILogic
	{

		public DlgHuntViewComponent View { get => this.GetComponent<DlgHuntViewComponent>();} 

		 

	}
}
