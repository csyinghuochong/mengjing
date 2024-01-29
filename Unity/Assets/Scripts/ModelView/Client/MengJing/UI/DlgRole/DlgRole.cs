namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRole :Entity,IAwake,IUILogic
	{

		public DlgRoleViewComponent View { get => this.GetComponent<DlgRoleViewComponent>();} 

		 

	}
}
