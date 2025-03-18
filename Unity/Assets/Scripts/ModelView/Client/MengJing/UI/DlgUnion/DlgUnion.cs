namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnion :Entity,IAwake,IUILogic
	{

		public DlgUnionViewComponent View { get => this.GetComponent<DlgUnionViewComponent>();} 

		 
		public bool ClickEnabled;
	}
}
