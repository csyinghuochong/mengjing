namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGM :Entity,IAwake,IUILogic
	{

		public DlgGMViewComponent View { get => this.GetComponent<DlgGMViewComponent>();} 

		 

	}
}
