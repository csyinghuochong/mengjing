namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRealName :Entity,IAwake,IUILogic
	{

		public DlgRealNameViewComponent View { get => this.GetComponent<DlgRealNameViewComponent>();} 

		 
		public int MapType { get; set; }

	}
}
