namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgCommonProperty :Entity,IAwake,IUILogic
	{

		public DlgCommonPropertyViewComponent View { get => this.GetComponent<DlgCommonPropertyViewComponent>();} 

		 

	}
}
