namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetHeChengExplain :Entity,IAwake,IUILogic
	{

		public DlgPetHeChengExplainViewComponent View { get => this.GetComponent<DlgPetHeChengExplainViewComponent>();} 

		 

	}
}
