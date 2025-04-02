namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMatch :Entity,IAwake,IUILogic
	{

		public DlgPetMatchViewComponent View { get => this.GetComponent<DlgPetMatchViewComponent>();} 

		 

	}
}
