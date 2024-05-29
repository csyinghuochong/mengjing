namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetEggLucklyExplain :Entity,IAwake,IUILogic
	{

		public DlgPetEggLucklyExplainViewComponent View { get => this.GetComponent<DlgPetEggLucklyExplainViewComponent>();} 

		 

	}
}
