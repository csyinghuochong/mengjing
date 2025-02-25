namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDamageValue :Entity,IAwake,IUILogic
	{

		public DlgDamageValueViewComponent View { get => this.GetComponent<DlgDamageValueViewComponent>();} 

		 

	}
}
