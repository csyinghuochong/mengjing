namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGuide :Entity,IAwake,IUILogic
	{

		public DlgGuideViewComponent View { get => this.GetComponent<DlgGuideViewComponent>();} 

		 

	}
}
