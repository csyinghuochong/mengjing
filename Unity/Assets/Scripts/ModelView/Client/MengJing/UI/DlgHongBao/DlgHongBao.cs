namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgHongBao :Entity,IAwake,IUILogic
	{

		public DlgHongBaoViewComponent View { get => this.GetComponent<DlgHongBaoViewComponent>();} 

		 

	}
}
