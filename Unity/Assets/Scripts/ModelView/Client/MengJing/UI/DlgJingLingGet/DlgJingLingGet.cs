namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJingLingGet :Entity,IAwake,IUILogic
	{

		public DlgJingLingGetViewComponent View { get => this.GetComponent<DlgJingLingGetViewComponent>();} 

		 

	}
}
