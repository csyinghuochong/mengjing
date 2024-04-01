namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetHeXinHeCheng :Entity,IAwake,IUILogic
	{

		public DlgPetHeXinHeChengViewComponent View { get => this.GetComponent<DlgPetHeXinHeChengViewComponent>();} 

		 

	}
}
