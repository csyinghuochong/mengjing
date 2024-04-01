namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetHeXinSuit :Entity,IAwake,IUILogic
	{

		public DlgPetHeXinSuitViewComponent View { get => this.GetComponent<DlgPetHeXinSuitViewComponent>();} 

		 

	}
}
