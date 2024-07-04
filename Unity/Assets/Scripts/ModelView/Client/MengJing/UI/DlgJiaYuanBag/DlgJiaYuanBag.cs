namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanBag :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanBagViewComponent View { get => this.GetComponent<DlgJiaYuanBagViewComponent>();} 

		 

	}
}
