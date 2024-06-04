namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetEgg :Entity,IAwake,IUILogic
	{

		public DlgPetEggViewComponent View { get => this.GetComponent<DlgPetEggViewComponent>();} 

		 

	}
}
