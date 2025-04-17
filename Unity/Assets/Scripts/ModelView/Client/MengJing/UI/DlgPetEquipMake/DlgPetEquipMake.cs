namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetEquipMake :Entity,IAwake,IUILogic
	{

		public DlgPetEquipMakeViewComponent View { get => this.GetComponent<DlgPetEquipMakeViewComponent>();} 

		 

	}
}
