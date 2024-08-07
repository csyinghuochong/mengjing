namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGivePet :Entity,IAwake,IUILogic
	{

		public DlgGivePetViewComponent View { get => this.GetComponent<DlgGivePetViewComponent>();} 

		 

	}
}
