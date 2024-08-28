namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgDungeonMapLevel :Entity,IAwake,IUILogic
	{

		public DlgDungeonMapLevelViewComponent View { get => this.GetComponent<DlgDungeonMapLevelViewComponent>();} 

		 

	}
}
