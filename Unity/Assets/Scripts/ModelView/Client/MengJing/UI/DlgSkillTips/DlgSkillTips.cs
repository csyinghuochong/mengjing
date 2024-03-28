namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSkillTips :Entity,IAwake,IUILogic
	{

		public DlgSkillTipsViewComponent View { get => this.GetComponent<DlgSkillTipsViewComponent>();} 

		 

	}
}
