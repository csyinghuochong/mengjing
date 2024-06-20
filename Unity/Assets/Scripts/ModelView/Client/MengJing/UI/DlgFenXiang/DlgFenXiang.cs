namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgFenXiang :Entity,IAwake,IUILogic
	{

		public DlgFenXiangViewComponent View { get => this.GetComponent<DlgFenXiangViewComponent>();} 

		 

	}
}
