namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetEggChouKaProbExplain :Entity,IAwake,IUILogic
	{

		public DlgPetEggChouKaProbExplainViewComponent View { get => this.GetComponent<DlgPetEggChouKaProbExplainViewComponent>();} 

		 

	}
}
