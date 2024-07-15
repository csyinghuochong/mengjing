namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgUnionXiuLian :Entity,IAwake,IUILogic
	{

		public DlgUnionXiuLianViewComponent View { get => this.GetComponent<DlgUnionXiuLianViewComponent>();} 

		 

	}
}
