namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRelink :Entity,IAwake,IUILogic
	{

		public DlgRelinkViewComponent View { get => this.GetComponent<DlgRelinkViewComponent>();} 

		 

	}
}
