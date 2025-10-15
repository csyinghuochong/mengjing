namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgAllItem :Entity,IAwake,IUILogic
	{

		public DlgAllItemViewComponent View { get => this.GetComponent<DlgAllItemViewComponent>();} 

		 

	}
}
