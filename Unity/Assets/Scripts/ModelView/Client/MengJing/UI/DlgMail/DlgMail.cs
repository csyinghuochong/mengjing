namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMail :Entity,IAwake,IUILogic
	{

		public DlgMailViewComponent View { get => this.GetComponent<DlgMailViewComponent>();} 

		 

	}
}
