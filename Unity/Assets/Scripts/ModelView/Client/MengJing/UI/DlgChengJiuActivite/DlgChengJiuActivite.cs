namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgChengJiuActivite :Entity,IAwake,IUILogic
	{

		public DlgChengJiuActiviteViewComponent View { get => this.GetComponent<DlgChengJiuActiviteViewComponent>();} 

		 

	}
}
