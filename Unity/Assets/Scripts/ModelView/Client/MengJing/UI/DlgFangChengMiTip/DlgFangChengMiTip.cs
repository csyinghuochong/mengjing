namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgFangChengMiTip :Entity,IAwake,IUILogic
	{

		public DlgFangChengMiTipViewComponent View { get => this.GetComponent<DlgFangChengMiTipViewComponent>();} 

		 

	}
}
