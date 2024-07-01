namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPetFubenResult :Entity,IAwake,IUILogic
	{

		public DlgPetFubenResultViewComponent View { get => this.GetComponent<DlgPetFubenResultViewComponent>();} 

		 

	}
}
