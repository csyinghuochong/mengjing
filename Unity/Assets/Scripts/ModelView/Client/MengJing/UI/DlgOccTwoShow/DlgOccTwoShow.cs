namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgOccTwoShow :Entity,IAwake,IUILogic
	{

		public DlgOccTwoShowViewComponent View { get => this.GetComponent<DlgOccTwoShowViewComponent>();} 

		 

	}
}
