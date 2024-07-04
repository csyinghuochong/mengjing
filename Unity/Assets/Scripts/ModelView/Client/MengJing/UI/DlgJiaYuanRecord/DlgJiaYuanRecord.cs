namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanRecord :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanRecordViewComponent View { get => this.GetComponent<DlgJiaYuanRecordViewComponent>();} 

		 

	}
}
