namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgJiaYuanPet :Entity,IAwake,IUILogic
	{

		public DlgJiaYuanPetViewComponent View { get => this.GetComponent<DlgJiaYuanPetViewComponent>();} 

		 

	}
}
