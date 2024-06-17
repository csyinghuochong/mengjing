namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgZhanQu :Entity,IAwake,IUILogic
	{

		public DlgZhanQuViewComponent View { get => this.GetComponent<DlgZhanQuViewComponent>();} 

		 

	}
}
