namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEnterMapHint :Entity,IAwake,IUILogic
	{

		public DlgEnterMapHintViewComponent View { get => this.GetComponent<DlgEnterMapHintViewComponent>();} 

		 

	}
}
