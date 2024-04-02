namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetChouKaGet :Entity,IAwake,IUILogic
	{

		public DlgPetChouKaGetViewComponent View { get => this.GetComponent<DlgPetChouKaGetViewComponent>();} 

		 

	}
}
