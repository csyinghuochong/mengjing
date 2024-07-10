namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgOpenChest :Entity,IAwake,IUILogic
	{

		public DlgOpenChestViewComponent View { get => this.GetComponent<DlgOpenChestViewComponent>();} 

		 

	}
}
