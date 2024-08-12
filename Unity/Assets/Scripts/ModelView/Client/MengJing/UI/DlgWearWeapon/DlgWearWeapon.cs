namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgWearWeapon :Entity,IAwake,IUILogic
	{

		public DlgWearWeaponViewComponent View { get => this.GetComponent<DlgWearWeaponViewComponent>();} 

		 

	}
}
