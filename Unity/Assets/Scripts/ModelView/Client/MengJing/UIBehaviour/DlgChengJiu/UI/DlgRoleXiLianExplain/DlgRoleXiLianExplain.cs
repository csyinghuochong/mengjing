namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRoleXiLianExplain :Entity,IAwake,IUILogic
	{

		public DlgRoleXiLianExplainViewComponent View { get => this.GetComponent<DlgRoleXiLianExplainViewComponent>();} 

		 

	}
}
