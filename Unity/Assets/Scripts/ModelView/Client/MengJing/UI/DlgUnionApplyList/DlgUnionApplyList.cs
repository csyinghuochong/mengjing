namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnionApplyList :Entity,IAwake,IUILogic
	{

		public DlgUnionApplyListViewComponent View { get => this.GetComponent<DlgUnionApplyListViewComponent>();} 

		 

	}
}
