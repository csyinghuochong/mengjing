namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTowerOfSealJump :Entity,IAwake,IUILogic
	{

		public DlgTowerOfSealJumpViewComponent View { get => this.GetComponent<DlgTowerOfSealJumpViewComponent>();} 

		 

	}
}
