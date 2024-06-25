namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetInfo :Entity,IAwake,IUILogic
	{

		public DlgPetInfoViewComponent View { get => this.GetComponent<DlgPetInfoViewComponent>();} 

		 

	}
}
