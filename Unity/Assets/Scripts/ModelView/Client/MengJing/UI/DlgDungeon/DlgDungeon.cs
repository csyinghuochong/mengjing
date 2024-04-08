namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDungeon :Entity,IAwake,IUILogic
	{

		public DlgDungeonViewComponent View { get => this.GetComponent<DlgDungeonViewComponent>();} 

		 

	}
}
