namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetMiningRecord :Entity,IAwake,IUILogic
	{

		public DlgPetMiningRecordViewComponent View { get => this.GetComponent<DlgPetMiningRecordViewComponent>();} 

		 

	}
}
