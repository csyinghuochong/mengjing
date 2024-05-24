namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRoleXiLian :Entity,IAwake,IUILogic
	{

		public DlgRoleXiLianViewComponent View { get => this.GetComponent<DlgRoleXiLianViewComponent>();} 

		 

	}
}
