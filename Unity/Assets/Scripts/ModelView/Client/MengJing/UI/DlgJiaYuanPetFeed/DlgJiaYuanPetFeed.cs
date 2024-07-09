namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanPetFeed :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanPetFeedViewComponent View { get => this.GetComponent<DlgJiaYuanPetFeedViewComponent>();} 

		 

	}
}
