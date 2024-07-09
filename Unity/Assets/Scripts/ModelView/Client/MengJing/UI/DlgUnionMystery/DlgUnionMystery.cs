namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnionMystery :Entity,IAwake,IUILogic
	{

		public DlgUnionMysteryViewComponent View { get => this.GetComponent<DlgUnionMysteryViewComponent>();} 

		 

	}
}
