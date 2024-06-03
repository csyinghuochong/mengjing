namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgShouJi :Entity,IAwake,IUILogic
	{

		public DlgShouJiViewComponent View { get => this.GetComponent<DlgShouJiViewComponent>();} 

		 

	}
}
