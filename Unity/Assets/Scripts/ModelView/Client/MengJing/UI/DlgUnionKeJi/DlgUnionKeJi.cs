namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnionKeJi :Entity,IAwake,IUILogic
	{

		public DlgUnionKeJiViewComponent View { get => this.GetComponent<DlgUnionKeJiViewComponent>();} 

		 

	}
}
