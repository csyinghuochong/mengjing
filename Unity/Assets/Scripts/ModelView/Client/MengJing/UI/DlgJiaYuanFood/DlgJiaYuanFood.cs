namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanFood :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanFoodViewComponent View { get => this.GetComponent<DlgJiaYuanFoodViewComponent>();} 

		 

	}
}
