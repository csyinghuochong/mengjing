namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEquipDuiBiTips :Entity,IAwake,IUILogic
	{

		public DlgEquipDuiBiTipsViewComponent View { get => this.GetComponent<DlgEquipDuiBiTipsViewComponent>();} 

		 

	}
}
