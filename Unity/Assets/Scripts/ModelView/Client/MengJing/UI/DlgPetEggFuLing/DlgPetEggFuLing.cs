namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetEggFuLing :Entity,IAwake,IUILogic
	{

		public DlgPetEggFuLingViewComponent View { get => this.GetComponent<DlgPetEggFuLingViewComponent>();} 

		 

	}
}
