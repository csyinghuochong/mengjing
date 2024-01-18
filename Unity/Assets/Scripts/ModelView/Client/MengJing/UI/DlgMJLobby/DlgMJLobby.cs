namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMJLobby :Entity,IAwake,IUILogic
	{

		public DlgMJLobbyViewComponent View { get => this.GetComponent<DlgMJLobbyViewComponent>();} 

		 

	}
}
